using BlinkingJequiti;

namespace KernelAgent
{
    public class BlinkingAlgoritm
    {
        const int OneHourInMiliseconds = 3600000;
        const int TreeHoursInMilisecons = 10800000;

        static void LoopThroughJequitiBlink()
        {
            while (true)
            {
                Thread.Sleep(new Random()
                    .Next(OneHourInMiliseconds, TreeHoursInMilisecons));

                BlinkForm1();
            }
        }

        public static async void BlinkForm1()
        {
            try
            {
                using JequitiForm form1 = new();
                form1.Hide();

                await Task.Delay(1000);

                if (form1.InvokeRequired)
                {
                    form1.Invoke(new Action(BlinkForm1));
                    return;
                }

                form1.Visible = true;
                await Task.Delay(100);
                form1.Visible = false;

                form1.Close();
                form1.Dispose();
            }
            catch (Exception)
            {
                //Just Ignore
            }
        }

    }
}
