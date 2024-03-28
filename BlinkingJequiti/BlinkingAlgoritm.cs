namespace BlinkingJequiti
{
    public static class BlinkingAlgoritm
    {
        private const int HalfHourInMiliseconds = 1800000;

        private const int TreeHoursInMilisecons = 3600000;
        public static string NextBlinkTime { get; private set; } = null!;

        private static readonly Random random = new();

        public static CancellationTokenSource cancellationTokenSource = new();

        public static async void Start()
        {
            var randomDelay = random.Next(HalfHourInMiliseconds, TreeHoursInMilisecons);

            NextBlinkTime = DateTime.Now.AddMilliseconds(randomDelay).ToString();

            await ScheduleJequitiBlink(randomDelay);
        }

        public static void Restart()
        {
            if (!cancellationTokenSource.IsCancellationRequested) return;
            cancellationTokenSource = new CancellationTokenSource();
            Start();
        }

        public static void Stop()
        {
            NextBlinkTime = "Blinking is Paused!";
            cancellationTokenSource.Cancel();
        }

        private static async Task ScheduleJequitiBlink(int delay)
        {
            try
            {
                await Task.Delay(delay, cancellationTokenSource.Token);
            }
            catch (TaskCanceledException)
            {
                return;
            }

            if (!UserState.IsConnected)
            {
                while (!UserState.IsConnected)
                {
                    await Task.Delay(3000);
                }

                await Task.Delay(30000);
            }

            await Blink();

            Start();
        }

        public static async Task Blink()
        {
            await Task.Run(async () =>
            {
                try
                {
                    using JequitiForm form = new();

                    if (form.InvokeRequired)
                    {
                        await form.Invoke(async () => await Blink());
                        return;
                    }

                    Task.Delay(1000).Wait();

                    form.Visible = true;

                    Task.Delay(50).Wait();

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
