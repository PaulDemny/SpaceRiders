namespace Space_Riders
{
    partial class Hauptmenue
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hauptmenue));
            this.Spielanleitung = new System.Windows.Forms.Button();
            this.Beenden = new System.Windows.Forms.Button();
            this.Optionen = new System.Windows.Forms.Button();
            this.Highscore = new System.Windows.Forms.Button();
            this.Spielen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Player_Rechts = new AxWMPLib.AxWindowsMediaPlayer();
            this.Player_Links = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.Player_Rechts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_Links)).BeginInit();
            this.SuspendLayout();
            // 
            // Spielanleitung
            // 
            this.Spielanleitung.BackColor = System.Drawing.Color.Red;
            this.Spielanleitung.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.Spielanleitung.FlatAppearance.BorderSize = 5;
            this.Spielanleitung.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Spielanleitung.Font = new System.Drawing.Font("Snap ITC", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Spielanleitung.ForeColor = System.Drawing.Color.Yellow;
            this.Spielanleitung.Location = new System.Drawing.Point(595, 830);
            this.Spielanleitung.Name = "Spielanleitung";
            this.Spielanleitung.Size = new System.Drawing.Size(303, 93);
            this.Spielanleitung.TabIndex = 22;
            this.Spielanleitung.Text = "Spielanleitung";
            this.Spielanleitung.UseVisualStyleBackColor = false;
            this.Spielanleitung.Click += new System.EventHandler(this.Spielanleitung_Click);
            // 
            // Beenden
            // 
            this.Beenden.BackColor = System.Drawing.Color.Red;
            this.Beenden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Beenden.Font = new System.Drawing.Font("Snap ITC", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Beenden.ForeColor = System.Drawing.Color.Yellow;
            this.Beenden.Location = new System.Drawing.Point(1544, 830);
            this.Beenden.Name = "Beenden";
            this.Beenden.Size = new System.Drawing.Size(251, 93);
            this.Beenden.TabIndex = 21;
            this.Beenden.Text = "Beenden";
            this.Beenden.UseVisualStyleBackColor = false;
            this.Beenden.Click += new System.EventHandler(this.Beenden_Click);
            // 
            // Optionen
            // 
            this.Optionen.BackColor = System.Drawing.Color.Red;
            this.Optionen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Optionen.Font = new System.Drawing.Font("Snap ITC", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Optionen.ForeColor = System.Drawing.Color.Yellow;
            this.Optionen.Location = new System.Drawing.Point(1088, 830);
            this.Optionen.Name = "Optionen";
            this.Optionen.Size = new System.Drawing.Size(254, 93);
            this.Optionen.TabIndex = 20;
            this.Optionen.Text = "Optionen";
            this.Optionen.UseVisualStyleBackColor = false;
            this.Optionen.Click += new System.EventHandler(this.Optionen_Click);
            // 
            // Highscore
            // 
            this.Highscore.BackColor = System.Drawing.Color.Red;
            this.Highscore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Highscore.Font = new System.Drawing.Font("Snap ITC", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Highscore.ForeColor = System.Drawing.Color.Yellow;
            this.Highscore.Location = new System.Drawing.Point(189, 830);
            this.Highscore.Name = "Highscore";
            this.Highscore.Size = new System.Drawing.Size(235, 93);
            this.Highscore.TabIndex = 19;
            this.Highscore.Text = "Highscore";
            this.Highscore.UseVisualStyleBackColor = false;
            this.Highscore.Click += new System.EventHandler(this.Highscore_Click);
            // 
            // Spielen
            // 
            this.Spielen.BackColor = System.Drawing.Color.DarkTurquoise;
            this.Spielen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Spielen.Font = new System.Drawing.Font("Snap ITC", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Spielen.ForeColor = System.Drawing.Color.Red;
            this.Spielen.Location = new System.Drawing.Point(680, 423);
            this.Spielen.Name = "Spielen";
            this.Spielen.Size = new System.Drawing.Size(561, 234);
            this.Spielen.TabIndex = 18;
            this.Spielen.Text = "!!!! SPIELEN !!!!";
            this.Spielen.UseVisualStyleBackColor = false;
            this.Spielen.Click += new System.EventHandler(this.Spielen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 72F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(532, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(782, 123);
            this.label1.TabIndex = 23;
            this.label1.Text = "Space Riders";
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Image = global::Space_Riders.Properties.Resources.MusicOn;
            this.checkBox1.Location = new System.Drawing.Point(1839, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(50, 50);
            this.checkBox1.TabIndex = 24;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Player_Rechts
            // 
            this.Player_Rechts.Enabled = true;
            this.Player_Rechts.Location = new System.Drawing.Point(1302, 40);
            this.Player_Rechts.Name = "Player_Rechts";
            this.Player_Rechts.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player_Rechts.OcxState")));
            this.Player_Rechts.Size = new System.Drawing.Size(531, 435);
            this.Player_Rechts.TabIndex = 27;
            // 
            // Player_Links
            // 
            this.Player_Links.Enabled = true;
            this.Player_Links.Location = new System.Drawing.Point(12, 12);
            this.Player_Links.Name = "Player_Links";
            this.Player_Links.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Player_Links.OcxState")));
            this.Player_Links.Size = new System.Drawing.Size(547, 485);
            this.Player_Links.TabIndex = 25;
            // 
            // Hauptmenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Space_Riders.Properties.Resources.Haumptmenue;
            this.ClientSize = new System.Drawing.Size(1286, 783);
            this.Controls.Add(this.Player_Rechts);
            this.Controls.Add(this.Player_Links);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Spielanleitung);
            this.Controls.Add(this.Beenden);
            this.Controls.Add(this.Optionen);
            this.Controls.Add(this.Highscore);
            this.Controls.Add(this.Spielen);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Hauptmenue";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Hauptmenue_Activated);
            this.Deactivate += new System.EventHandler(this.Hauptmenue_Deactivate);
            this.Load += new System.EventHandler(this.Hauptmenue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Player_Rechts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player_Links)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Spielanleitung;
        private System.Windows.Forms.Button Beenden;
        private System.Windows.Forms.Button Optionen;
        private System.Windows.Forms.Button Highscore;
        private System.Windows.Forms.Button Spielen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private AxWMPLib.AxWindowsMediaPlayer Player_Links;
        private AxWMPLib.AxWindowsMediaPlayer Player_Rechts;

    }
}

