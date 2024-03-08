using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlinkingJequiti
{
    public class Program
    {
        private static async Task Main()
        {
            EnsureSingleInstance();
            await InitializeApp();
        }

        private static void EnsureSingleInstance()
        {
            if (!(new Mutex(true, AppDomain.CurrentDomain.FriendlyName)).WaitOne(TimeSpan.Zero, true))
            {
                Environment.Exit(0);
            }
        }

        private static async Task InitializeApp()
        {
            BlinkingAlgoritm.Start();
            await StartPipeLine();
        }

        private static async Task StartPipeLine()
        {
            while (true)
            {
                string? args = null;

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
                MessageBox.Show(BlinkingAlgoritm.NextBlinkTime);
            }
            else if (args == "blink")
            {
                await BlinkingAlgoritm.BlinkForm();
            }
        }
    }
}