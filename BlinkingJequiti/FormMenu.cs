namespace BlinkingJequiti
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BlinkingAlgoritm.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("next blink: " + BlinkingAlgoritm.NextBlinkTime);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BlinkingAlgoritm.Restart();
        }
    }
}
