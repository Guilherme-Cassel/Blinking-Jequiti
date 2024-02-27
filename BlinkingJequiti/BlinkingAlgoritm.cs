namespace BlinkingJequiti
{
    public class BlinkingAlgoritm
    {
        private const int HalfHourInMiliseconds = 5000/*1800000*/;
        private const int TreeHoursInMilisecons = 10000;
        private static readonly Random random = new();
        public string NextBlinkTime { get; private set; } = null!;

        public async Task Start()
        {
            var randomDelay = random.Next(HalfHourInMiliseconds, TreeHoursInMilisecons);

            NextBlinkTime = (DateTime.Now.AddMilliseconds(randomDelay)).ToString();

            await LoopThroughJequitiBlink(randomDelay);
        }

        private async Task LoopThroughJequitiBlink(int delay)
        {
            await Task.Delay(delay);

            await BlinkForm1();

            await Start();
        }

        public static async Task BlinkForm1()
        {
            await Task.Run(async () =>
            {
                try
                {
                    using JequitiForm form = new();

                    if (form.InvokeRequired)
                    {
                        await form.Invoke(async () => await BlinkForm1());
                        return;
                    }

                    Task.Delay(1000).Wait();

                    form.Visible = true;

                    Task.Delay(100).Wait();

                    form.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
    }
}
