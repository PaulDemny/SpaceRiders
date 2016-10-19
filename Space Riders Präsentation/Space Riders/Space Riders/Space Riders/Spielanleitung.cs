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
    /// Diese Klasse beeinhaltet das Spielanleitung Formular
    /// </summary>
    public partial class Spielanleitung : Form
    {
        /// <summary>
        /// Dieser Player spielt die Hintergrundmusik ab
        /// </summary>
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        /// <summary>
        /// Konstruktor des Spielanleitung Formulars
        /// </summary>
        public Spielanleitung()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dieses Event beendet das Optionen Formular
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Anleitung_schließen_Click(object sender, EventArgs e)
        {
            if (Speicher.EndFlag)
            {
                Speicher.EndFlag = false;
            }
            this.Dispose(true);
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald die Eingangsanimation geladen wird. Der Soundplayer wird gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spielanleitung_Load(object sender, EventArgs e)
        {
            Spielanleitung.ActiveForm.BackgroundImage = Properties.Resources.Spielanleitung;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spielanleitung_Activated(object sender, EventArgs e)
        {
            if (Speicher.MusicFlag)
            {
                try
                {
                    this.player.URL = @"Spielanleitung.mp3";
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
        private void Spielanleitung_Deactivate(object sender, EventArgs e)
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
