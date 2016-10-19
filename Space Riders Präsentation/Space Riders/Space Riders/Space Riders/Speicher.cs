using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Space_Riders
{
    /// <summary>
    /// Diese Klasse speichert spielübergreifend die Schwierigkeit, das Schiff, eine Flag ob global Musik gespielt wird und eine Flag die das Spiel beendet
    /// </summary>
    class Speicher
    {
        /// <summary>
        /// Der Inhalt dieser Variable legt das Aussehen und das Verhalten des Raumschiffs fest
        /// </summary>
        private static int schiff = 1;

        /// <summary>
        /// Diese Variable legt das Intervall des Timers HindernisseErzeugen im Flugmanagers fest
        /// </summary>
        private static int schwierigkeit = 2000;

        /// <summary>
        /// Diese Variable legt fest ob global Musik abgespielt wird, oder nicht
        /// </summary>
        private static bool musicflag = true;

        /// <summary>
        /// Diese Flag beendet das Spiel
        /// </summary>
        private static bool endflag = false;

        /// <summary>
        /// Rendering - Einstellung
        /// </summary>
        private static byte render = 50;

        /// <summary>
        /// Mit dieser Propertie kann auf die Variable Schiff von außerhalb zugegriffen werden
        /// </summary>
        public static int Schiff
        {
            get
            {
                return schiff;
            }
            set
            {
                schiff = value;
            }
        }

        /// <summary>
        /// Mit dieser Propertie kann auf die Variable Schwierigkeit von außerhalb zugegriffen werden
        /// </summary>
        public static int Schwierigkeit
        {
            get
            {
                return schwierigkeit;
            }
            set
            {
                schwierigkeit = value;
            }
        }
        /// <summary>
        /// Mit dieser Propertie kann auf die Variable Musiscflag von außerhalb zugegriffen werden
        /// </summary>
        public static bool MusicFlag
        {
            get
            {
                return musicflag;
            }
            set
            {
                musicflag = value;
            }
        }
        /// <summary>
        /// Mit dieser Propertie kann auf die Variable Endflag von außerhalb zugegriffen werden
        /// </summary>
        public static bool EndFlag
        {
            get
            {
                return endflag;
            }
            set
            {
                endflag = value;
            }
        }
        /// <summary>
        /// Mit dieser Propertie kann auf die Variable Schwierigkeit von außerhalb zugegriffen werden
        /// </summary>
        public static byte Render
        {
            get
            {
                return render;
            }
            set
            {
                render = value;
            }
        }
    }
}
