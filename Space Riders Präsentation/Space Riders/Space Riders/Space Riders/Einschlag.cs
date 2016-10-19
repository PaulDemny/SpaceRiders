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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Einschlag fest
    /// </summary>
    class Einschlag : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Einschlag übergeben
        /// </summary>
        private Bitmap einschlag;

       /// <summary>
        /// Konstruktor für das Hindernis Einschlag
        /// </summary>
        /// <param name="bitmap">Bitmap des Einschlags</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Einschlags</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Einschlag(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Einschlag wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da der Einschlag kein Schild ist, ist das Schildflag false
            this.schildflag = false;
            //Da der Einschlag keine Munition ist, ist das Munitionsflag false 
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
                //Bild des Einschlags
                this.einschlag = new Bitmap(Properties.Resources.Einschlag);
                return this.einschlag;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.einschlag = new Bitmap(200, 222);
                using (Graphics graphic = Graphics.FromImage(this.einschlag))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 200, 222);
                }
                return this.einschlag;
            }
        }

        /// <summary>
        /// Einschlag wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt den Einschlag um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Diese Methode bewegt den Einschlag um den Wert von velocity von unten nach oben
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
