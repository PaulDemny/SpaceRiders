using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse ist das Hauptmenue des Spiels und enthält alle Pfade
    /// </summary>
    public partial class Hauptmenue : Form
    {
        /// <summary>
        /// Dieser Player spielt die Hintergrundmusik ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// Konstruktor des Haumptmenus
        /// </summary>
        public Hauptmenue()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald das Hauptmenue geladen wird. Zuerst wird die Eingangssequenz geöffnet, danach die beiden Videos und die Musik gestartet 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hauptmenue_Load(object sender, EventArgs e)
        {
            //Die Eingangssequenz wird als erstes geöffnet
            Eingangssequenz eingangssequenz = new Eingangssequenz();
            try
            {
                eingangssequenz.ShowDialog(this);
            }
            catch (Exception ex)
            {
                eingangssequenz.Dispose();
            }
            try
            {
                //Die URLs der beiden Seitenvideos werden festgelegt
                this.Player_Links.URL = @"Player_links.mp4";
                this.Player_Rechts.URL = @"Player_rechts.mp4";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
                this.Player_Links.Dispose();
                this.Player_Rechts.Dispose();
            }
            try
            {
                this.Cursor = new Cursor(@"Cursor1.cur");
            }
            catch (Exception ex)
            {
                this.Cursor = this.DefaultCursor;
            }
            Cursor.Show();
        }

        /// <summary>
        /// Dieses Event öffnet das eigentliche Spiel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spielen_Click(object sender, EventArgs e)
        {
            //Überprüfung der Variablen
            try
            {
                switch (Speicher.Schwierigkeit)
                {
                    case (2500): break;
                    case (2000): break;
                    case (1600): break;
                    case (1200): break;
                    case (900): break;
                    default: MessageBox.Show("Gehacktes Spiel oder beschädigte Spieldatei. Das Spiel wird beendet!!!");
                        Cursor.Hide();
                        Endsequenz Endsequenz = new Endsequenz();
                        Endsequenz.ShowDialog(this);
                        break;
                }
                switch (Speicher.Schiff)
                {
                    case (1): break;
                    case (2): break;
                    case (3): break;
                    case (4): break;
                    case (5): break;
                    case (6): break;
                    default: MessageBox.Show("Gehacktes Spiel oder beschädigte Spieldatei. Das Spiel wird beendet!!!");
                        Cursor.Hide();
                        Endsequenz Endsequenz = new Endsequenz();
                        Endsequenz.ShowDialog(this);
                        break;
                }
                MessageBox.Show("Falls sie vergessen haben eine Schwierigkeitsstufe oder Schiff im Optionenmenü auszuwählen, können sie diese im Pausenmenü des Spiels (Leertaste) auswählen");
                Spiel Spiel = new Spiel();
                Spiel.ShowDialog(this);
            }
            catch (Exception ex)
            {
                try
                {
                    MessageBox.Show("Beschädigte Spieldatei, Spiel wird beendet!!!");
                    Endsequenz Endsequenz = new Endsequenz();
                    Endsequenz.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Beschädigte Spieldatei, Spiel wird beendet!!!");
                    Application.Exit();
                }
            }                       
        }

        /// <summary>
        /// Dieses Event öffnet die Form Highscore 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Highscore_Click(object sender, EventArgs e)
        {
            try
            {
                Highscore Highscore = new Highscore();
                Highscore.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Spieldatei, Spiel wird beendet!!!");
                Endsequenz Endsequenz = new Endsequenz();
                Endsequenz.ShowDialog();
            }
        }

        /// <summary>
        /// Dieses Event öffnet die Form Spielanleitung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spielanleitung_Click(object sender, EventArgs e)
        {
            try
            {
                Spielanleitung Spielanleitung = new Spielanleitung();
                Spielanleitung.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Spieldatei, Spiel wird beendet!!!");
                Endsequenz Endsequenz = new Endsequenz();
                Endsequenz.ShowDialog();
            }
        }

        /// <summary>
        /// Dieses Event öffnet die Form Optionen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Optionen_Click(object sender, EventArgs e)
        {
            try
            {
                Optionen Optionen = new Optionen();
                Optionen.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Spieldatei, Spiel wird beendet!!!");
                Endsequenz Endsequenz = new Endsequenz();
                Endsequenz.ShowDialog();
            }
        }

        /// <summary>
        /// Dieses Event öffnet die Form Endsequenz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Beenden_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Hide();
                Endsequenz Endsequenz = new Endsequenz();
                Endsequenz.ShowDialog(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Beschädigte Spieldatei, Spiel wird abgebrochen. Bitte erneut öffnen!!!");
                Application.Exit();
            }
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
                    MessageBox.Show("Beschädigte Musikdatei oder ihr Betriebssystem ist nicht Windows!");
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
                    MessageBox.Show("Beschädigte Musikdatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
        }

        /// <summary>
        /// Wenn das Hauptmenue aktiviert wird, wird der Hintergrundsound abgespielt und die Videos gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hauptmenue_Activated(object sender, EventArgs e)
        {
            //Falls globale Musik aktiviert ist
            if (Speicher.MusicFlag)
            {
                //Sound wirg gestartet
                try
                {
                    this.player.URL = @"Hauptmenue.mp3";
                    this.player.settings.setMode("Loop", true);
                    this.player.controls.play();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
            //Videos werden gestartet
            try
            {
                this.Player_Links.Ctlcontrols.play();
                this.Player_Rechts.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
            }
        }

        /// <summary>
        /// Wenn das Hauptmenue nicht das aktive Formular ist, werden die Videos und der Souond gestoppt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hauptmenue_Deactivate(object sender, EventArgs e)
        {
            //Videos werden gestoppt
            try
            {
                this.Player_Links.Ctlcontrols.stop();
                this.Player_Rechts.Ctlcontrols.stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
            }
            //Sound wird gestoppt
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
