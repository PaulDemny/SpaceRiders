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
    /// Diese Klasse legt das Aussehen und das Verhalten der Munition fest
    /// </summary>
    public class Munition : Flugkoerper

    {
         /// <summary>
        /// Dieses Bitmap wird jedem Schild übergeben
        /// </summary>
        private Bitmap munition;

        /// <summary>
        /// Konstruktor für die Munition
        /// </summary>
        /// <param name="bitmap">Bitmap der Munition</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit der Munition</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, true</param>
        public Munition(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jeder Munition wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da Munition kein Schild ist, ist das Schildflag false
            this.schildflag = false;
            //Munitionsflag ist true, um bei der Kollissionsanalyse die Munition zu erkennnen
            this.munitionsflag = true;
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
                this.munition = new Bitmap(Properties.Resources.Munition);
                return this.munition;
            }
            catch (Exception ex)
            {
                //Grünes Rechteck mit einem S
                using (Font arial24bold = new Font("Arial", 10, FontStyle.Regular))
                {
                    this.munition = new Bitmap(25, 25);
                    using (Graphics graphic = Graphics.FromImage(this.munition))
                    {
                        graphic.FillRectangle(Brushes.Green, 0, 0, 25, 25);
                        graphic.DrawString("M", arial24bold, Brushes.Blue, 10, 10);
                    }
                }
                return this.munition;
            }
        }

        /// <summary>
        /// Munition wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
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
