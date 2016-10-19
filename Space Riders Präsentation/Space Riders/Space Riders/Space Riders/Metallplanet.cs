using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Media;
using System.Windows.Forms;


namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Metallplanet fest
    /// </summary>
    class Metallplanet : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Metallplaneten übergeben
        /// </summary>
        private Bitmap metallplanet;

        /// <summary>
        /// Konstruktor für das Hindernis Metallplanet
        /// </summary>
        /// <param name="bitmap">Bitmap des Metallplaneten</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Metallplaneten</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Metallplanet(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Metallplaneten wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da der Metallplanet kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da der Metallplanet keine Munition ist, ist das Munitionsflag false 
            this.munitionsflag = false;
        }

        /// <summary>
        /// In dieser Methode wird das Bild festgelegt, falls die Ressource nicht gefunden wird, wird als Bild ein rotes Rechteck angezeigt
        /// </summary>
        /// <returns></returns>
        public override Bitmap Bild()
        {
            try
            {
                //Bild des Metallplaneten
                this.metallplanet = new Bitmap(Properties.Resources.Metallplanet);
                return this.metallplanet;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.metallplanet = new Bitmap(189, 189);
                using (Graphics graphic = Graphics.FromImage(this.metallplanet))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 189, 189);
                }
                return this.metallplanet;
            }
        }
       
        /// <summary>
        /// Metallplanet wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt den Metallplaneten um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt den Metallplaneten um den Wert von velocity von unten nach oben
        /// </summary>
        public override void BewegenVert()
        {
            this.rectangle.Y -= this.velocity;
        }

        /// <summary>
        /// Methode zur Löschung von Ressourcen
        /// </summary>
        public override void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Methode zur Löschung von Ressourcen
        /// </summary>
        /// <param name="disposing">Löschung von gemanagten Ressourcen</param>
        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.bitmap != null)
                {
                    this.bitmap.Dispose();
                }
            }
        }
    }
}
