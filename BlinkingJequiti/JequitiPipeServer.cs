using System.IO.Pipes;

namespace BlinkingJequiti;


/// <summary>
/// Pipe Name = "BlinkingJequiti"
/// </summary>
public static class JequitiPipeServer
{
    private const string PipeName = "BlinkingJequiti";
    public static async Task<string?> StartReading()
    {
        string? args = string.Empty;

        using NamedPipeServerStream pipeServer = new(PipeName, PipeDirection.InOut);
        try
        {
            await pipeServer.WaitForConnectionAsync();

            using StreamReader reader = new(pipeServer);

            args = reader.ReadLine();

            reader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            await pipeServer.DisposeAsync();
        }

        if (args is not null)
            args = args.ToLower().Trim();

        return args;
    }
}