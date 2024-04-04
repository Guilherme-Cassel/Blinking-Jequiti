namespace BlinkingJequiti;

public static class BlinkingAlgoritm
{
    private const int HalfHourInMiliseconds = 1800000;

    private const int TreeHoursInMilisecons = 10800000;

    private static CancellationTokenSource cancellationTokenSource = new();

    public static bool IsOn => !cancellationTokenSource.IsCancellationRequested;

    public static string NextBlinkTime { get; private set; } = null!;

    public static void Start()
    {
        var randomDelay = new Random().Next(HalfHourInMiliseconds, TreeHoursInMilisecons);

        NextBlinkTime = "Next Blink: " + DateTime.Now.AddMilliseconds(randomDelay).ToString("HH:mm:ss");

        _ = ScheduleJequitiBlink(randomDelay);
    }

    public static void Restart()
    {
        if (!cancellationTokenSource.IsCancellationRequested) return;

        cancellationTokenSource = new CancellationTokenSource();

        Start();
    }

    public static void Stop()
    {
        NextBlinkTime = "Off";
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

        await WaitForUserActivity();

        await Blink();

        Start();
    }

    private static async Task WaitForUserActivity()
    {
        if (UserState.IsConnected)
            return;

        while (!UserState.IsConnected)
        {
            await Task.Delay(3000);
        }

        int randomDelay = new Random().Next(30000, 60000);

        await Task.Delay(randomDelay);

        if (UserState.IsConnected)
            return;
        else
            await WaitForUserActivity();
    }

    public static async Task Blink()
    {
        try
        {
            using JequitiForm form = new JequitiForm();

            if (form.InvokeRequired)
            {
                await form.Invoke(async () => await Blink());
                return;
            }

            await Task.Delay(1000);
            form.Visible = true;
            await Task.Delay(100);
            form.Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
