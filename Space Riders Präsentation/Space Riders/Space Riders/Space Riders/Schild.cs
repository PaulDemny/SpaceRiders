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
    /// Diese Klasse legt das Aussehen und das Verhalten des Schildes fest
    /// </summary>
    class Schild : Flugkoerper
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Schild übergeben
        /// </summary>
        private Bitmap schild;

        /// <summary>
        ///  Konstruktor für ein Schild
        /// </summary>
        /// <param name="bitmap">Bitmap des Schildes</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Schildes</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, true</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Schild(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Schild wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Um ein Schild in der Kollisionsanalyse zu erkennen ist bei einem Schild das Schildflag true
            this.schildflag = true;
            //Da die Doppelstation keine Munition ist, ist das Munitionsflag false 
            this.munitionsflag = false;
        }
       
        /// <summary>
        /// In dieser Methode wird das Bild festgelegt, falls die Ressource nicht gefunden wird, wird als Bild ein grünes Rechteck mit dem Buchstaben S angezeigt
        /// </summary>
        /// <returns></returns>
        public override Bitmap Bild()
        {
            try
            {
                //Bild des Schildkristalles
                this.schild = new Bitmap(Properties.Resources.Schild);
                return this.schild;
            }
            catch (Exception ex)
            {
                //Grünes Rechteck mit einem S
                using (Font arial24bold = new Font("Arial", 10, FontStyle.Regular))
                {
                    this.schild = new Bitmap(25, 25);
                    using (Graphics graphic = Graphics.FromImage(this.schild))
                    {
                        graphic.FillRectangle(Brushes.Green, 0, 0, 25, 25);
                        graphic.DrawString("S", arial24bold, Brushes.Blue, 10, 10);
                    }
                }
                return this.schild;
            }
        }

        /// <summary>
        /// Schild wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt das Schild um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt das Schild um den Wert von velocity von unten nach oben
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
            Dispose(true);
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
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
            }
        }
    }
}
