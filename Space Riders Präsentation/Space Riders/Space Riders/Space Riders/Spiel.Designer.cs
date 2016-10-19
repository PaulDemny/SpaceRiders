namespace Space_Riders
{
    partial class Spiel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spiel));
            this.pSpielflaeche = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pSpielflaeche
            // 
            this.pSpielflaeche.Location = new System.Drawing.Point(-3, -5);
            this.pSpielflaeche.Name = "pSpielflaeche";
            this.pSpielflaeche.Size = new System.Drawing.Size(1851, 954);
            this.pSpielflaeche.TabIndex = 0;
            this.pSpielflaeche.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pSpielflaeche_MouseClick);
            // 
            // Spiel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1844, 946);
            this.Controls.Add(this.pSpielflaeche);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Spiel";
            this.Text = "Spiel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Spiel_Activated);
            this.Deactivate += new System.EventHandler(this.Spiel_Deactivate);
            this.Load += new System.EventHandler(this.Spiel_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Spiel_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSpielflaeche;

    }
}