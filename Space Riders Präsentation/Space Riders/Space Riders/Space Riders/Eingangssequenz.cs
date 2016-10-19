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
    /// Diese Klasse beeinhaltet das Video der Eingangsanimation des Spiels
    /// </summary>
    public partial class Eingangssequenz : Form
    {
        /// <summary>
        /// Dieser Timer schliesst am Ende das Video
        /// </summary>
        private Timer timer = new Timer();

        /// <summary>
        /// Dieser Zähler wird jede Sekunde um eins erhöht
        /// </summary>
        private int ticks;

        /// <summary>
        /// Konstruktor der Eingangssequenz
        /// </summary>
        public Eingangssequenz()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Dieses Event wird ausgeführt sobald die Eingangsanimation geladen wird. Der Timer , das Video und der Player wird gestartet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eingangssequenz_Load(object sender, EventArgs e)
        {
            this.timer.Interval = 1000;
            this.timer.Tick += new EventHandler(timer_Tick);
            this.timer.Enabled = true;
            this.timer.Start();
            Cursor.Hide();
            try
            {
                //Das Video wird gestartet
                this.Eingangsanimation.URL = @"Eingangsanimation.mp4";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beschädigte Videodatei oder ihr Betriebssystem ist nicht Windows!");
                this.Dispose(true);
            }
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, sobald der Timer überläuft. Die Variable ticks wird um eins erhöht und wenn sie 21 erreicht, wird die Eingangssequenz beendet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.ticks++;
            //da das Video 21 Sekunden lang ist, wird nach diesr Zeit die Eingangssequenz geschlossen
            if (this.ticks == 31)
            {
                this.Dispose(true);
            }
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, sobald die linke oder rechte Maustaste gedrückt wird. Es schließt die Eingangsanimation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eingangsanimation_MouseDownEvent(object sender, AxWMPLib._WMPOCXEvents_MouseDownEvent e)
        {
            //linker Mausklick
            try
            {
                if (Form.MouseButtons == MouseButtons.Left)
                {
                    this.Dispose(true);
                }
                //rechter Mausklick
                if (Form.MouseButtons == MouseButtons.Right)
                {
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
