using System.Diagnostics;

namespace BlinkingJequiti
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void ButtonStopCounter_Click(object sender, EventArgs e)
        {
            BlinkingAlgoritm.Stop();
            UpdateDisplay(false);
        }

        private void ButtonQuitApplication_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void ButtonRestartCounter_Click(object sender, EventArgs e)
        {
            BlinkingAlgoritm.Restart();
            UpdateDisplay(true);
        }

        private void UpdateDisplay(bool running)
        {
            LabelNextBlink.Text = BlinkingAlgoritm.NextBlinkTime;
            if (running) BackColor = Color.LightBlue; else BackColor = Color.LightSalmon;
        }
    }
}
