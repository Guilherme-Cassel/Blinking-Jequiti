using System.IO.Pipes;

namespace BlinkingJequiti;


/// <summary>
/// Pipe Name = "BlinkingJequiti"
/// </summary>
public class JequitiPipeServer : IDisposable
{
    private const string PipeName = "BlinkingJequiti";
    private readonly NamedPipeServerStream pipeServer = new(PipeName, PipeDirection.InOut);

    public void Dispose()
    {
        GC.WaitForPendingFinalizers();
        GC.SuppressFinalize(this);
        GC.Collect();
    }

    internal async Task<string?> StartReading()
    {
        string? args = string.Empty;

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

        if (args is not null)
            args = args.ToLower().Trim();

        return args ?? string.Empty;
    }
}