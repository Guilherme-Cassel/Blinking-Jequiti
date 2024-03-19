using System.Diagnostics;
using System.IO.Pipes;

namespace BlinkingJequiti;

/// <summary>
/// Pipe Name = "BlinkingJequiti"
/// </summary>
public static class JequitiPipeServer
{
    private const string PipeName = "BlinkingJequiti";
    private const string PipeShortCutText =
        $"""
        @echo off
        echo %* > \\.\pipe\{PipeName}
        """;

    private static string LocalBatPath = $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\Microsoft\\WindowsApps\\{PipeName}.bat";

    private static void CreateBat()
    {
        using StreamWriter writer = new(LocalBatPath);

        writer.Write(PipeShortCutText);
    }

    private static void DeleteBat() => File.Delete(LocalBatPath);

    public static async Task<string?> StartReading()
    {
        string? args = null;

        using NamedPipeServerStream pipeServer = new(PipeName, PipeDirection.InOut);
        try
        {
            CreateBat();

            await pipeServer.WaitForConnectionAsync();

            using StreamReader reader = new(pipeServer);

            args = reader.ReadLine();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Houve um Erro na Leitura do Pipeline \nErro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
        finally
        {
            _ = Task.Delay(1000).ContinueWith(x => DeleteBat());
        }

        if (args is not null)
            args = args.ToLower().Trim();

        return args;
    }
}