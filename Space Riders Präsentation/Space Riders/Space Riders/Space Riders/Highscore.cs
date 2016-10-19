using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing.Printing;
using WMPLib;

namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse beeinhaltet das Highscore Formular
    /// </summary>
    public partial class Highscore : Form
    {
        /// <summary>
        /// Dieser Soundplayer spielt die Hintergrundmusik ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// Diser string beinhaltet den Namen der Datenbak aus der gelesen bzw. geschrieben wird
        /// </summary>
        private string datenquelle = "Highscore.sqlite";

        /// <summary>
        /// Diese Instanz wird später zur Verbindung mit der Datenbank genutzt
        /// </summary>
        private SQLiteConnection verbindung = new SQLiteConnection();

        /// <summary>
        /// Dieser string beinhaltet die Schwierigkeitsstufe als Textform
        /// </summary>
        private string schwierigkeit;

        /// <summary>
        /// Konstruktor des Highscore Formulars
        /// </summary>
        public Highscore()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald das Highscore Formular geladen wird. Die Combobox auf "Alle" gesetzt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Highscore_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbHighscore.SelectedItem = "Alle";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Spieldatei, Highscore konnte nicht angezeigt werden!!!");
            }
            try
            {
                this.Cursor = new Cursor(@"Cursor1.cur");
            }
            catch (Exception ex)
            {
                this.Cursor = this.DefaultCursor;
            }
        }

        /// <summary>
        /// Dieses Event beendet das Highscore Formular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Highscore_schließen_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
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
                    MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
                }
            }
        }

        /// <summary>
        /// Diese Methode liest die Datenbank aus und schreibt die Datensätze in die Listbox
        /// </summary>
        /// <param name="commando">SQL - Abfragetext</param>
        /// <returns></returns>
        public string HighscoreLesen(string commando)
        {
            try
            {
                //Verbindung zur Datenbank welche, die Highscore beinhaltet, wird aufgebaut
                verbindung.ConnectionString = "Data Source = " + datenquelle;
                verbindung.Open();
                SQLiteCommand command = new SQLiteCommand(verbindung);
                //Kommandotext, der den Namen, den Highscore und die Schwierigkeit von Spielern aus der Datenbank ausliest, abhängig vom string commando (Einschränkung)
                command.CommandText = "Select Name, Score, Schwierigkeit from Highscore " + commando + " order by Score desc";
                command.ExecuteNonQuery();
                //Die Datenbak wird ausgelesen
                SQLiteDataReader reader = command.ExecuteReader();
                //Dieser string wird mit den Datensätzen der Datenbak gefüllt
                string erg = "";
                //Diese Variable beinhaltet die Platzierung
                int platz = 1;
                //Der Reader liest Zeile für Zeile
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        //Platzierung
                        erg += platz.ToString() + ". Platz: ";
                        //Name des Spielers
                        erg += reader.GetString(reader.GetOrdinal("Name"));
                        //Punktestand des Spielers
                        erg += ",  Score: ";
                        erg += reader.GetInt32(reader.GetOrdinal("Score"));
                        //Falls die gesamte Datenbank ausgelesen wird, wird die Schwierigkeit angezeigt, sonst nicht, da die Auswahl der Schwierigkeit vom User durch die Combobox fesetgelegt 
                        if (commando == "")
                        {
                            //Schwierigkeitsstufe
                            erg += ", Schwierigkeit: ";
                            erg += reader.GetString(reader.GetOrdinal("Schwierigkeit"));
                        }
                        //der string wird der Anzeige (Listbox) hinzugefügt
                        this.lbHighscore.Items.Add(erg);
                        //der string wird geleert, um den nächsten DAtensatz einzulesen
                        erg = "";
                        //Die Platzierung wird um eins erhöht, d.h auf den näcchst schlechteren Spieler gesetzt
                        platz++;
                    }
                //Die Verbindung zur Datenbank wird geschlossen
                verbindung.Close();
                return erg;
            }
            catch (Exception ex)
            {
                string nichts = ""; 
                MessageBox.Show("Highscore konnte nicht angezeigt werden");
                return nichts; 
            }
        }

        /// <summary>
        /// Diese Methode speichert die Elemente, welche in der Listbox angezeigt wird als .csv ab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speichern_Click(object sender, EventArgs e)
        {
            try
            {
                //Diser string beeinhaltet die Einschränkung für die SQL - Abfrage
                string bedingung = "";
                //Durch die Combobox kann die Schwierigkeitsstufe gewählt werden
                switch (this.cbHighscore.SelectedItem.ToString())
                {
                    case ("Alle"):
                        bedingung = "";
                        this.schwierigkeit = "Alle";
                        break;
                    case ("Einfach"):
                        bedingung = "where Schwierigkeit = 'Einfach'";
                        this.schwierigkeit = "Einfach";
                        break;
                    case ("Normal"):
                        bedingung = "where Schwierigkeit = 'Normal'";
                        this.schwierigkeit = "Normal";
                        break;
                    case ("Schwer"):
                        bedingung = "where Schwierigkeit = 'Schwer'";
                        this.schwierigkeit = "Schwer";
                        break;
                    case ("Sehr Schwer"):
                        bedingung = "where Schwierigkeit = 'Sehr Schwer'";
                        this.schwierigkeit = "Sehr Schwer";
                        break;
                    case ("Veteran"):
                        bedingung = "where Schwierigkeit = 'Veteran'";
                        this.schwierigkeit = "Veteran";
                        break;
                }
                //Der Dialog zum Abspeichern wird geöffnet
                SaveFileDialog save = new SaveFileDialog();
                //Die Datei wird nur als .csv abgespeichert
                save.DefaultExt = "*.csv";
                save.Filter = "CSV-Dateien (*.csv)|*.csv|Alle Dateien (*.*)|*.*";
                DialogResult dialogRes = save.ShowDialog();
                //Nun wird das Aussehen der .csv Datei festgelegt
                if (dialogRes == DialogResult.OK)
                {
                    String pfad = save.FileName;
                    FileInfo info = new FileInfo(pfad);
                    FileStream streamer = info.Open(FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                    StreamWriter writer = new StreamWriter(streamer);
                    //Verbindung zur Datenbank
                    verbindung.ConnectionString = "Data Source=" + datenquelle;
                    verbindung.Open();
                    SQLiteCommand command = new SQLiteCommand(verbindung);
                    //Kommandotext, der sich je nach ausgewähltem Index der Combobox verändert
                    command.CommandText = "Select Name, Score, Schwierigkeit from Highscore " + bedingung + " order by Score desc";
                    command.ExecuteNonQuery();
                    SQLiteDataReader reader = command.ExecuteReader();
                    int platz = 1;
                    //Die Datenbank wird ausgelesen und gleichzeitig in die .csv Datei geschrieben
                    if (reader.HasRows)
                    {
                        //Kopfzeile der .csv Datei
                        writer.WriteLine("Highscoreliste fuer Schwierigkeitstufe: " + schwierigkeit);
                        writer.WriteLine();
                        writer.WriteLine();
                        writer.Write("Plazierung;");
                        writer.Write("Spielername;");
                        if (bedingung == "")
                        {
                            writer.Write("Score;");
                            writer.WriteLine("Schwierigkeit;");
                            writer.WriteLine();
                        }
                        else
                        {
                            writer.WriteLine("Score;");
                            writer.WriteLine();
                        }
                        //Lesen und Schreiben
                        while (reader.Read())
                        {
                            writer.Write(platz.ToString() + ". Platz;");
                            writer.Write(reader.GetString(reader.GetOrdinal("Name")) + ";");
                            if (bedingung == "")
                            {
                                writer.Write(reader.GetInt32(reader.GetOrdinal("Score")) + ";");
                                writer.WriteLine(reader.GetString(reader.GetOrdinal("Schwierigkeit")) + ";");
                            }
                            else
                            {
                                writer.WriteLine(reader.GetInt32(reader.GetOrdinal("Score")) + ";");
                            }
                            platz++;
                        }
                    }
                    //Verbindung und Writer wird geschlossen
                    writer.Close();
                    verbindung.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Highscore konnte nicht abgespeichert werden");
            }
        }

        /// <summary>
        /// Dieses Event ändert die angezeigten Elemente in der Listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbHighscore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.cbHighscore.SelectedItem.ToString())
                {
                    case ("Alle"):
                        this.lbHighscore.Items.Clear();
                        this.lbHighscore.Text = HighscoreLesen("");
                        this.schwierigkeit = "Alle";
                        break;
                    case ("Einfach"):
                        this.lbHighscore.Items.Clear();
                        this.lbHighscore.Text = HighscoreLesen("where Schwierigkeit = 'Einfach'");
                        this.schwierigkeit = "Einfach";
                        break;
                    case ("Normal"):
                        this.lbHighscore.Items.Clear();
                        this.lbHighscore.Text = HighscoreLesen("where Schwierigkeit = 'Normal'");
                        this.schwierigkeit = "Normal";
                        break;
                    case ("Schwer"):
                        this.lbHighscore.Items.Clear();
                        this.lbHighscore.Text = HighscoreLesen("where Schwierigkeit = 'Schwer'");
                        this.schwierigkeit = "Schwer";
                        break;
                    case ("Sehr Schwer"):
                        this.lbHighscore.Items.Clear();
                        this.lbHighscore.Text = HighscoreLesen("where Schwierigkeit = 'Sehr Schwer'");
                        this.schwierigkeit = "Sehr Schwer";
                        break;
                    case ("Veteran"):
                        this.lbHighscore.Items.Clear();
                        this.lbHighscore.Text = HighscoreLesen("where Schwierigkeit = 'Veteran'");
                        this.schwierigkeit = "Veteran";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Spieldatei, Highscore konnte nicht angezeigt werden!!!");
            }
        }

        /// <summary>
        /// Dieses Event ruft den PrintPageEventHandler auf und öffnet eine Druckansicht der Listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Drucken_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPreviewDialog preview = new PrintPreviewDialog();
                PrintDocument document = new PrintDocument();
                preview.Document = document;
                //Es wird die Druckvorschau angezeigt
                document.PrintPage += new PrintPageEventHandler(document_PrintPage);
                preview.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Drucken ist nun nicht verfügbar. Bitte öffnen sie das Fenster erneut");
            }
        }

        /// <summary>
        /// Dieses Event legt das Aussehen der Druckansicht fest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                DateTime date = DateTime.Now;
                using (Graphics g = e.Graphics)
                {
                    Size stringSize;
                    Font arial24bold = new Font("Arial", 24, FontStyle.Bold);
                    //Space Riders Symbol 
                    stringSize = Size.Ceiling(g.MeasureString("Space Riders", arial24bold));
                    g.FillEllipse(Brushes.Gray, new Rectangle(e.MarginBounds.X - 50, e.MarginBounds.Y - 60, stringSize.Width + 30, stringSize.Height + 30));
                    g.FillEllipse(Brushes.Black, new Rectangle(e.MarginBounds.X - 52, e.MarginBounds.Y - 62, stringSize.Width + 30, stringSize.Height + 30));
                    g.DrawString("Space Riders", arial24bold, Brushes.Blue, e.MarginBounds.X - 35, e.MarginBounds.Y - 45);
                    g.DrawString("Space Riders", arial24bold, Brushes.Red, e.MarginBounds.X - 37, e.MarginBounds.Y - 47);
                    arial24bold = new Font("Arial", 12, FontStyle.Bold);
                    //Datum und Uhrzeit
                    g.DrawString(date.DayOfWeek.ToString() + ": " + date.Day.ToString() + "." + date.Month.ToString() + "." + date.Year.ToString() + ": " + date.Hour.ToString() + ":" + date.Minute.ToString(), arial24bold, Brushes.Blue, e.MarginBounds.X + 400, e.MarginBounds.Y - 70);
                    arial24bold = new Font("Arial", 12, FontStyle.Underline);
                    //SChwierigkeitsstufe
                    g.DrawString("Highscoreliste für Schwierigkeitstufe: " + schwierigkeit, arial24bold, Brushes.Green, e.MarginBounds.X - 60, e.MarginBounds.Y + 50);
                    int x = e.MarginBounds.X - 60;
                    int y = e.MarginBounds.Y + 90;
                    arial24bold = new Font("Arial", 8, FontStyle.Regular);
                    //Umrandung
                    g.DrawRectangle(Pens.Black, 10, 10, e.PageBounds.Width - 20, e.PageBounds.Height - 20);
                    g.DrawRectangle(Pens.Black, 15, 15, e.PageBounds.Width - 30, e.PageBounds.Height - 30);
                    //Platzierung, Name, Highscore und bedingt auch die Schwierigkeitsstufe  in zwei Spalten
                    foreach (string str in lbHighscore.Items)
                    {
                        g.DrawString(str, arial24bold, Brushes.Black, x, y);
                        //Unteresende der Spalten
                        if (y >= e.MarginBounds.Y + 950)
                        {
                            //Wenn linke Spalte voll ist, wird rechte Spalte befüllt
                            if (x == e.MarginBounds.X - 60)
                            {
                                x = e.MarginBounds.X + 350;
                                y = e.MarginBounds.Y + 90;
                            }
                            //Wenn beide Spalten voll sind, wird abgebrochen
                            else
                            {
                                break;
                            }
                            //Abstand zwischen zwei Plätzen
                        }
                        else
                        {
                            y += 15;
                        }
                    }
                    arial24bold = new Font("Arial", 7, FontStyle.Italic);
                    //Fußzeile
                    g.DrawString("Space Rides, designed by Liebhardt - Pfetsch - Demny Entertainment.Ltd", arial24bold, Brushes.Red, e.MarginBounds.X - 60, e.MarginBounds.Y + 1010);
                    g.DrawString("Programmierer: Christian Liebhardt, Tobias Pfetsch, Paul Demny, Version: Mark 3, 2016, Powered by Hochschule Ulm", arial24bold, Brushes.Red, e.MarginBounds.X - 60, e.MarginBounds.Y + 1030);
                    arial24bold.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Drucken ist nun nicht verfügbar. Bitte öffnen sie das Fenster erneut");
                this.Dispose(true);
            }
        }  
        
        /// <summary>
        /// Wenn Highscore zur aktiven Form wird, wird die Hintergrundmusik gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Highscore_Activated(object sender, EventArgs e)
        {
            //Wenn globale Musik aktiviert ist, wird der Hintergrundsound abgespielt
            if (Speicher.MusicFlag)
            {
                try
                {
                    this.player.URL = @"Highscore.mp3";
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
        /// Wenn Highscore inaktiv wird, wird der Mediaplayer gestoppt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Highscore_Deactivate(object sender, EventArgs e)
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
