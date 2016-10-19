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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses FeindlichesSchiff fest
    /// </summary>
    public class FeindlichesSchiff : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem feindlichen Schiff übergeben
        /// </summary>
        private Bitmap feindlichesSchiff;

        /// <summary>
        /// Konstruktor für das Hindernis FeindlichesSchiff
        /// </summary>
        /// <param name="bitmap">Bitmap des feindlichen Schiffes</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des feindlischen Schiffes</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public FeindlichesSchiff(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem feindlichem Schiff wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da das feindliche Schiff kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da der das feindliche Schiff keine Munition ist, ist das Munitionsflag false 
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
                //Bild des feindlichen Schiffs
                this.feindlichesSchiff = new Bitmap(Properties.Resources.FeindlichesSchiff);
                return this.feindlichesSchiff;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.feindlichesSchiff = new Bitmap(80, 50);
                using (Graphics graphic = Graphics.FromImage(this.feindlichesSchiff))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 80, 50);
                }
                return this.feindlichesSchiff;
            }
        }

        /// <summary>
        /// Feindliches Schiff wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }
        /// <summary>
        /// Diese Methode bewegt das feindliche Schiff um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt das feindliche Schiff um den Wert von velocity von unten nach oben
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
