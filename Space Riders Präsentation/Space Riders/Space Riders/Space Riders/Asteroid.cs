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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Asteroid fest
    /// </summary>
    public class Asteroid : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Asteroiden übergeben
        /// </summary>
        private Bitmap asteroid;

       /// <summary>
       /// Konstruktor für das Hindernis Asteroid
       /// </summary>
       /// <param name="bitmap">Bitmap des Asteroiden</param>
       /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
       /// <param name="velocity">Geschwindigkeit des Asteroids</param>
       /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
       /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Asteroid(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Asteroiden wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da der Asteroid kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da der Asteroid keine Munition ist, ist das Schildflag false 
            this.munitionsflag = false;
        }

        /// <summary>
        /// In dieser Methode wird das Bild festgelegt, falls die Ressource nicht gefunden wird, wird als Bild ein rotes Rechteck angezeigt
        /// </summary>
        /// <returns>Dieses Bitmap wird dem Asteroiden zugordnet</returns>
        public override Bitmap Bild()
        {
            try
            {
                //Bild des Asteroiden
                this.asteroid = new Bitmap(Properties.Resources.Asteroid);
                return this.asteroid;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.asteroid = new Bitmap(60, 60);
                using (Graphics graphic = Graphics.FromImage(this.asteroid))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 60, 60);
                }
                return this.asteroid;
            }
        }

        /// <summary>
        /// Asteroid wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }
        /// <summary>
        /// Diese Methode bewegt den Asteroiden um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt den Asteroiden um den Wert von velocity von unten nach oben
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
