using System.Diagnostics;

namespace BlinkingJequiti
{
    public class Program
    {
        public static Thread Blinking = new(BlinkingAlgoritm.Start);

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
            StartPipeLine();
        }

        private static async void StartPipeLine()
        {
            string? args;

            while (true)
            {
                args = null;

                try
                {
                    JequitiPipeServer.CreateBat();

                    args = await JequitiPipeServer.StartReading();

                    JequitiPipeServer.DeleteBat();

                    if (args is null)
                        continue;
                }
                catch (Exception)
                {
                    continue;
                }
                finally
                {
                    await RunScript(args!);
                }
            }
        }

        private static async Task RunScript(string args)
        {
            if (args == "show")
            {
                using FormMenu formMenu = new();
                formMenu.ShowDialog();
            }
            else if (args == "blink")
            {
                await BlinkingAlgoritm.Blink();
            }
            else
            {
                return;
            }
        }
    }
}