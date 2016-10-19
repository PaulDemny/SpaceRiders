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
    /// Diese Klasse legt das Aussehen und das Verhalten eines Schusses fest
    /// </summary>
    class Schuss : Flugkoerper
    {

        /// <summary>
        /// Dieses Bitmap wird jeder Schuss übergeben
        /// </summary>
        private Bitmap schuss;

        /// <summary>
        /// Diese Pinsel bestimmt die Farbe des Schusses
        /// </summary>
        SolidBrush pinsel;

        /// <summary>
        /// Konstruktor für einen Schuss
        /// </summary>
        /// <param name="bitmap">Bitmap dees Schusses</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Schusses</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Schuss(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Schuss wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da der Schuss kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da der Schuss keine Munition ist, ist das Munitionsflag false 
            this.munitionsflag = false;
        }

        /// <summary>
        /// In dieser Methode wird das Bild festgelegt
        /// </summary>
        /// <returns>Dieses Bitmap wird dem Schuss zugordnet</returns>
        public override Bitmap Bild()
        {
            this.schuss = new Bitmap(20, 10);
            //SolidBrush pinsel;
            Random rnd = new Random();
            int zufall = rnd.Next(0, 6);
            switch (zufall)
            {
                case (0): pinsel = new SolidBrush(Color.Red);
                    break;
                case (1): pinsel = new SolidBrush(Color.Blue);
                    break;
                case (2): pinsel = new SolidBrush(Color.Green);
                    break;
                case (3): pinsel = new SolidBrush(Color.Yellow);
                    break;
                case (4): pinsel = new SolidBrush(Color.White);
                    break;
                case (5): pinsel = new SolidBrush(Color.Orange);
                    break;
                default: break;
            }
            using (Graphics graphic = Graphics.FromImage(this.schuss))
            {
                graphic.FillRectangle(pinsel, 0, 0, 10, 5);
            }
            return this.schuss;
        }

        /// <summary>
        /// Schuss wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt die Doppelstation um den Wert von velocity von links nach rechts
        /// </summary>
        public override void BewegenHori()
        {
            rectangle.X += velocity;
        }

        /// <summary>
        /// Es gibt nur Schüsse in horizontaler Richtung, des wegen Methode nicht implementiert
        /// </summary>
        public override void BewegenVert()
        {
            throw new NotImplementedException();
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
