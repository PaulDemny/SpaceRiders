using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using WMPLib;
using System.Windows.Forms;
using System.Threading;
using AxWMPLib;

namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse beinhaltet das eigentliche Spiel
    /// </summary>
    public partial class Spiel : Form
    {
        /// <summary>
        /// Dieser Soundplayer spielt die Hintergrundmusik 
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary> 
        /// Es wird eine Instanz der Klasse Flugmanager erstellt
        /// </summary>
        private Flugmanager manager = new Flugmanager();

        /// <summary>
        /// Dieser Timer bestimmt das Intervall, mit das Panel neu gezeichnet wird
        /// </summary>
        private System.Windows.Forms.Timer zeichneAufPanel = new System.Windows.Forms.Timer();

        /// <summary>
        /// Dieser Timer bestimmt wie oft auf Kolission geprüft 
        /// </summary>
        private System.Windows.Forms.Timer kollisionpruefung = new System.Windows.Forms.Timer();

        private System.Windows.Forms.Timer schusspruefung = new System.Windows.Forms.Timer();
        /// <summary>
        /// Diese Flag steuert den Sound im Spiel
        /// </summary>
        private static bool musik = true;

        /// <summary>
        /// Diese Variable verhindert das die Meldung für neue Schiffe mehrmals aufgerufen wird
        /// </summary>
        private static byte wache = 10;

        /// <summary>
        /// Dieser Backgroundworker führt in einem anderen Tread die Kollisionsüberprüfung aus
        /// </summary>
        private BackgroundWorker kollission = new BackgroundWorker();

        /// <summary>
        /// Dieser Backgroundworker führt in einem anderen Tread die Kollisionsüberprüfung mit einem Schuss aus
        /// </summary>
        private BackgroundWorker impakt = new BackgroundWorker();

        /// <summary>
        /// Diese Flag verhindert dauerfeuer
        /// </summary>
        private bool schusskontrolle = true;

        /// <summary>
        /// Dieser Timer definiert die Pausenzeit bei SChussabgabe
        /// </summary>
        private System.Windows.Forms.Timer kontrolle = new System.Windows.Forms.Timer();

        /// <summary>
        /// Dieser Delegat wird vom Backgroundworker kollission aufgerufen und ermöglich es das GameOver - Formular über den Hintergrundthread aufzurufen
        /// </summary>
        private delegate void Fertig();

        /// <summary>
        /// zählt auf 10 Sekunden und räumt dann die Spielfläche
        /// </summary>
        private byte raeumen = 0;
        /// <summary>
        /// Propertie um auf Variable Wache von außen zuzugreifen
        /// </summary>
        public static byte Wache 
        {
            get { return wache; }
            set { wache = value; }
        }

        /// <summary>
        /// Konstruktor des Spiel Formulars
        /// </summary>
        public Spiel()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald das Highscore Pause geladen wird. Der Soundplayer wird gestartet, das Timerintervall festgelegt, die Spielfläche festgelegt und die Start - Methode des Flugmanagers aufgerufen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spiel_Load(object sender, EventArgs e)
        {
            try
            {
                //Panel wird auf Desktopgröße festgelegt
                this.pSpielflaeche.Width = this.ClientRectangle.Width;
                this.pSpielflaeche.Height = this.ClientRectangle.Height;

                //Ausgabe Panel wird auf die Größe der Form eingestellt
                this.manager.PanelGroeßeFestlegen(this.pSpielflaeche.Width, this.pSpielflaeche.Height);
                //Manager Start() wird ausgefüht und die Standardwerte gesetzt
                this.manager.Start();

                //Timer der die Hindernisse zeichnet wird eingestellt
                this.zeichneAufPanel.Enabled = true;
                this.zeichneAufPanel.Interval = Speicher.Render;
                this.zeichneAufPanel.Tick += new EventHandler(this.zeichneAufPanel_Tick);
                this.zeichneAufPanel.Start();

                this.kontrolle.Enabled = true;
                this.kontrolle.Interval = 2000;
                this.kontrolle.Tick += new EventHandler(kontrolle_Tick);
 
                //Timer der Kollisionen überprüft wird eingestellt
                this.kollisionpruefung.Enabled = true;
                this.kollisionpruefung.Interval = 100;
                this.kollisionpruefung.Tick += new EventHandler(this.kollisionpruefung_Tick);
                this.kollisionpruefung.Start();

                //Timer für Pausenzeiten, um Dauerfeuer zu verhindern
                this.schusspruefung.Enabled = true;
                this.schusspruefung.Interval = 50;
                this.schusspruefung.Tick += new EventHandler(schusspruefung_Tick);
                       
                //Backgroundworker, der Kollissionsprüfung ausführt
                this.kollission.DoWork += new DoWorkEventHandler(kollission_DoWork);
                this.kollission.WorkerSupportsCancellation = true;

                //Backgroundworker, der Kollissionsprüfung mit Schüssen ausführt
                this.impakt.DoWork +=new DoWorkEventHandler(impakt_DoWork);
                this.impakt.WorkerSupportsCancellation = true;                
            }
            catch (Exception ex)
            {
                //Falls das Spiel nicht geladen werden kann
                MessageBox.Show("Das Spiel konnte leider nicht geladen werden");
                this.Dispose(true);
            }
            try
            {
                //Ein Crosshair Cursor wird festgelegt
                this.Cursor = new Cursor(@"Cursor2.cur");
            }
            catch (Exception ex)
            {
                //Falls die Cursordatei nicht gefunden weden konnte, wird der normale Cursor gewählt
                this.Cursor = this.DefaultCursor;
            }
        }

        /// <summary>
        /// Dieses Event zeichnet alle Objekte auf die Spielfläche und überprüft Kollisionen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void zeichneAufPanel_Tick(object sender, EventArgs e)
        {
            try
            {
                //Ein Graphicsobjekt wird erstellt, das später wieder gelöscht wird
                using (Graphics grafics = pSpielflaeche.CreateGraphics())
                {
                    //Font zum einstellen der Schrift, der später wieder gelöscht wird
                    using (Font arial25Bold = new Font("Arial", 25, FontStyle.Bold))
                    {
                        //Eine Liste wird erzeugt; die der Liste Hindernisse im Flugmangager entspricht, welche die Hindernisse enthält, die horizontal bewegt werden
                        List<Flugkoerper> objekte_hori = manager.HindernisseHori;
                        //Eine Liste wird erzeugt; die der Liste Hindernisse im Flugmangager entspricht, welche die Hindernisse enthält, die horizontal vertikal werden
                        List<Flugkoerper> objekte_vert = manager.HindernisseVert;

                        List<Flugkoerper> schuesse = manager.Schuss;

                        //Ein raumschiff wird erzeugt
                        Raumschiff schiff = manager.Raumschiff;

                        //Ein Rechteck überzeichnet das Bild des Raumschiffs aus dem vorigen Zyklus
                        grafics.FillRectangle(Brushes.Black, schiff.Rectangle.X - 80, schiff.Rectangle.Y - 80, 240, 190);
                        //Das Raumschiff wird auf das Panel gezeichnet
                        grafics.DrawImageUnscaledAndClipped(schiff.Bitmap, schiff.Rectangle);

                        //Jedes Objekt der Liste der horizontalen Hindernisse wird gezeichnet
                        for (int i = 0; i < objekte_hori.Count(); i++)
                        {
                            //Ein Rechteck überzeichnet das Bild für jedes Hindernis aus dem vorigen Zyklus
                            grafics.FillRectangle(Brushes.Black, objekte_hori[i].Rectangle.X + objekte_hori[i].Rectangle.Width, objekte_hori[i].Rectangle.Y, objekte_hori[i].Velocity, objekte_hori[i].Rectangle.Height);
                            //Jedes Hinderniss wird auf das Panel gezeichnet  
                            grafics.DrawImageUnscaledAndClipped(objekte_hori[i].Bitmap, objekte_hori[i].Rectangle);
                        }

                        //Falls die Schwierigkeit "Schwer" oder höher ist, gibt es auch vertikale Hindernisse 
                        //Jedes Objekt der Liste der vertikalen Hindernisse wird gezeichnet
                        for (int i = 0; i < objekte_vert.Count(); i++)
                        {
                            //Ein Rechteck überzeichnet das Bild für jedes Hindernis aus dem vorigen Zyklus
                            grafics.FillRectangle(Brushes.Black, objekte_vert[i].Rectangle.X, objekte_vert[i].Rectangle.Y + objekte_vert[i].Rectangle.Height, objekte_vert[i].Rectangle.Width, objekte_vert[i].Velocity);
                            //Jedes Hinderniss wird auf das Panel gezeichnet
                            grafics.DrawImageUnscaledAndClipped(objekte_vert[i].Bitmap, objekte_vert[i].Rectangle);                                    
                        }

                        //Zeichnet die SChüsse auf die Spielfläche
                        for (int i = 0; i < schuesse.Count(); i++)
                        {
                            grafics.FillRectangle(Brushes.Black, schuesse[i].Rectangle.X - 25, schuesse[i].Rectangle.Y, 10, 5); 
                            grafics.DrawImageUnscaledAndClipped(schuesse[i].Bitmap, schuesse[i].Rectangle);
                        }
                        //Highscore wird auf Panel gezeichnet
                        grafics.FillRectangle(Brushes.Black, 110, 0, 110, 33);
                        grafics.DrawString("Score: " + this.manager.Score.ToString(), arial25Bold, Brushes.Red, 0, 0);
                        grafics.FillRectangle(Brushes.Black, 320, 0, 80, 33);
                        grafics.DrawString("Level: " + this.manager.Level, arial25Bold, Brushes.Red, 220, 0);
                        //Wenn das Level höher als neun ist, werden auch Schilder als Hindernisse eingeflogen
                        if (this.manager.Level >= 10)
                        {
                            //Zeigt die Anzahl der gesammelten Schilder an
                            grafics.FillRectangle(Brushes.Black, 640, 0, 100, 33);
                            grafics.DrawString("Schildkristalle: " + this.manager.Kristalle.ToString(), arial25Bold, Brushes.Red, 400, 0);
                        }

                        //Wenn das ausgewählte Schiff mindestens in der Stufe zwei ist
                        if (Speicher.Schiff > 3)
                        {
                            //Zeigt an ob das Schild aktiviert ist oder nicht
                            grafics.FillRectangle(Brushes.Black, 870, 0, 180, 33);
                            grafics.DrawString("Schild: " + this.manager.SchildStatus(), arial25Bold, Brushes.Red, 750, 0);
                            grafics.FillRectangle(Brushes.Black, 1255, 0, 90, 33);
                            grafics.DrawString("Munition: " + this.manager.Munition.ToString(), arial25Bold, Brushes.Red, 1100, 0);
                        }

                        //Wenn das Schiff auf Stufe drei ist
                        if (Speicher.Schiff == 6)
                        {
                            //Zeigt an, wie of gebeamt werden kann
                            grafics.FillRectangle(Brushes.Black, 1580, 0, 75, 33);
                            grafics.DrawString("Beamkristalle: " + this.manager.Beams.ToString(), arial25Bold, Brushes.Red, 1350, 0);
                            grafics.FillRectangle(Brushes.Black, 1800, 0, 90, 33);
                            grafics.DrawString("Bomben: " +this.manager.Bomben.ToString(), arial25Bold, Brushes.Red, 1650, 0);
                        }
                        grafics.DrawLine(Pens.Red, 0, 35, this.pSpielflaeche.Width, 35);
                        this.Achtung();

                        //Diese Flag beendet das Spiel oder lässt es laufen
                        if (Speicher.EndFlag)
                        {
                            Speicher.Schwierigkeit = 2000;
                            Speicher.Schiff = 1;
                            Speicher.EndFlag = false;
                            MessageBox.Show("Das Spiel wird nun beendet!!!");
                            this.Dispose(true);
                        }
                        //Bewegt die Hindernisse
                        this.manager.HindernisseBewegen();
                        this.raeumen++;
                        if (this.raeumen == 200)
                        {
                            this.raeumen = 0;
                            grafics.FillRectangle(Brushes.Black, 0, 35, this.ClientRectangle.Width, this.ClientRectangle.Height);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Falls das Spiel gar nicht funktioniert, wird es sofort geschlossen 
                MessageBox.Show("Gravierender Spielfehler. Das Spiel muss leider geschlossen werden!");
                this.Dispose(true);
            }
        }

        /// <summary>
        /// Dieser Timer führt in einem bestimmten Intervall die Kollisionsprüfung durch 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void kollisionpruefung_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.kollission.IsBusy)
                {
                    this.kollission.RunWorkerAsync();
                }
            }
            catch
            {
                bool erg = this.manager.PruefeKolission();
                if (erg)
                {
                    this.Beenden();
                }
            }
        }
        /// <summary>
        /// Dieser Timereventhandler startet den Hintergrundthread zur Schussüberprüfung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void schusspruefung_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!this.impakt.IsBusy)
                {
                    this.impakt.RunWorkerAsync();
                }
            }
            catch
            {
                this.manager.Treffer();
            }
        }

        /// <summary>
        ///  Dieser Timereventhandler ermöglich nach seinem Ablauf das Abgeben eines Schusses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void kontrolle_Tick(object sender, EventArgs e)
        {
            this.schusskontrolle = true;
        }

        /// <summary>
        /// Schussüberprüfung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void impakt_DoWork(object sender, DoWorkEventArgs e)
        {
            this.manager.Treffer();
        }
        
        /// <summary>
        /// Kollissionprüfung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void kollission_DoWork(object sender, DoWorkEventArgs e)
        {
                bool erg = this.manager.PruefeKolission();
                if (erg)
                {   
                    Fertig f = new Fertig(Beenden);
                    this.Invoke(f);
                }
        }
        
        /// <summary>
        /// Diese Event ruft je nach Tastendruck verschiedenen Methoden auf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spiel_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.S) | (e.KeyCode == Keys.Down))
            {
                this.manager.RaumschiffAB();
            }

            else if ((e.KeyCode == Keys.W) | (e.KeyCode == Keys.Up))
            {
                this.manager.RaumschiffAUF();
            }

            else if ((e.KeyCode == Keys.A) | (e.KeyCode == Keys.Left))
            {
                this.manager.RaumschiffLinks();
            }  
        
            else if ((e.KeyCode == Keys.D) | (e.KeyCode == Keys.Right))
            {
                this.manager.RaumschiffRechts();
            }

            else if ( e.KeyCode == Keys.F)
            {
                this.manager.Schildaktivieren(); 
            }

            else if (e.KeyCode == Keys.C)
            {
                if (schusskontrolle)
                {
                    this.manager.Schießen();
                    this.schusskontrolle = false;
                    this.kontrolle.Start();
                }
            }

            else if (e.KeyCode == Keys.Escape)
            {
                Speicher.Schiff = 1;
                Speicher.Schwierigkeit = 2000;
                MessageBox.Show("Das Spiel wird nun beendet!!!");
                this.Dispose(true);
            }

            else if (e.KeyCode == Keys.Space)
            {
                //Das Spiel wird pausiert und das Pause Menü aufgerufen
                Raumschiff schiff2 = this.manager.Raumschiff;
                using (Graphics grafics = this.pSpielflaeche.CreateGraphics())
                {
                    grafics.FillRectangle(Brushes.Black, this.pSpielflaeche.ClientRectangle);
                }
                schiff2 = null;
                Pause Pause = new Pause(this.manager.Score, this.manager.Level, this.manager.Raumschiff, musik, manager);
                Pause.ShowDialog(this);       
            }

            else if (e.KeyCode == Keys.R)
            {
                Raumschiff schiff = this.manager.Raumschiff;
                Rectangle bomb = new Rectangle(schiff.Rectangle.X - 660, schiff.Rectangle.Y - 387, 1400, 800);
                this.manager.Krater(bomb);
                schiff = null;
            }
        }

        /// <summary>
        /// Diese Methode gibt Meldung wenn eine neue Schiffsklasse verfügbar ist
        /// </summary>
        private void Achtung()
        {
            //Eine Meldung für eine neue Schiffsklasse
            if (this.manager.Level == wache)
            {
                if (wache == 10)
                {
                    wache = 15;
                }
                else
                {
                    wache = 10;
                }
                this.manager.HindernisseErzeugen.Stop();
                this.zeichneAufPanel.Stop();
                this.schusspruefung.Stop();
                this.kollisionpruefung.Stop();
                MessageBox.Show("Eine neue Schiffsgeneration ist verfügbar");
                this.manager.HindernisseErzeugen.Start();
                this.zeichneAufPanel.Start();
                this.schusspruefung.Start();
                this.kollisionpruefung.Start();
            }
        }

        /// <summary>
        /// Diese Methode beendet das Spiel
        /// </summary>
        public void Beenden()
        {
            this.zeichneAufPanel.Stop();
            this.kollisionpruefung.Stop();
            this.kontrolle.Stop();
            this.schusspruefung.Stop();
            this.manager.HindernisseErzeugen.Stop();
            this.kollission.CancelAsync();
            this.impakt.CancelAsync();
            Speicher.Schwierigkeit = 2000;
            Speicher.Schiff = 1;
            GameOverAnimation gameover = new GameOverAnimation(manager.Score);
            gameover.ShowDialog(this);
            this.Dispose(true);
            
        }
      
        /// <summary>
        /// Wird ausgeführt, wenn das Spiel aktiviert ist. Timer und Musik wird gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spiel_Activated(object sender, EventArgs e)
        {
            //Timer werden gestoppt
            this.zeichneAufPanel.Start();
            this.kollisionpruefung.Start();
            this.schusspruefung.Start();
            this.schusspruefung.Start();
            this.manager.HindernisseErzeugen.Start();
            
            //Musik wird gestartet, falls globale Musik aktiviert ist
            if (Speicher.MusicFlag)
            {
                //Musik wird gestartet, falls Spielmusik aktiviert ist
                if (musik)
                {
                    try
                    {
                        this.player.URL = @"Spiel.mp3";
                        this.player.settings.setMode("Loop", true);
                        this.player.controls.play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                    }
                }
            }
        }

        /// <summary>
        /// Diese Methode übernimmt das Spielmusikflag aus dem Pause - Menü
        /// </summary>
        /// <param name="flag"></param>
        public void Musik(bool flag)
        {
            musik = flag;
        }

        /// <summary>
        /// Wird ausgeführt, wenn das Spiel deaktiviert ist. Timer und Musik wird gestoppt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spiel_Deactivate(object sender, EventArgs e)
        {
            this.zeichneAufPanel.Stop();
            this.kollisionpruefung.Stop();
            this.kontrolle.Stop();
            this.schusspruefung.Stop();
            this.manager.HindernisseErzeugen.Stop();
            this.kollission.CancelAsync();
            this.impakt.CancelAsync();
            try
            {
                this.player.controls.stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
            }
        }

        /// <summary>
        /// Diese Event wird beim Mausdruck ausgelöst und ruft die Beam - Methode das Flugmanagers auf
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pSpielflaeche_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Übermalt das alte Raumschiff
                Raumschiff schiff2 = this.manager.Raumschiff;
                using (Graphics grafics = pSpielflaeche.CreateGraphics())
                {
                    grafics.FillRectangle(Brushes.Black, schiff2.Rectangle);
                }
                schiff2 = null;
                //Weißt dem Raumschiff einen neuen Punkt zu
                this.manager.Beam(e.Location.X, e.Location.Y);
            }
        }
    }
}
