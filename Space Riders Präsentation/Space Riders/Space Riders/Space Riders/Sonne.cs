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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Sonne fest
    /// </summary>
    class Sonne : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jeder Sonne übergeben
        /// </summary>
        private Bitmap sonne;

        /// <summary>
        /// Konstruktor für das Hindernis Sonne
        /// </summary>
        /// <param name="bitmap">Bitmap der Sonne</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit der Sonne</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Sonne(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jeder Sonne wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da die Sonne kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da die Sonne keine Munition ist, ist das Munitionsflag false
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
                //Bild der Sonne
                this.sonne = new Bitmap(Properties.Resources.Sonne);
                return this.sonne;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.sonne = new Bitmap(800, 744);
                using (Graphics graphic = Graphics.FromImage(this.sonne))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 800, 744);
                }
                return this.sonne;
            }
        }

        /// <summary>
        /// Sonne wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            velocity = 5000;
        }
        /// <summary>
        /// Diese Methode bewegt die Sonne um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt die Sonne um den Wert von velocity von unten nach oben
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
