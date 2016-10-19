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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Kreisschiff fest
    /// </summary>
    class Kreisschiff : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Kreisschiff übergeben
        /// </summary>
        private Bitmap kreisschiff;

        /// <summary>
        /// Konstruktor für das Hindernis Kreisschiff
        /// </summary>
        /// <param name="bitmap">Bitmap des Kreisschiffs</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Kreisschiffs</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Kreisschiff(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Kreisschiff wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da das Kreisschiff kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da das Kreisschiff keine Munition ist, ist das Munitionsflag false
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
                //Bild des Kreisschiffes
                this.kreisschiff = new Bitmap(Properties.Resources.Kreisschiff);
                return this.kreisschiff;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.kreisschiff = new Bitmap(417, 313);
                using (Graphics graphic = Graphics.FromImage(this.kreisschiff))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 417, 313);
                }
                return this.kreisschiff;
            }
        }
       
        /// <summary>
        /// Kreisschiff wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt das Kreisschiff um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt das Kreisschiff um den Wert von velocity von unten nach oben
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
