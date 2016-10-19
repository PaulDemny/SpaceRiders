using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Space_Riders
{
    /// <summary>
    /// 
    /// </summary>
    interface IModify
    {
        /// <summary>
        /// Diese Methode legt das Bitmap des Flugkoerpers fest
        /// </summary>
        /// <returns>Bild der Flugkoerpers</returns>
        Bitmap Bild();
        /// <summary>
        /// Diese Methode entfernt den Flugkoerper aus der Spielfläche
        /// </summary>
        void Setzen();
        /// <summary>
        /// Methode um einen Flugkoerper horizontal zu bewegen
        /// </summary>
        void BewegenVert();
        /// <summary>
        /// Diese Methode legt das Bitmap des Flugkoerpers fest
        /// </summary>
        void BewegenHori();
    }
}
