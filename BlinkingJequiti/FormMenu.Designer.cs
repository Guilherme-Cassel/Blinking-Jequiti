namespace BlinkingJequiti
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonPauseCounter = new Button();
            ButtonQuitApplication = new Button();
            ButtonRestartCounter = new Button();
            LabelNextBlink = new Label();
            ButtonBlink = new Button();
            SuspendLayout();
            // 
            // ButtonPauseCounter
            // 
            ButtonPauseCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonPauseCounter.BackColor = Color.FromArgb(255, 128, 128);
            ButtonPauseCounter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonPauseCounter.Location = new Point(329, 174);
            ButtonPauseCounter.Name = "ButtonPauseCounter";
            ButtonPauseCounter.Size = new Size(180, 80);
            ButtonPauseCounter.TabIndex = 0;
            ButtonPauseCounter.Text = "Pause Counter";
            ButtonPauseCounter.UseVisualStyleBackColor = false;
            ButtonPauseCounter.Click += ButtonStopCounter_Click;
            // 
            // ButtonQuitApplication
            // 
            ButtonQuitApplication.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonQuitApplication.BackColor = Color.Red;
            ButtonQuitApplication.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonQuitApplication.Location = new Point(12, 257);
            ButtonQuitApplication.Name = "ButtonQuitApplication";
            ButtonQuitApplication.Size = new Size(180, 80);
            ButtonQuitApplication.TabIndex = 1;
            ButtonQuitApplication.Text = "Quit Application";
            ButtonQuitApplication.UseVisualStyleBackColor = false;
            ButtonQuitApplication.Click += ButtonQuitApplication_Click;
            // 
            // ButtonRestartCounter
            // 
            ButtonRestartCounter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ButtonRestartCounter.BackColor = Color.FromArgb(128, 255, 128);
            ButtonRestartCounter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonRestartCounter.Location = new Point(329, 260);
            ButtonRestartCounter.Name = "ButtonRestartCounter";
            ButtonRestartCounter.Size = new Size(180, 80);
            ButtonRestartCounter.TabIndex = 2;
            ButtonRestartCounter.Text = "Restart Counter";
            ButtonRestartCounter.UseVisualStyleBackColor = false;
            ButtonRestartCounter.Click += ButtonRestartCounter_Click;
            // 
            // LabelNextBlink
            // 
            LabelNextBlink.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelNextBlink.Location = new Point(12, 43);
            LabelNextBlink.Name = "LabelNextBlink";
            LabelNextBlink.Size = new Size(497, 52);
            LabelNextBlink.TabIndex = 3;
            LabelNextBlink.Text = "Blinking Status";
            LabelNextBlink.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonBlink
            // 
            ButtonBlink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ButtonBlink.BackColor = Color.DeepSkyBlue;
            ButtonBlink.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonBlink.Location = new Point(12, 171);
            ButtonBlink.Name = "ButtonBlink";
            ButtonBlink.Size = new Size(180, 80);
            ButtonBlink.TabIndex = 4;
            ButtonBlink.Text = "Blink";
            ButtonBlink.UseVisualStyleBackColor = false;
            ButtonBlink.Click += ButtonBlink_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 352);
            Controls.Add(ButtonBlink);
            Controls.Add(LabelNextBlink);
            Controls.Add(ButtonRestartCounter);
            Controls.Add(ButtonQuitApplication);
            Controls.Add(ButtonPauseCounter);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BlinkingJequiti Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonPauseCounter;
        private Button ButtonQuitApplication;
        private Button ButtonRestartCounter;
        private Label LabelNextBlink;
        private Button ButtonBlink;
    }
}