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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Bioschiff fest
    /// </summary>
    class Bioschiff : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Bioschiff übergeben
        /// </summary>
        private Bitmap bioschiff;

       /// <summary>
        /// Konstruktor für das Hindernis Bioschiff
       /// </summary>
        /// <param name="bitmap">Bitmap des Bioschiffs</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Bioschiffs</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Bioschiff(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Bioschiff wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da das Bioschiff kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da das Bioschiff keine Munition ist, ist das Munitionsflag false 
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
                //Bild des Bioschiffs
                this.bioschiff = new Bitmap(Properties.Resources.Bioschiff);
                return this.bioschiff;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.bioschiff = new Bitmap(150, 150);
                using (Graphics graphic = Graphics.FromImage(this.bioschiff))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 150, 150);
                }
                return this.bioschiff;
            }
        }

        /// <summary>
        /// Bioschiff wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }
        /// <summary>
        /// Diese Methode bewegt das Bioschiff um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt das Bioschiff um den Wert von velocity von unten nach oben
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
        ///  Methode zur Löschung von Ressourcen
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
