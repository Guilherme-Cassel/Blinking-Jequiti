namespace BlinkingJequiti;

public class Program
{
    public string NextBlink { get; set; }

    static async Task Main()
    {
        JequitiForm form = new JequitiForm();
        form.ShowDialog();

        Thread.Sleep(1000);

        form.Close();

        return;

        BlinkingAlgoritm blinkingAlgoritm = new();

        await blinkingAlgoritm.Start();

        MessageBox.Show(blinkingAlgoritm.NextBlinkTime);
    }
    private static async Task InitializeApp()
    {
        EnsureSingleInstance();
    }

    private static void EnsureSingleInstance()
    {
        Mutex singleton = new Mutex(true, AppDomain.CurrentDomain.FriendlyName);

        if (!singleton.WaitOne(TimeSpan.Zero, true))
        {
            //there is already another instance running!
            Environment.Exit(0);
        }
    }
}
