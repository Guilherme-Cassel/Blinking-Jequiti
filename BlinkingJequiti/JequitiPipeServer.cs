using System.Diagnostics;
using System.IO.Pipes;
using System.Text;

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

    public static void CreateBat()
    {
        using FileStream fs = File.Create(LocalBatPath);
        using StreamWriter writer = new(fs);
        writer.Write(PipeShortCutText);
    }

    public static void DeleteBat() => File.Delete(LocalBatPath);

    public static async Task<string?> StartReading()
    {
        string? args = null;
        string defaultArgs = "show";

        bool isArgumentNullOrBlank()
        {
            if (string.IsNullOrWhiteSpace(args)) return true;

            string base64NullCallingResponse = "RUNITyBlc3Tvv70gZGVzYXRpdmFkby4=";
            byte[] argsBytes = Encoding.UTF8.GetBytes(args);
            string base64args = Convert.ToBase64String(argsBytes);

            if (base64args == base64NullCallingResponse)
                return true;
            else
                return false;
        }

        using NamedPipeServerStream pipeServer = new(PipeName, PipeDirection.InOut);
        try
        {
            await pipeServer.WaitForConnectionAsync();

            using StreamReader reader = new(pipeServer);

            args = reader.ReadLine();

            if (isArgumentNullOrBlank())
                args = defaultArgs;
        }
        catch (Exception)
        {
            return null;
        }

        if (args is not null)
            args = args.ToLower().Trim();

        return args;
    }
}