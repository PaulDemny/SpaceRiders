namespace Space_Riders
{
    partial class GameOverAnimation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverAnimation));
            this.Animation = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).BeginInit();
            this.SuspendLayout();
            // 
            // Animation
            // 
            this.Animation.Enabled = true;
            this.Animation.Location = new System.Drawing.Point(-5, -4);
            this.Animation.Name = "Animation";
            this.Animation.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Animation.OcxState")));
            this.Animation.Size = new System.Drawing.Size(1958, 1092);
            this.Animation.TabIndex = 0;
            this.Animation.MouseDownEvent += new AxWMPLib._WMPOCXEvents_MouseDownEventHandler(this.Animation_MouseDownEvent);
            // 
            // GameOverAnimation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(2066, 1084);
            this.Controls.Add(this.Animation);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameOverAnimation";
            this.Text = "GameOverAnimation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GameOverAnimation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Animation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer Animation;
    }
}