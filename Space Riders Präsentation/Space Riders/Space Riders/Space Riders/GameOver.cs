using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using WMPLib;

namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse beeinhaltet das GameOver Formular
    /// </summary>
    public partial class GameOver : Form
    {
        /// <summary>
        /// Dieser Player spielt die Hintergrundmusik ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// Diese Variable beinhaltet wenn GameOver geladen wird, den Wert des erreichten Scores im Spiel
        /// </summary>
        private int highscore;

        /// <summary>
        /// Dieser string beimhaltet die Schwierigkeitsstufe als Text
        /// </summary>
        private string schwierigkeit;

        /// <summary>
        /// Konstruktor des GameOver Formulars
        /// </summary>
        /// <param name="score">erreichter Highscore im Spiel</param>
        public GameOver(int score)
        {
            this.InitializeComponent();
            this.highscore = score;
            this.lScoreAusgabe.Text = highscore.ToString();
        }

        /// <summary>
        /// Dieses Event beendet das GameOver Formular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bBeenden_Click(object sender, EventArgs e)
        {
            Speicher.EndFlag = false;
            this.Dispose(true);
        }

        /// <summary>
        /// Dieses Event speichert den Namen, den Score, und die Schwierigkeit in die Datenbank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSpeichern_Click(object sender, EventArgs e)
        {
             try
             {
                //Dieser string beinhaltet den Namen, den der Spieler für den Highscore eingibt
                string name = tbName.Text;
                //Damit es keinen leeren Namen gibt
                if (name != "" ) 
                {
                    //Name der Datenbak, in die der Highscore gespeichert wird
                    string datenquelle = "Highscore.sqlite";
                    //Verbindung wird zur Datenbank aufgebaut
                    SQLiteConnection verbindung = new SQLiteConnection();
                    verbindung.ConnectionString = "Data Source = " + datenquelle;
                    verbindung.Open();
                    SQLiteCommand command = new SQLiteCommand(verbindung);
                    //Kommandotext, der den Namen, den Highscore und die Schwierigkeit des Spielers in die Datenbank schreibt
                    command.CommandText = "Insert Into Highscore (Name, Score, Schwierigkeit) Values ('" + name + "'," + this.highscore + ",'" + this.schwierigkeit + "')";
                    command.ExecuteNonQuery();
                    //Verbindung zur Datenbank wird geschlossen 
                    verbindung.Close();
                    this.Dispose(true);
                }
                else
                {
                    this.tbName.Text = "Name eintragen!!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ihr Score Kann leider nicht gespeichert werden");
                this.Dispose(true);
            }            
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald das GameOver Formular geladen wird. Dem string schwierigkeit abhängig von der Variable schwierigkeit der Klasse speicher zugeordnet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameOver_Load(object sender, EventArgs e)
        {
            this.panel1.BackgroundImage = Properties.Resources.GameOver;
            try
            {
                this.Cursor = new Cursor(@"Cursor1.cur");
            }
            catch (Exception ex)
            {
                this.Cursor = this.DefaultCursor;
            }
            Cursor.Show();
            //Dem string schwierigkeit wird die Schwierigkeitsstufe in Textform aus der Speicherklasse übergeben
            switch (Speicher.Schwierigkeit)
            {
                case (2500): this.schwierigkeit = "Einfach";
                    break;
                case (2000): this.schwierigkeit = "Normal";
                    break;
                case (1600): this.schwierigkeit = "Schwer";
                    break;
                case (1200): this.schwierigkeit = "Sehr Schwer";
                    break;
                case (900): this.schwierigkeit = "Veteran";
                    break;
                default: MessageBox.Show("Gehacktes Spiel oder beschädigte Spieldatei. Das Spiel wird beendet!!!");
                         Cursor.Hide();
                         Endsequenz Endsequenz = new Endsequenz();
                         Endsequenz.ShowDialog(this);
                     break;
            }
        }

        /// <summary>
        /// Wenn GameOver aktiviert wird, wird der Hintergrundsound abgespielt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameOver_Activated(object sender, EventArgs e)
        {
            //Falls globaler Sound aktiviert ist, wird der Sound gestartet
            if (Speicher.MusicFlag)
            {
                try
                {
                    this.player.URL = @"GameOver.mp3";
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
        /// Wenn das GameOver nicht mehr das aktive Steuerelemet ist, wird der Sound gestoppt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameOver_Deactivate(object sender, EventArgs e)
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
