namespace Space_Riders
{
    partial class GameOver
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
            this.lScoreAusgabe = new System.Windows.Forms.Label();
            this.lScore = new System.Windows.Forms.Label();
            this.bBeenden = new System.Windows.Forms.Button();
            this.bSpeichern = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lNameeintragen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lScoreAusgabe
            // 
            this.lScoreAusgabe.AutoSize = true;
            this.lScoreAusgabe.BackColor = System.Drawing.Color.Transparent;
            this.lScoreAusgabe.Font = new System.Drawing.Font("Snap ITC", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScoreAusgabe.ForeColor = System.Drawing.Color.Red;
            this.lScoreAusgabe.Location = new System.Drawing.Point(618, 148);
            this.lScoreAusgabe.Name = "lScoreAusgabe";
            this.lScoreAusgabe.Size = new System.Drawing.Size(0, 45);
            this.lScoreAusgabe.TabIndex = 12;
            // 
            // lScore
            // 
            this.lScore.AutoSize = true;
            this.lScore.BackColor = System.Drawing.Color.Transparent;
            this.lScore.Font = new System.Drawing.Font("Snap ITC", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScore.ForeColor = System.Drawing.Color.Red;
            this.lScore.Location = new System.Drawing.Point(270, 148);
            this.lScore.Name = "lScore";
            this.lScore.Size = new System.Drawing.Size(260, 45);
            this.lScore.TabIndex = 11;
            this.lScore.Text = "Dein Score:";
            // 
            // bBeenden
            // 
            this.bBeenden.BackColor = System.Drawing.Color.Red;
            this.bBeenden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bBeenden.Font = new System.Drawing.Font("Snap ITC", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bBeenden.ForeColor = System.Drawing.Color.Yellow;
            this.bBeenden.Location = new System.Drawing.Point(866, 478);
            this.bBeenden.Name = "bBeenden";
            this.bBeenden.Size = new System.Drawing.Size(275, 109);
            this.bBeenden.TabIndex = 10;
            this.bBeenden.Text = "Beenden";
            this.bBeenden.UseVisualStyleBackColor = false;
            this.bBeenden.Click += new System.EventHandler(this.bBeenden_Click);
            // 
            // bSpeichern
            // 
            this.bSpeichern.BackColor = System.Drawing.Color.Red;
            this.bSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bSpeichern.Font = new System.Drawing.Font("Snap ITC", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSpeichern.ForeColor = System.Drawing.Color.Yellow;
            this.bSpeichern.Location = new System.Drawing.Point(90, 478);
            this.bSpeichern.Name = "bSpeichern";
            this.bSpeichern.Size = new System.Drawing.Size(339, 109);
            this.bSpeichern.TabIndex = 9;
            this.bSpeichern.Text = "Speichern";
            this.bSpeichern.UseVisualStyleBackColor = false;
            this.bSpeichern.Click += new System.EventHandler(this.bSpeichern_Click);
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(580, 293);
            this.tbName.MaximumSize = new System.Drawing.Size(200, 50);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(200, 24);
            this.tbName.TabIndex = 8;
            this.tbName.TabStop = false;
            this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbName.WordWrap = false;
            // 
            // lNameeintragen
            // 
            this.lNameeintragen.AutoSize = true;
            this.lNameeintragen.BackColor = System.Drawing.Color.Transparent;
            this.lNameeintragen.Font = new System.Drawing.Font("Snap ITC", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNameeintragen.ForeColor = System.Drawing.Color.Red;
            this.lNameeintragen.Location = new System.Drawing.Point(297, 278);
            this.lNameeintragen.Name = "lNameeintragen";
            this.lNameeintragen.Size = new System.Drawing.Size(145, 45);
            this.lNameeintragen.TabIndex = 7;
            this.lNameeintragen.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 48F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(205, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(867, 82);
            this.label1.TabIndex = 13;
            this.label1.Text = "Highscore abspeichern";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Space_Riders.Properties.Resources.GameOver;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bBeenden);
            this.panel1.Controls.Add(this.lScoreAusgabe);
            this.panel1.Controls.Add(this.bSpeichern);
            this.panel1.Controls.Add(this.lScore);
            this.panel1.Controls.Add(this.lNameeintragen);
            this.panel1.Controls.Add(this.tbName);
            this.panel1.Location = new System.Drawing.Point(343, 154);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1212, 625);
            this.panel1.TabIndex = 14;
            // 
            // GameOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 1084);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameOver";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "GameOver";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.GameOver_Activated);
            this.Deactivate += new System.EventHandler(this.GameOver_Deactivate);
            this.Load += new System.EventHandler(this.GameOver_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lScoreAusgabe;
        private System.Windows.Forms.Label lScore;
        private System.Windows.Forms.Button bBeenden;
        private System.Windows.Forms.Button bSpeichern;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lNameeintragen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}