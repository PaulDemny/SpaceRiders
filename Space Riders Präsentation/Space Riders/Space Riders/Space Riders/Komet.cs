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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Komet fest
    /// </summary>
    public class Komet : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Kometen übergeben
        /// </summary>
        private Bitmap komet;

       /// <summary>
        /// Konstruktor für das Hindernis Komet
        /// </summary>
        /// <param name="bitmap">Bitmap des Kometen</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Kometen</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Komet(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem Komet wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da der Komet kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da der die Komet keine Munition ist, ist das Munitionsflag false 
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
                //Bild des Kometen
                this.komet = new Bitmap(Properties.Resources.Komet);
                return this.komet;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.komet = new Bitmap(273, 65);
                using (Graphics graphic = Graphics.FromImage(this.komet))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 273, 65);
                }
                return this.komet;
            }
        }
       
        /// <summary>
        /// Komet wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }

        /// <summary>
        /// Diese Methode bewegt den Kometen um den Wert von velocity von rechts nach links 
        /// </summary>
        public override void BewegenHori()
        {
            this.rectangle.X -= this.velocity;
        }

        /// <summary>
        /// Da dieses Hinderniss nur von links nach rechts bewegt wird, wird diese Methode nicht implementiert
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
