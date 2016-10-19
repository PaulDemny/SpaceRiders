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
    /// 
    /// </summary>
    public partial class GameOverAnimation : Form
    {
        /// <summary>
        /// Dieser Player spielt die Hintergrundmusik ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        /// <summary>
        /// Dieser Timer schliesst das Formular, nachdem das Video beendet wurde
        /// </summary>
        private Timer timer = new Timer();
        /// <summary>
        /// erreichter Highscore, aus dem Spiel wird an das GameOVer - Formular weitergegeben
        /// </summary>
        private int highscore;
        /// <summary>
        /// Sekunden 
        /// </summary>
        private int ticks = 0;

        /// <summary>
        /// Konstruktor für das GameOverAnimation Formular
        /// </summary>
        /// <param name="score"></param>
        public GameOverAnimation(int score)
        {
            InitializeComponent();
            highscore = score;
        }

        /// <summary>
        /// Wenn GameOverAnimation aktiviert wird, wird der Hintergrundsound abgespielt und das Video gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameOverAnimation_Load(object sender, EventArgs e)
        {
            this.timer.Enabled = true;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Interval = 1000;
            if (Speicher.MusicFlag)
            {
                try
                {
                    //Der Sound wird gestartet
                    this.player.URL = @"GameOverMusik.mp3";
                    this.player.controls.play();
                }
                catch (Exception ex)
                {
                    this.player.controls.stop();
                    MessageBox.Show("Beschädigte Sounddatei oder ihr Betriebssystem ist nicht Windows!");
                    this.Dispose(true);
                }
            }
            try
            {
                //Das Video wird gestartet
                this.Animation.URL = @"GameOver.mp4";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
                this.Dispose(true);
            }

            Cursor.Hide();
        }

        /// <summary>
        /// Timerüberlaufereigniss
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.ticks++;
            //da das Video 10 Sekunden lang ist, wird nach diesr Zeit die Endsequenz geschlossen
            if (this.ticks == 11)
            {
                this.player.controls.stop();
                GameOver gameover = new GameOver(highscore);
                gameover.ShowDialog();
                this.Dispose(true);
            }
        }


        /// <summary>
        /// Mausklick schliesst das Formular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Animation_MouseDownEvent(object sender, AxWMPLib._WMPOCXEvents_MouseDownEvent e)
        {
            //linker Mausklick
            try
            {
                if (Form.MouseButtons == MouseButtons.Left)
                {
                    this.player.controls.stop();
                    GameOver gameover = new GameOver(highscore);
                    gameover.ShowDialog();
                    this.Dispose(true);
                }
                //rechter Mausklick
                if (Form.MouseButtons == MouseButtons.Right)
                {
                    this.player.controls.stop();
                    GameOver gameover = new GameOver(highscore);
                    gameover.ShowDialog();
                    this.Dispose(true);
                }
            }
            catch (Exception ex)
            {
                this.Dispose(true);
            }
        }
    }
}
