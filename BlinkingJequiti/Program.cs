using System.Diagnostics;

namespace BlinkingJequiti
{
    public class Program
    {
        public static Thread Blinking = new(BlinkingAlgoritm.Start);
        public static Thread PipeLine = new(StartPipeLine);

        private static void Main()
        {
            Application.EnableVisualStyles();

            EnsureSingleInstance();
            InitializeApp();

            Application.Run();
        }

        private static void EnsureSingleInstance()
        {
            if (!(new Mutex(true, AppDomain.CurrentDomain.FriendlyName)).WaitOne(TimeSpan.Zero, true))
            {
                Environment.Exit(0);
            }
        }

        private static void InitializeApp()
        {
            Blinking.Start();
            PipeLine.Start();
        }

        private static async void StartPipeLine()
        {
            string? args;

            while (true)
            {
                args = null;

                try
                {
                    args = await JequitiPipeServer.StartReading();

                    if (args is null)
                        continue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    await RunScript(args!);
                }
            }
        }

        private static async Task RunScript(string args)
        {
            if (args == null)
                return;

            if (args == "show")
            {
                using FormMenu formMenu = new();
                formMenu.ShowDialog();
            }
            else if (args == "blink")
            {
                await BlinkingAlgoritm.Blink();
            }
        }
    }
}