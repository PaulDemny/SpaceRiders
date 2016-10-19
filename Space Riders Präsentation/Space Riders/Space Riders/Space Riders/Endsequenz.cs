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
    /// Diese Klasse beeinhaltet das Video der Endanimation des Spiels
    /// </summary>
    public partial class Endsequenz : Form
    {
        /// <summary>
        /// Dieser Player spielt die Hintergrundmusik zum Video der Endanimation ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// Dieser Timer schließt das Spiel
        /// </summary>
        private Timer timer = new Timer();

        /// <summary>
        /// Dieser Zähler wird jede Sekunde um eins erhöht
        /// </summary>
        private int ticks = 0;

        /// <summary>
        /// Konstruktor der Eingangssequenz
        /// </summary>
        public Endsequenz()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, sobald der Timer überläuft. Die Variable ticks wird um eins erhöht und wenn sie 16 erreicht, wird das Spiel beendet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.ticks++;
            //da das Video 16 Sekunden lang ist, wird nach diesr Zeit die Endsequenz geschlossen
            if (this.ticks == 37)
            {
                this.player.controls.stop();
                //Programm wird beendet
                Application.Exit();
            }
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald die Endanimation geladen wird. Der Timer , das Video und der Soundplayer wird gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Endsequenz_Load(object sender, EventArgs e)
        {
            Speicher.MusicFlag = false;
            this.timer.Enabled = true;
            this.timer.Tick +=new EventHandler(timer_Tick);
            this.timer.Interval = 1000;
            this.timer.Start();

            try
            {
                //Der Sound wird gestartet
                this.player.URL = @"Endsequenz.mp3";
                this.player.controls.play();
            }

            catch (Exception ex)
            {
                this.player.controls.stop();
                MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                Application.Exit();
            }

            try
            {
                //Das Video wird gestartet
                this.Endanimation.URL = @"Endanimation.mp4";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
                Application.Exit();
            }

            Cursor.Hide();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, sobald die linke oder rechte Maustaste gedrückt wird. Es beendet das Spiel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Endanimation_MouseDownEvent(object sender, AxWMPLib._WMPOCXEvents_MouseDownEvent e)
        {
            //linker Mausklick
            if (Form.MouseButtons == MouseButtons.Left)
            {
                this.player.controls.stop();
                //Programm wird beendet
                Application.Exit();
            }
            //rechter Mausklick
            if (Form.MouseButtons == MouseButtons.Right)
            {
                this.player.controls.stop();
                //Programm wird beendet
                Application.Exit();
            }
        }
    }
}
