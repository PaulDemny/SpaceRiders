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
    /// Diese Klasse beeinhaltet das Pause Formular
    /// </summary>
    public partial class Pause : Form
    {
        /// <summary>
        /// Es wird eine Instanz der Klasse Spiel erstellt
        /// </summary>
        private Spiel spiel = new Spiel();

        /// <summary>
        /// Es wird eine Instanz der Klasse Flugmanager erstellt
        /// </summary>
        private Flugmanager flugmanger;

        /// <summary>
        /// Es wird eine Instanz der Klasse Raumschiff erstellt
        /// </summary>
        private Raumschiff raumschiff;

        /// <summary>
        /// Dieser Soundplayer spielt die Hintergrundmusik ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// Dieser Variable wird der Wert des Scores des Spiels zugewiesen
        /// </summary>
        private int punkte;

        /// <summary>
        /// Dieser Variable wird der Wert des Levels des Spiels zugewiesen
        /// </summary>
        private int schwierigkeit;

        /// <summary>
        /// Dieser Variable wird der Wert des Raumschiffs des Spiels zugewiesen
        /// </summary>
        private int schiff;

        /// <summary>
        /// Dieser Variable wird der Wert der Variable schwierigkeit der Klasse Speicher zugewiesen
        /// </summary>
        private int level;

        /// <summary>
        /// Diese Flag steurt den Sound im Spiel
        /// </summary>
        private bool sound;

      /// <summary>
        /// Konstruktor des Pause Formulars
      /// </summary>
      /// <param name="score"></param>
      /// <param name="spiellevel"></param>
      /// <param name="schiff"></param>
      /// <param name="musik"></param>
      /// <param name="manager"></param>
        public Pause(int score, int spiellevel, Raumschiff schiff, bool musik, Flugmanager manager)
        {
            this.InitializeComponent();
            this.punkte = score;
            this.raumschiff = schiff;
            this.level = spiellevel;
            this.sound = musik;
            this.flugmanger = manager;
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald das Highscore Pause geladen wird. Der Soundplayer wird gestartet und das Raumschiff und die Schwierigkeit abhängig von den Variablen schiff und  schwierigkeit der Klasse speicher gewählt und die verschiedenen Raumschiffe aktiviert bzw. deaktiviert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pause_Load(object sender, EventArgs e)
        {
            try
            {
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
                switch (Speicher.Schiff)
                {
                    case (1): this.rbSchiff1.Checked = true;
                        break;
                    case (2): this.rbSchiff2.Checked = true;
                        break;
                    case (3): this.rbSchiff3.Checked = true;
                        break;
                    case (4): this.rbSchiff4.Checked = true;
                        break;
                    case (5): this.rbSchiff5.Checked = true;
                        break;
                    case (6): this.rbSchiff6.Checked = true;
                        break;
                    default: MessageBox.Show("Gehacktes Spiel oder beschädigte Spieldatei. Das Spiel wird beendet!!!");
                        Cursor.Hide();
                        Endsequenz Endsequenz = new Endsequenz();
                        Endsequenz.ShowDialog(this);
                        this.Dispose(true);
                        break;
                }
                if (this.level >= 10)
                {
                    this.rbSchiff4.Enabled = true;
                    this.rbSchiff5.Enabled = true;
                }
                else
                {
                    this.rbSchiff4.Enabled = false;
                    this.rbSchiff5.Enabled = false;
                }
                if (level >= 15)
                {
                    this.rbSchiff6.Enabled = true;
                }
                else
                {
                    this.rbSchiff6.Enabled = false;
                }
                if (sound)
                {
                    this.cMusik.Checked = true;
                }
                else
                {
                    this.cMusik.Checked = false;
                }
                if (Speicher.MusicFlag)
                {
                    this.Globale_Musik.Checked = true;
                }
                else
                {
                    this.Globale_Musik.Checked = false;
                }
                this.lScore.Text = "Ihr Score liegt bei " + this.punkte.ToString();
                this.schwierigkeit = Speicher.Schwierigkeit;
                this.schiff = Speicher.Schiff;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Das Pause Menü konnte leider nicht geladen werden. Beschädigte Spieldatei. Bitte staten sie das Spiel erneut.");
            }
        }

        /// <summary>
        /// Dieses Event schaltet die Musik an und aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cMusik_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cMusik.Checked)
            {
                this.sound = true;
            }
            else
            {
                this.sound = false;
            }
        }

        /// <summary>
        /// Dieses Event setzt das Spiel fort und setzt falls nötig das Spiel zurück
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spiel_fortsetzen_Click(object sender, EventArgs e)
        {
            if (this.rbSchiff1.Checked)
            {
                Speicher.Schiff = 1;
                this.Raumschiff_zurueck();
            }
            else if (this.rbSchiff2.Checked)
            {
                Speicher.Schiff = 2;
                this.Raumschiff_zurueck();
            }
            else if (this.rbSchiff3.Checked)
            {
                Speicher.Schiff = 3;
                this.Raumschiff_zurueck();
            }
            else if (this.rbSchiff4.Checked)
            {
                Speicher.Schiff = 4;
                this.Raumschiff_zurueck();
            }
            else if (this.rbSchiff5.Checked)
            {
                Speicher.Schiff = 5;
                this.Raumschiff_zurueck();
            }
            else if (this.rbSchiff6.Checked)
            {
                Speicher.Schiff = 6;
                this.Raumschiff_zurueck();
            }
            if (this.rbLeicht.Checked)
            {
               Speicher.Schwierigkeit = 2500;
               this.Score_zuruek();
            }
            else if (this.rbNormal.Checked)
            {
                Speicher.Schwierigkeit= 2000;
                this.Score_zuruek();
            }
            else if (rbSchwer.Checked)
            {
                Speicher.Schwierigkeit = 1600;
                Score_zuruek();
            }
            else if (this.rbSehrSchwer.Checked)
            {
                Speicher.Schwierigkeit = 1200;
                this.Score_zuruek();
            }
            else if (this.rbVeteran.Checked)
            {
                Speicher.Schwierigkeit = 900;
                this.Score_zuruek();
            }
            Speicher.EndFlag = false;
            this.raumschiff.Bild();
            this.spiel.Musik(sound);
            this.Dispose(true);          
       }

        /// <summary>
        /// Dieses Event beendet das Pause Formular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Beenden_Click(object sender, EventArgs e)
        {
            Speicher.EndFlag = true;
            this.flugmanger.Zuruecksetzen();
            this.Dispose(true);
        }

        /// <summary>
        /// Diese Methode überprüft, ob die Schwierigkeit verändert wurde. Falls ja, ruft sie die Methode Zuruecksetzen der Klasse Flugmanager auf
        /// </summary>
        private void Score_zuruek()
        {
            if (Speicher.Schwierigkeit != this.schwierigkeit)
            {
                this.flugmanger.Zuruecksetzen();
                this.raumschiff.Setzen();
            }
        }
        private void Raumschiff_zurueck()
        {
            if (Speicher.Schiff != this.schiff)
            {
                this.raumschiff.Setzen();
            }
        }

        /// <summary>
        /// Dieses Event schaltet die Musik an und aus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
        /// Dieses Event öffnet die Form Spielanleitung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spielanleitung_öffnen_Click(object sender, EventArgs e)
        {
            Speicher.EndFlag = true;
            try
            {
                Spielanleitung spielanleitung = new Spielanleitung();
                spielanleitung.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Spielanleitung konnte nicht gelden werden");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pause_Activated(object sender, EventArgs e)
        {
            if (Speicher.MusicFlag)
            {
                try
                {
                    this.player.URL = @"Pause.mp3";
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pause_Deactivate(object sender, EventArgs e)
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
