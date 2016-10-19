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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Satellit fest
    /// </summary>
    public class Satellit : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Satelliten übergeben
        /// </summary>
        private Bitmap satellit;

       /// <summary>
        /// Konstruktor für das Hindernis Satellit
        /// </summary>
        /// <param name="bitmap">Bitmap des Satelliten</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Satelliten</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Satellit(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Satellit wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da der Satellit kein Schild ist, ist das Schildflag false
            this.schildflag = false;
            //Da der Satellit keine Munition ist, ist das Munitionsflag false 
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
                //Bild des Satelliten
                this.satellit = new Bitmap(Properties.Resources.Satellit);
                return this.satellit;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.satellit = new Bitmap(70, 70);
                using (Graphics graphic = Graphics.FromImage(this.satellit))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 70, 70);
                }
                return this.satellit;
            }
        }
        
        /// <summary>
        /// Satellit wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt den Satelliten um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt den Satelliten um den Wert von velocity von unten nach oben
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
