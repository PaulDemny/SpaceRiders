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
    /// Diese Klasse legt das Aussehen und das Verhalten des Hindernisses Blauer_Komet fest
    /// </summary>
    class Blauer_Komet : Hindernisse
    {
        /// <summary>
        /// Dieses Bitmap wird jedem blauen Kometen übergeben
        /// </summary>
        private Bitmap blauer_komet;

        /// <summary>
        /// Konstruktor für das Hindernis Blauer_Komet
        /// </summary>
        /// <param name="bitmap">Bitmap des Blauen Kometen</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Blauen Kometen</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Blauer_Komet(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Jedem blauem Kometen wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = this.Bild();
            //Da der blaue Komet kein Schild ist, ist das Schildflag false 
            this.schildflag = false;
            //Da der blaue Komet keine Munition ist, ist das Munitionsflag false
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
                //Bild des blauen Kometen
                this.blauer_komet = new Bitmap(Properties.Resources.Blauer_komet);
                return this.blauer_komet;
            }
            catch (Exception ex)
            {
                //Rotes Rechteck
                this.blauer_komet = new Bitmap(100, 245);
                using (Graphics graphic = Graphics.FromImage(this.blauer_komet))
                {
                    graphic.FillRectangle(Brushes.Red, 0, 0, 100, 245);
                }
                return this.blauer_komet;
            }
        }

        /// <summary>
        /// Blauer Komet wird aus der Spielfläche entfernt
        /// </summary>
        public override void Setzen()
        {
            this.velocity = 5000;
        }

        /// <summary>
        /// Da dieses Hindernis nur von unten nach oben bewegt wird, wird diese Methode nicht implementiert
        /// </summary>
        public override void BewegenHori()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Diese Methode bewegt den blauen Kometen um den Wert von velocity von unten nach oben
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
