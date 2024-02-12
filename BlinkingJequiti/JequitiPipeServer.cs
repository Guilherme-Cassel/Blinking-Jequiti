using System.IO.Pipes;

namespace BlinkingJequiti;


/// <summary>
/// Pipe Name = "BlinkingJequiti"
/// </summary>
public class JequitiPipeServer : IDisposable
{
    private const string PipeName = "BlinkingJequiti";
    private readonly NamedPipeServerStream pipeServer = new(PipeName, PipeDirection.InOut);

    internal async Task<string?> StartReading()
    {
        string? result = string.Empty;

        try
        {
            await pipeServer.WaitForConnectionAsync();

            using StreamReader reader = new(pipeServer);

            result = reader.ReadLine();

            reader.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (result is not null)
            result = result.ToLower().Trim();

        return result ?? string.Empty;
    }

    public void Dispose()
    {
        pipeServer.Close();
        pipeServer.Dispose();
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.SuppressFinalize(this);
    }
}