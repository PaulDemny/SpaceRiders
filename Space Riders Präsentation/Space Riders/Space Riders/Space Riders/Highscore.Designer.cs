namespace Space_Riders
{
    partial class Highscore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Highscore));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Highscore_schließen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.lbHighscore = new System.Windows.Forms.ListBox();
            this.cbHighscore = new System.Windows.Forms.ComboBox();
            this.Speichern = new System.Windows.Forms.Button();
            this.Drucken = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.SuspendLayout();
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
            this.checkBox1.TabIndex = 34;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Highscore_schließen
            // 
            this.Highscore_schließen.BackColor = System.Drawing.Color.Red;
            this.Highscore_schließen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Highscore_schließen.Font = new System.Drawing.Font("Snap ITC", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Highscore_schließen.ForeColor = System.Drawing.Color.Yellow;
            this.Highscore_schließen.Location = new System.Drawing.Point(1274, 865);
            this.Highscore_schließen.Name = "Highscore_schließen";
            this.Highscore_schließen.Size = new System.Drawing.Size(415, 72);
            this.Highscore_schließen.TabIndex = 31;
            this.Highscore_schließen.Text = "Highscore schließen";
            this.Highscore_schließen.UseVisualStyleBackColor = false;
            this.Highscore_schließen.Click += new System.EventHandler(this.Highscore_schließen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 48F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(122, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 82);
            this.label1.TabIndex = 28;
            this.label1.Text = "Highscore";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Space_Riders.Properties.Resources.Falke;
            this.pictureBox2.Location = new System.Drawing.Point(1728, 880);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 45);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Space_Riders.Properties.Resources.Falke;
            this.pictureBox4.Location = new System.Drawing.Point(1172, 880);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(62, 45);
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1274, 479);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(303, 194);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = global::Space_Riders.Properties.Resources.MilleniumFalke;
            this.pictureBox12.Location = new System.Drawing.Point(1009, 123);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(308, 132);
            this.pictureBox12.TabIndex = 29;
            this.pictureBox12.TabStop = false;
            // 
            // lbHighscore
            // 
            this.lbHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHighscore.FormattingEnabled = true;
            this.lbHighscore.ItemHeight = 25;
            this.lbHighscore.Location = new System.Drawing.Point(135, 318);
            this.lbHighscore.Name = "lbHighscore";
            this.lbHighscore.Size = new System.Drawing.Size(702, 604);
            this.lbHighscore.TabIndex = 35;
            // 
            // cbHighscore
            // 
            this.cbHighscore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHighscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHighscore.ForeColor = System.Drawing.Color.Black;
            this.cbHighscore.FormattingEnabled = true;
            this.cbHighscore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbHighscore.Items.AddRange(new object[] {
            "Alle",
            "Einfach",
            "Normal",
            "Schwer",
            "Sehr Schwer",
            "Veteran"});
            this.cbHighscore.Location = new System.Drawing.Point(135, 234);
            this.cbHighscore.Name = "cbHighscore";
            this.cbHighscore.Size = new System.Drawing.Size(146, 24);
            this.cbHighscore.TabIndex = 36;
            this.cbHighscore.SelectedIndexChanged += new System.EventHandler(this.cbHighscore_SelectedIndexChanged);
            // 
            // Speichern
            // 
            this.Speichern.BackColor = System.Drawing.Color.Red;
            this.Speichern.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Speichern.Font = new System.Drawing.Font("Snap ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Speichern.Location = new System.Drawing.Point(370, 206);
            this.Speichern.Name = "Speichern";
            this.Speichern.Size = new System.Drawing.Size(240, 76);
            this.Speichern.TabIndex = 37;
            this.Speichern.Text = "Liste als .csv abspeichern";
            this.Speichern.UseVisualStyleBackColor = false;
            this.Speichern.Click += new System.EventHandler(this.Speichern_Click);
            // 
            // Drucken
            // 
            this.Drucken.BackColor = System.Drawing.Color.Red;
            this.Drucken.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Drucken.Font = new System.Drawing.Font("Snap ITC", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drucken.Location = new System.Drawing.Point(644, 205);
            this.Drucken.Name = "Drucken";
            this.Drucken.Size = new System.Drawing.Size(187, 76);
            this.Drucken.TabIndex = 38;
            this.Drucken.Text = "Liste drucken";
            this.Drucken.UseVisualStyleBackColor = false;
            this.Drucken.Click += new System.EventHandler(this.Drucken_Click);
            // 
            // Highscore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Space_Riders.Properties.Resources.Highscore;
            this.ClientSize = new System.Drawing.Size(1901, 1044);
            this.Controls.Add(this.Drucken);
            this.Controls.Add(this.Speichern);
            this.Controls.Add(this.cbHighscore);
            this.Controls.Add(this.lbHighscore);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.Highscore_schließen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Highscore";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Highscore";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Highscore_Activated);
            this.Deactivate += new System.EventHandler(this.Highscore_Deactivate);
            this.Load += new System.EventHandler(this.Highscore_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button Highscore_schließen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbHighscore;
        private System.Windows.Forms.ComboBox cbHighscore;
        private System.Windows.Forms.Button Speichern;
        private System.Windows.Forms.Button Drucken;
    }
}