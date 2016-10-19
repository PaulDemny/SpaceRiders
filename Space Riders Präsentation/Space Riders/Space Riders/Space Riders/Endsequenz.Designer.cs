namespace Space_Riders
{
    partial class Endsequenz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Endsequenz));
            this.Endanimation = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.Endanimation)).BeginInit();
            this.SuspendLayout();
            // 
            // Endanimation
            // 
            this.Endanimation.Enabled = true;
            this.Endanimation.Location = new System.Drawing.Point(-3, -4);
            this.Endanimation.Name = "Endanimation";
            this.Endanimation.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Endanimation.OcxState")));
            this.Endanimation.Size = new System.Drawing.Size(1930, 1092);
            this.Endanimation.TabIndex = 0;
            this.Endanimation.MouseDownEvent += new AxWMPLib._WMPOCXEvents_MouseDownEventHandler(this.Endanimation_MouseDownEvent);
            // 
            // Endsequenz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1084);
            this.Controls.Add(this.Endanimation);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Endsequenz";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Endsequenz";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Endsequenz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Endanimation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer Endanimation;
    }
}