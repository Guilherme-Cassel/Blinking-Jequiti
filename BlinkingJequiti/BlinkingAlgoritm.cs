namespace BlinkingJequiti
{
    public class BlinkingAlgoritm
    {
        private const int HalfHourInMiliseconds = 1800000;
        private const int TreeHoursInMilisecons = 3600000;
        private static readonly Random random = new();
        public string NextBlinkTime { get; private set; } = null!;

        public async void Start()
        {
            var randomDelay = random.Next(HalfHourInMiliseconds, TreeHoursInMilisecons);

            NextBlinkTime = (DateTime.Now.AddMilliseconds(randomDelay)).ToString();

            await ScheduleJequitiBlink(randomDelay);
        }

        private async Task ScheduleJequitiBlink(int delay)
        {
            await Task.Delay(delay);

            await BlinkForm();

            Start();
        }

        public static async Task BlinkForm()
        {
            await Task.Run(async () =>
            {
                try
                {
                    using JequitiForm form = new();

                    if (form.InvokeRequired)
                    {
                        await form.Invoke(async () => await BlinkForm());
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
