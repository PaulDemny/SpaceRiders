using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse legt das Aussehen und das Verhalten eines Hindernisses fest
    /// </summary>
    public abstract class Hindernisse : Flugkoerper
    {
       /// <summary>
        /// Konstruktor für ein Hindernis
        /// </summary>
        /// <param name="bitmap">Das Bitmap des jeweiligen Hindernisses</param>
        /// <param name="rectangle">Das umarandende REchteck des Hindernisses</param>
        /// <param name="velocity">Die geschwindigkeit des Hindernisses</param>
        /// <param name="schildflag">An dieser Flag kann in der Kollisssionanalyse ein Schild erkannt werden</param>
        /// <param name="munitionsflag">An dieser Flag kann in der Kollisssionanalyse Munition erkannt werden</param>
        public Hindernisse(Bitmap bitmap, Rectangle rectangle, int velocity, bool schildflag, bool munitionsflag)
            : base(bitmap, rectangle, velocity, schildflag, munitionsflag)
        {
            this.velocity = velocity;
        }
    }
}
