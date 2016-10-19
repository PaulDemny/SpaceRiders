using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse beeinhaltet das Optionen Formular
    /// </summary>
    public partial class Optionen : Form
    {
        /// <summary>
        /// Dieser Player spielt die Hintergrundmusik ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// Konstruktor des Optionen Formulars
        /// </summary>
        public Optionen()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald das GameOver Formular geladen wird. Der Soundplayer wird gestartet und das Raumschiff und die Schwierigkeit abhängig von den Variablen schiff und  schwierigkeit der Klasse speicher gewählt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Optionen_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = new Cursor(@"Cursor1.cur");
            }
            catch (Exception ex)
            {
                this.Cursor = this.DefaultCursor;
            }
            if (Speicher.MusicFlag)
            {
                this.Globale_Musik.Checked = true;
            }
            else
            {
                this.Globale_Musik.Checked = false;
            }
            switch (Speicher.Schiff)
            {
                case (1): this.rbSchiff1.Checked = true;
                    break;
                case (2): this.rbSchiff2.Checked = true;
                    break;
                case (3): this.rbSchiff3.Checked = true;
                    break;
                default: MessageBox.Show("Gehacktes Spiel oder beschädigte Spieldatei. Das Spiel wird beendet!!!");
                    Cursor.Hide();
                    Endsequenz Endsequenz = new Endsequenz();
                    Endsequenz.ShowDialog(this);
                    this.Dispose(true);
                    break;
            }
            switch (Speicher.Render)
            {
                case (100): this.rbSchlecht.Checked = true;
                    break;
                case (50): this.rbMittel.Checked = true;
                    break;
                case (30): this.rbUltra.Checked = true;
                    break;
                default: MessageBox.Show("Gehacktes Spiel oder beschädigte Spieldatei. Das Spiel wird beendet!!!");
                    Cursor.Hide();
                    Endsequenz Endsequenz = new Endsequenz();
                    Endsequenz.ShowDialog(this);
                    this.Dispose(true);
                    break;
            }
            switch (Speicher.Schwierigkeit)
            {
                case (2500): this.rbLeicht.Checked = true;
                    break;
                case (2000): this.rbNormal.Checked = true;
                    break;
                case (1600): this.rbSchwer.Checked = true;
                    break;
                case (1200): this.rbSehrSchwer.Checked = true;
                    break;
                case (900):  this.rbVeteran.Checked = true;
                    break;
                default: MessageBox.Show("Gehacktes Spiel oder beschädigte Spieldatei. Das Spiel wird beendet!!!");
                    Cursor.Hide();
                    Endsequenz Endsequenz = new Endsequenz();
                    Endsequenz.ShowDialog(this);
                    this.Dispose(true);
                    break;
            }
        }

        /// <summary>
        /// Dieses Event beendet das Optionen Formular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Optionen_schließen_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Dieses Event schaltet die Musik an und aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                //Musik an
                try
                {
                    this.checkBox1.Image = Properties.Resources.MusicOn;
                }
                catch (Exception ex)
                {
                    this.checkBox1.Dispose();
                }
                try
                {
                    this.player.controls.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
            else
            {
                try
                {
                    //Musik aus
                    this.checkBox1.Image = Properties.Resources.MusicMute;
                }
                catch (Exception ex)
                {
                    this.checkBox1.Dispose();
                }
                try
                {
                    this.player.controls.stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
        }

        /// <summary>
        /// Dieses Event setzt die Variablen der Klasse Speicher, schiff und schwierigkeit abhängig von den gwählten Optionen fest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speichern_und_fortsetzen_Click(object sender, EventArgs e)
        {
            if (this.rbLeicht.Checked)
            {
                Speicher.Schwierigkeit = 2500;
            }
            else if (this.rbNormal.Checked)
            {
                Speicher.Schwierigkeit = 2000;
            }
            else if (this.rbSchwer.Checked)
            {
                Speicher.Schwierigkeit = 1600;
            }
            else if (this.rbSehrSchwer.Checked)
            {
                Speicher.Schwierigkeit = 1200;
            }
            else if (this.rbVeteran.Checked)
            {
                Speicher.Schwierigkeit = 900;
            }
            if (this.rbSchiff1.Checked)
            {
                Speicher.Schiff = 1;
            }
            else if (this.rbSchiff2.Checked)
            {
                Speicher.Schiff = 2;
            }
            else if (this.rbSchiff3.Checked)
            {
                Speicher.Schiff = 3;
            }
            if (this.rbSchlecht.Checked)
            {
                Speicher.Render = 100;
            }
            else if (this.rbMittel.Checked)
            {
                Speicher.Render = 50;
            }
            else if (this.rbUltra.Checked)
            {
                Speicher.Render = 30;
            }
            this.Dispose(true);
        }

        /// <summary>
        /// Dieses Event schaltet die Musik an und aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Globale_Musik_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Globale_Musik.Checked)
            {
                Speicher.MusicFlag = true;
                try
                {
                    this.player.controls.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
            else
            {
                Speicher.MusicFlag = false;
                try
                {
                    this.player.controls.stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
        }

        /// <summary>
        /// Wenn das Optionen aktiviert wird, wird der Hintergrundsound abgespielt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Optionen_Activated(object sender, EventArgs e)
        {
            if (Speicher.MusicFlag)
            {
                try
                {
                    this.player.URL = @"Optionen.mp3";
                    this.player.settings.setMode("Loop", true);
                    this.player.controls.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
        }

        /// <summary>
        ///  Wenn das Hauptmenue nicht das aktive Formular ist, wird der Souond gestoppt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Optionen_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.player.controls.stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
            }
        }
    }
}
