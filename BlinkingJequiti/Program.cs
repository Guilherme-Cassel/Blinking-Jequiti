using KernelAgent;

namespace BlinkingJequiti;

internal static class Program
{
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        //InitializeApp();

        Application.Run();

        BlinkingAlgoritm.BlinkForm1();
    }
    static void InitializeApp()
    {
        EnsureSingleInstance();
    }


    static void EnsureSingleInstance()
    {
        Mutex singleton = new Mutex(true, AppDomain.CurrentDomain.FriendlyName);

        if (!singleton.WaitOne(TimeSpan.Zero, true))
        {
            //there is already another instance running!
            Environment.Exit(0);
        }
    }
}
