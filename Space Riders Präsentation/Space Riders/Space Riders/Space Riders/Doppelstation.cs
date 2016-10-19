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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Doppelstation fest
    /// </summary>
    class Doppelstation : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jeder Doppelstation übergeben
        /// </summary>
        private Bitmap doppelstation;

        /// <summary>
        /// Konstruktor für das Hinderniss Doppelstation
        /// </summary>
        /// <param name="bitmap">Bitmap der Doppelstation</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit der Doppelstation</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Doppelstation(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jeder Doppelstation wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da die Doppelstation kein Schild ist, ist das Schildflag false
            this.schildflag = false;
            //Da die Doppelstation keine Munition ist, ist das Munitionsflag false 
            this.munitionsflag = false;
        }

        /// <summary>
        /// In dieser Methode wird das Bild festgelegt, falls die Ressource nicht gefunden wird, wird als Bild ein rotes Rechteck angezeigt
        /// </summary>
        /// <returns>Dieses Bitmap wird der Doppelstation zugordnet</returns>
        public override Bitmap Bild()
        {
            try
            {
                //Bild der Doppelstation
                this.doppelstation = new Bitmap(Properties.Resources.Doppelstation);
                return this.doppelstation;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.doppelstation = new Bitmap(291, 227);
                using (Graphics graphic = Graphics.FromImage(this.doppelstation))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 291, 227);
                }
                return this.doppelstation;
            }
        }
      
        /// <summary>
        /// Doppelstation wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt die Doppelstation um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt die Doppelstation um den Wert von velocity von unten nach oben
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
