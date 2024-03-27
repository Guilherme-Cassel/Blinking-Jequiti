using System.Diagnostics;

namespace BlinkingJequiti
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            UpdateDisplay();
            Focus();
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

        private void UpdateDisplay()
        {
            LabelNextBlink.Text = BlinkingAlgoritm.NextBlinkTime;
            if (BlinkingAlgoritm.cancellationTokenSource.IsCancellationRequested) BackColor = Color.LightSalmon; 
            else BackColor = Color.LightBlue;
        }
    }
}
