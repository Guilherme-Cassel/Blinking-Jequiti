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
            button2 = new Button();
            ButtonRestartCounter = new Button();
            LabelNextBlink = new Label();
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
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = Color.Red;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(12, 257);
            button2.Name = "button2";
            button2.Size = new Size(180, 80);
            button2.TabIndex = 1;
            button2.Text = "Quit Application";
            button2.UseVisualStyleBackColor = false;
            button2.Click += ButtonQuitApplication_Click;
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
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(521, 352);
            Controls.Add(LabelNextBlink);
            Controls.Add(ButtonRestartCounter);
            Controls.Add(button2);
            Controls.Add(ButtonPauseCounter);
            Name = "FormMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BlinkingJequiti Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button ButtonPauseCounter;
        private Button button2;
        private Button ButtonRestartCounter;
        private Label LabelNextBlink;
    }
}