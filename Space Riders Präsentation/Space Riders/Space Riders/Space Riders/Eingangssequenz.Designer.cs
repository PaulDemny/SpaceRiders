namespace Space_Riders
{
    partial class Eingangssequenz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eingangssequenz));
            this.Eingangsanimation = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.Eingangsanimation)).BeginInit();
            this.SuspendLayout();
            // 
            // Eingangsanimation
            // 
            this.Eingangsanimation.Enabled = true;
            this.Eingangsanimation.Location = new System.Drawing.Point(0, -1);
            this.Eingangsanimation.Name = "Eingangsanimation";
            this.Eingangsanimation.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Eingangsanimation.OcxState")));
            this.Eingangsanimation.Size = new System.Drawing.Size(1929, 1111);
            this.Eingangsanimation.TabIndex = 0;
            this.Eingangsanimation.MouseDownEvent += new AxWMPLib._WMPOCXEvents_MouseDownEventHandler(this.Eingangsanimation_MouseDownEvent);
            // 
            // Eingangssequenz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 773);
            this.Controls.Add(this.Eingangsanimation);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Eingangssequenz";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Eingangssequenz";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Eingangssequenz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Eingangsanimation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer Eingangsanimation;

    }
}