using System.Diagnostics;

namespace BlinkingJequiti
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            UpdateDisplay();

            Shown += FormMenu_Shown;
        }

        private void FormMenu_Shown(object? sender, EventArgs e)
        {
            Focus();
            BringToFront();
        }

        private void ButtonStopCounter_Click(object sender, EventArgs e)
        {
            BlinkingAlgoritm.Stop();
            UpdateDisplay();
        }

        private void ButtonQuitApplication_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void ButtonRestartCounter_Click(object sender, EventArgs e)
        {
            BlinkingAlgoritm.Restart();
            UpdateDisplay();
        }

        private async void ButtonBlink_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new();
            try
            {
                ButtonBlink.Enabled = false;

                Task blink = BlinkingAlgoritm.Blink();
                await blink.WaitAsync(cts.Token);

                ButtonBlink.Enabled = true;
            }
            catch (Exception ex)
            {
                await cts.CancelAsync();
                MessageBox.Show($"Error Message:\n\n{ex}", "Error While Executing Blink");
            }
        }

        private void UpdateDisplay()
        {
            LabelNextBlink.Text = BlinkingAlgoritm.NextBlinkTime;
            if (BlinkingAlgoritm.cancellationTokenSource.IsCancellationRequested) BackColor = Color.LightSalmon;
            else BackColor = Color.LightBlue;
        }
    }
}
