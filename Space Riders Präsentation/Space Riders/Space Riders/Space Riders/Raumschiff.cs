using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse legt das Aussehen und das Verhalten des Raumschiff fest
    /// </summary>
    public class Raumschiff : Flugkoerper
    {
        /// <summary>
        /// Dieses Bitmap wird jedem Raumschiff übergeben
        /// </summary>
        protected Bitmap raumschiff;

        /// <summary>
        /// Dieses Rechteck wird jedem Raumschiff übergeben
        /// </summary>
        protected Rectangle rec;

        /// <summary>
        /// Konstruktor für das Raumschiff
        /// </summary>
        /// <param name="bitmap">Bitmap des Raumschiffs</param>
        /// <param name="rectangle">Rechteck in das das Bitmap eingefügt wird</param>
        /// <param name="velocity">Geschwindigkeit des Raumschiffs</param>
        /// <param name="schildflag">Boolsches Flag zur Erkennung eines Schildes, false</param>
        /// <param name="munitionsflag">Boolsches Flag zur Erkennung von Munition, false</param>
        public Raumschiff(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            //Da das Raumschiff kein Schild ist, ist das Schildflag false
            this.schildflag = false;
            //Jedem Raumschiff wird das Bitmap über die Methode Bild() festgelegt
            this.bitmap = bitmap;
            //Da das Raumschiff keine Munition ist, ist das Munitionsflag false 
            this.munitionsflag = false;
        }

        /// <summary>
        /// Da das Raumschiff per Tastendruck gesetuert wird, wird diese Methode nicht implementiert
        /// </summary>
        public override void BewegenHori()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Da das Raumschiff per Tastendruck gesteuert wird, wird diese Methode nicht implementiert
        /// </summary>
        public override void BewegenVert()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Diese Methode legt das Bild des Raumschiffs fest, falls die Ressource nicht vorhanden wird, wird ein blaues Rechteck mit dem Buchstaben R angezeigt
        /// </summary>
        /// <returns></returns>
        public override Bitmap Bild()
        {
            try
            {
                //Weißt über den Wert der Variable Schiff der Klasse Speicher das Bild für das Raumschiff zu. Falls der Wert nicht behandelt wird, wurde das Spiel gehackt oder ist beschädigt
                switch (Speicher.Schiff)
                {
                    case (1): this.bitmap = Properties.Resources.Schiff1;
                        break;
                    case (2): this.bitmap = Properties.Resources.Schiff2;
                        break;
                    case (3): this.bitmap = Properties.Resources.Schiff3;
                        break;
                    case (4): this.bitmap = Properties.Resources.Schiff4;
                        break;
                    case (5): this.bitmap = Properties.Resources.Schiff5;
                        break;
                    case (6): this.bitmap = Properties.Resources.Schiff6;
                        break;
                    default: MessageBox.Show("Beschädigte Ressource oder gehackte Version. Bitte starten sie das Spiel neu");
                        break;
                }
                return this.bitmap;
            }
            catch (Exception ex)
            {
                //Blaues Rechteck mit einem roten R
                using (Font arial24bold = new Font("Arial", 10, FontStyle.Regular))
                {
                    MessageBox.Show("Beschädigte Ressource");
                    this.bitmap = new Bitmap(80, 27);
                    using (Graphics graphic = Graphics.FromImage(this.bitmap))
                    {
                        graphic.FillRectangle(Brushes.Blue, 0, 0, 80, 27);
                        graphic.DrawString("R", arial24bold, Brushes.Red, 40, 10);
                    }
                    return this.bitmap;
                }
            }
        }
       
        /// <summary>
        /// Diese Methode setzt das Raumschiff auf den Anfangspunkt
        /// </summary>
        public override void Setzen()
        {
            this.rectangle.X = 10;
            this.rectangle.Y = 600;
        }

        /// <summary>
        /// Diese Methode bewegt das Raumschiff nach oben
        /// </summary>
        public void BewegenAuf()
        {
            //Damit das Raumschiff nicht über den Rand der Spielfläche hinaus gesteuert werden kann
            if (this.rectangle.Y > 55)
            {
                this.rectangle.Y -= this.velocity;
            }
        }

        /// <summary>
        /// Diese Methode bewegt das Raumschiff nach unten
        /// </summary>
        /// <param name="sizeHeightPanel">Begrenzung der Bewegung</param>
        public void BewegenAb(int sizeHeightPanel)
        {
            //Damit das Raumschiff nicht über den Rand der Spielfläche hinaus gesteuert werden kann
            if ((this.rectangle.Y + this.rectangle.Height) < sizeHeightPanel - 5)
            {
                this.rectangle.Y += this.velocity;
            }
        }

        /// <summary>
        /// Diese Methode bewegt das Raumschiff nach links
        /// </summary>
        public void BewegenLinks()
        {
            //Die Links - Bewegung ist nur ab Schiffen der zweiten Stufe möglich
            if (Speicher.Schiff > 3)
            {
                //Damit das Raumschiff nicht über den Rand der Spielfläche hinaus gesteuert werden kann
                if (this.rectangle.X > 10)
                {
                    this.rectangle.X -= this.velocity;
                }
            }
        }

        /// <summary>
        /// Diese Methode bewegt das Raumschiff nach rechts
        /// </summary>
        /// <param name="sizeWidthPanel">Begrenzung der Bewegung</param>
        public void BewegenRechts(int sizeWidthPanel)
        {
            //Die Rechts - Bewegung ist nur ab Schiffen der zweiten Stufe möglich
            if (Speicher.Schiff > 3)
            {
                //Damit das Raumschiff nicht über den Rand der Spielfläche hinaus gesteuert werden kann
                if (this.rectangle.X + this.rectangle.Width < sizeWidthPanel - 10)
                {
                    this.rectangle.X += this.velocity;
                }
            }
        }

        /// <summary>
        /// Diese Methode setzt das Raumschiff auf die Koordinaten x, y, wenn diese in einem bestimmten Bereich liegen
        /// </summary>
        /// <param name="x">alte x Koordinate des Raumschiffs</param>
        /// <param name="y">alte y Koordinate des Raumschiffs</param>
        /// <param name="width">Begrenzung auf ie Spielfläche</param>
        /// <param name="height">Begrenzung auf die Spielfläche</param>
        /// <returns></returns>
        public bool RaumschiffBeam(int x, int y, int width, int height)
        {
            bool erg = false;
            //Beamen ist nur mit dem Schiff der Stufe 3 möglich
            if (Speicher.Schiff == 6)
            {
                //Damit das Schiff nicht in einen Bereich gebeamt werden kann, den keine Hindernisse ereichen können
                //Breite
                if (x > 10 && x < width - 90)
                {
                    //Höhe
                    if (y > 65 && y < height - 35)
                    {
                        //Zuweisung des neuen Punktes
                        this.rectangle.X = x;
                        this.rectangle.Y = y;
                        erg = true;
                    }
                }
                     
            }
            return erg;
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
