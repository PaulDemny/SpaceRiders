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
    /// Diese Klasse legt das Aussehen und das Verhalten eines Flugkoerpers fest
    /// </summary>
    public abstract class Flugkoerper : IModify, IDisposable
    {
        /// <summary>
        /// Jedem Flugkoerper wird ein Bitmap zugewiesen
        /// </summary>
        protected Bitmap bitmap;

        /// <summary>
        /// Jedem Flugkoerper wird ein Rectangle zugewiesen
        /// </summary>
        protected Rectangle rectangle;

        /// <summary>
        /// Jedem Flugkoerper wird eine velocity zugewiesen
        /// </summary>
        protected int velocity;

        /// <summary>
        /// Jedem Flugkoerper wird ein schildflag zugewiesen
        /// </summary>
        protected bool schildflag;
        /// <summary>
        /// Jedem Flugkoerper wird ein munitionsflag zugewiesen
        /// </summary>
        protected bool munitionsflag;

        /// <summary>
        /// Konstruktor für einen Flugkoerper
        /// </summary>
        /// <param name="bitmap">Das Bitmap des jeweiligen Flugkoerpers</param>
        /// <param name="rectangle">Das umarandende REchteck des Flugkoerpers</param>
        /// <param name="velocity">Die geschwindigkeit des Flugkoerpers</param>
        /// <param name="schildflag">An dieser Flag kann in der Kollisssionanalyse ein Schild erkannt werden</param>
        /// <param name="munitionsflag">An dieser Flag kann in der Kollisssionanalyse Munition erkannt werden</param>
        public Flugkoerper(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
        {
            this.bitmap = bitmap;
            this.rectangle = rectangle;
            this.velocity = velocity;
            this.schildflag = schildflag;
            this.munitionsflag = munitionsflag;
        }

        /// <summary>
        /// Propertie für die Bitmap
        /// </summary>
        public Bitmap Bitmap
        {
            get { return this.bitmap; }
            set { this.bitmap = value; }
        }

        /// <summary>
        /// Propertie für das Rechteck
        /// </summary>
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
            set { this.rectangle = value; }
        }

        /// <summary>
        /// Propertie für die velocicty
        /// </summary>
        public int Velocity
        {
            get { return this.velocity; }
            set { this.velocity = value; }
        }

        /// <summary>
        /// Propertie für das schildflag
        /// </summary>
        public bool Schildflag
        {
            get { return this.schildflag; }
            set { this.schildflag = value; }
        }

        /// <summary>
        /// Propertie für das munitionsflag
        /// </summary>
        public bool Munitionsflag
        {
            get { return this.munitionsflag; }
            set { this.munitionsflag = value; }
        }

        /// <summary>
        /// Methode um einen Flugkoerper vertikal zu bewegen
        /// </summary>
        public abstract void BewegenVert();

        /// <summary>
        /// Methode um einen Flugkoerper horizontal zu bewegen
        /// </summary>
        public abstract void BewegenHori();

       /// <summary>
        /// Diese Methode legt das Bitmap des Flugkoerpers fest
       /// </summary>
       /// <returns>Bild der Flugkoerpers</returns>
        public abstract Bitmap Bild();

        /// <summary>
        /// Diese Methode entfernt den Flugkoerper aus der Spielfläche
        /// </summary>
        public abstract void Setzen();

        /// <summary>
        /// Methode zur Löschung von Ressourcen
        /// </summary>
        public abstract void Dispose();
    }
}
