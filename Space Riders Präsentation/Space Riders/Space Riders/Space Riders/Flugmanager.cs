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
    /// Die Klasse Flugmanager regelt im Hintergrund die Abläufe des Spiels
    /// </summary>
    public class Flugmanager
    {
        /// <summary>
        /// Diese Variable beinhaltet den Wert des erreichten Scores
        /// </summary>
        private int score;

        /// <summary>
        /// Diese Variable beinhaltet den Wert des erreichten Levels
        /// </summary>
        private byte level;

        /// <summary>
        /// In dieser Liste werden alle Flugkoerper gespeichert, die horizontal bewegt werden
        /// </summary>
        private List<Flugkoerper> hindernisse_hori = new List<Flugkoerper>();

        /// <summary>
        /// In dieser Liste werden alle Flugkoerper gespeichert, die vertikal bewegt werden
        /// </summary>
        private List<Flugkoerper> hindernisse_vert = new List<Flugkoerper>();
        /// <summary>
        /// In diesesr Liste werden alle Schüsse gespeichert, die der Spieler abgibt
        /// </summary>
        private List<Flugkoerper> schuss = new List<Flugkoerper>();
        /// <summary>
        /// Es wird eine Instanz der Klasse Raumschiff erzeugt
        /// </summary>
        private Raumschiff raumschiff;

        /// <summary>
        /// Diese Variable beinhaltet Breite der Spielflaeche
        /// </summary>
        private int sizeWidthPanel;

        /// <summary>
        /// Diese Variable beinhaltet Höhe der Spielflaeche
        /// </summary>
        private int sizeHeightPanel;

        /// <summary>
        /// An dieser Flag kann erkannt werden, ob ein Hindernis ein Schild ist, oder nicht
        /// </summary>
        private bool schild;

        /// <summary>
        /// Diese Variable beinhaltet den Wert der Kristalle die zur Erzeugung eines Schutzschildes nötig sind
        /// </summary>
        private byte kristalle = 100;

        /// <summary>
        /// Dieser string zeigt den Status des Schutzschildes an
        /// </summary>
        private string erg;

        /// <summary>
        /// Diese Variable beinhaltet den Wert (Beams), wie oft die Methode Beam() des Flugmanagers aufgerufen werden kann
        /// </summary>
        private byte beams = 100;

        /// <summary>
        /// Diese Flag zeigt an, ob sich das Level um 5 erhöht hat
        /// </summary>
        private bool wiederholung = true;

        /// <summary>
        /// Diese Flag zeigt an, ob sich der Score um 500 erhöht hat
        /// </summary>
        private bool scoreup = true;

        /// <summary>
        /// Anzahl der möglichen Schüsse
        /// </summary>
        private int munition = 500;

        /// <summary>
        /// Anzahl der möglichen Bombeneinsätze
        /// </summary>
        private byte bomben = 100;

        /// <summary>
        /// Dieser Timer bestimmt das Intervall, ind dem das Event hindernisseErzeugen_Tick aufgerufen wird
        /// </summary>
        private Timer hindernisseErzeugen = new Timer();

        /// <summary>
        /// Diese Methode legt die Größe der Spielfläche fest
        /// </summary>
        /// <param name="sizeWidthPanel">Breite der Spielfläche</param>
        /// <param name="sizeHeightPanel">Höhe der Spielfläche</param>
        public void PanelGroeßeFestlegen(int sizeWidthPanel, int sizeHeightPanel)
        {
            this.sizeWidthPanel = sizeWidthPanel;
            this.sizeHeightPanel = sizeHeightPanel;
        }
        /// <summary>
        /// Propertie um auf die Liste HindernisseHori zuzugreifen
        /// </summary>
        public List<Flugkoerper> HindernisseHori
        {
            get { return this.hindernisse_hori; }
        }

        /// <summary>
        /// Propertie um auf die Liste HindernisseVert zuzugreifen
        /// </summary>
        public List<Flugkoerper> HindernisseVert
        {
            get { return this.hindernisse_vert; }
        }
        /// <summary>
        /// 
        /// </summary>
        public List<Flugkoerper> Schuss
        {
            get { return this.schuss; }
        }
        /// <summary>
        /// Propertie um auf Raumschiff zuzugreifen
        /// </summary>
        public Raumschiff Raumschiff
        {
            get { return this.raumschiff; }
        }

        /// <summary>
        /// Propertie um auf Score zuzugreifen
        /// </summary>
        public int Score
        {
            get { return this.score; }
        }

        /// <summary>
        /// Propertie um auf Level zuzugreifen
        /// </summary>
        public byte Level
        {
            get { return this.level; }
        }

        /// <summary>
        /// Propertie um auf Score zuzugreifen
        /// </summary>
        public bool Schild
        {
            get { return this.schild; }
        }

        /// <summary>
        /// Propertie um auf Kristalle zuzugreifen
        /// </summary>
        public byte Kristalle
        {
            get { return this.kristalle; }
        }

        /// <summary>
        /// Propertie um auf Beams zuzugreifen
        /// </summary>
        public byte Beams
        {
            get { return this.beams; }
        }

        /// <summary>
        /// Diese Flag verhindert mehrmals aufrufen von Methoden
        /// </summary>
        public bool Wiederhohlung
        {
            get { return this.wiederholung; }
        }

        /// <summary>
        /// Propertie um auf Munition zuzugreifen
        /// </summary>
        public int Munition
        {
            get { return this.munition; }
        }
        /// <summary>
        /// Dieser Timer erstellt in jedem Intervall Hindernisse
        /// </summary>
        public Timer HindernisseErzeugen
        {
            get { return this.hindernisseErzeugen; }
            set { this.hindernisseErzeugen = value; }
        }
        /// <summary>
        /// Propertie um auf Bomben zuzugreifen
        /// </summary>
        public byte Bomben
        {
            get { return this.bomben; }
        }
        /// <summary>
        /// Dieser Timer bestimmt das Intervall, ind dem das Event hindernisseErzeugen_Tick aufgerufen wird
        /// </summary>
        public void Start()
        {
            try
            {
                //Level und Score festlegen
                this.level = 20;
                this.score = 0;

                //Timer Einstellen und Event zum auswerten des Timer wird erstellt
                this.hindernisseErzeugen.Enabled = true;
                this.hindernisseErzeugen.Interval = Speicher.Schwierigkeit;
                this.hindernisseErzeugen.Tick += new EventHandler(this.hindernisseErzeugen_Tick);
                this.hindernisseErzeugen.Start();

                //Das Anfangsraumschiff wird festgelegt
                this.emptyRectangle.Height = 27;
                this.emptyRectangle.Width = 80;
                this.raumschiff = new Raumschiff(this.emptyBitmap, this.emptyRectangle, this.velocityRaumschiff, this.flag, this.flag);
                this.raumschiff.Bild();
                this.raumschiff.Setzen();
            }
            catch
            {
                MessageBox.Show("Das Spiel kann leider nicht gestartet werden. Versuchen sie einen Neustart!");
            }
        }
        /// <summary>
        /// Ein Objekt vom Typ Zufall wird erzeugt um später zufällige Koordinaten zu erzeugen
        /// </summary>
        private Random rnd = new Random();

        /// <summary>
        /// Diese Bitmap wird später allen Flugkoerpern zugewiesen
        /// </summary>
        private Bitmap emptyBitmap = new Bitmap(1, 1);

        /// <summary>
        /// Diese Flag zeigt an, wie oft die Methoden HindernisseVertList() und HindernisseHoriList() aufgerufen werden
        /// </summary>
        private byte bedingung = 0;

        /// <summary>
        /// Dieses Rectangle wird später allen Flugkoerpern zugewiesen
        /// </summary>
        private Rectangle emptyRectangle = new Rectangle();

        /// <summary>
        /// Anfangsgeschwindigkeit des Asteroids
        /// </summary>
        private int velocityAsteroid = 7;

        /// <summary>
        /// Anfangsgeschwindigkeit des Satellits
        /// </summary>
        private int velocitySatellit = 8;

        /// <summary>
        /// Anfangsgeschwindigkeit des feindlichen Schiffs
        /// </summary>
        private int velocityFeindlichesSchiff = 10;

        /// <summary>
        /// Anfangsgeschwindigkeit des Komets
        /// </summary>
        private int velocityKomet = 100;

        /// <summary>
        /// Anfangsgeschwindigkeit des blauen Komets
        /// </summary>
        private int velocityBlauer_Komet = 100;

        /// <summary>
        /// Anfangsgeschwindigkeit des Raumschiffs
        /// </summary>
        private int velocityRaumschiff = 15;

        /// <summary>
        /// Anfangsgeschwindigkeit des Schilds
        /// </summary>
        private int velocitySchild = 20;

        /// <summary>
        /// Anfagsgeschwindigkeit der Munition
        /// </summary>
        private int velocityMunition = 20;

        /// <summary>
        /// Anfangsgeschwindigkeit des Bioschiffs
        /// </summary>
        private int velocityBioschiff = 9;

        /// <summary>
        /// Anfangsgeschwindigkeit des Metallplanets
        /// </summary>
        private int velocityMetallplanet = 6;

        /// <summary>
        /// Anfangsgeschwindigkeit der Skelettstation
        /// </summary>
        private int velocitySkelettstation = 12;

        /// <summary>
        /// Anfangsgeschwindigkeit der Doppelstation
        /// </summary>
        private int velocityDoppelstation = 8;

        /// <summary>
        /// Anfangsgeschwindigkeit des Einschlags
        /// </summary>
        private int velocityEinschlag = 13;

        /// <summary>
        /// Anfangsgeschwindigkeit des Kreisschiffs
        /// </summary>
        private int velocityKreisschiff = 10;

        /// <summary>
        /// Anfangsgeschwindigkeit des Saturns
        /// </summary>
        private int velocitySaturn = 5;

        /// <summary>
        /// Anfangsgeschwindigkeit der Erde
        /// </summary>
        private int velocityErde = 30;

        /// <summary>
        /// Anfangsgeschwindigkeit der Sonne
        /// </summary>
        private int velocitySonne = 20;

        /// <summary>
        /// Anfangsgeschwindigkeit eines Schusses
        /// </summary>
        private int velocitySchuss = 25;
        /// <summary>
        /// Dieser Flag wird der logische Wert der Schildflag jedes Hindernisses zugewiesen
        /// </summary>
        private bool flag = false;

        /// <summary>
        /// Dieser Event - Handler erzeugt bei Überlauf des Timers hindernisseErzeugen die gegnerischen Flugkoerper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void hindernisseErzeugen_Tick(object sender, EventArgs e)
        {
            try
            {
                //Normaler Modus: Einfacher Aufruf: 1 horizontales Hindernis
                this.HindernisseHoriList();

                //Wenn das Level größer als neun ist werden neue Optionen offen
                if (this.level >= 10)
                {
                    //Alle fünf Level 
                    if ((this.level - 10) % 5 == 0)
                    {
                        //Wenn die Flag wiederholung true ist
                        if (this.wiederholung)
                        {
                            //bedingung wird inkrementiert
                            this.bedingung++;

                            //Da diese Schleife eigentlich meherere Zyklen ausgefürht werden würde, wird wiederhohlung bei ersten Mal sofort auf false gesetzt. So wird bedingung nur einmal erhöht
                            this.wiederholung = false;

                            //Es wird die Beamserhoehen Methode aufgerufen
                            this.BeamsMunitionBombenerhoehen();
                        }
                    }
                    //Erst wenn das Level nicht mehr ganzzalig durch fünf teilbar ist, wird wiederhohlung wieder auf true gesetzt um beim nächsten Mal wieder in die obere Schleife zu springen
                    if ((this.level - 10) % 5 == 1)
                    {
                        this.wiederholung = true;
                    }

                    //Es je nach Wert von bedingung die Methode HindernisseHoriList aufgerufen
                    for (int i = 0; i < this.bedingung; i++)
                    {
                        //this.HindernisseErstellen(hindernisse_hori, true);
                        this.HindernisseHoriList();
                    }

                    // Wenn die Schweirigkeit höher als "Normal" ist werden auch vertikale Hindernisse erzeugt
                    if (Speicher.Schwierigkeit < 1900)
                    {
                        //Aufruf der Methode
                        this.HindernisseVertList();
                        if (this.bedingung > 0)
                        {
                            //Es je nach Wert von bedingung - 1 die Methode HindernisseVertList aufgerufen
                            for (int i = 0; i < (this.bedingung - 1); i++)
                            {
                                this.HindernisseVertList();
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Diese Methode erstellt verschiedene Hindernisse, welche vertikal über die Spielflaeche bewegt werden
        /// </summary>
        private void HindernisseVertList()
        {
            try
            {
                //XPosition des Hindernisses wird auf Rechte Panelseite gesetzt
                this.emptyRectangle.X = this.rnd.Next(0, this.sizeWidthPanel - 60);
                //YPosition des Hindernisses wird zufällig erzeugt
                this.emptyRectangle.Y = this.sizeHeightPanel;
                //Zufälliges Hindernis wird ausgewählt und der Liste hinzugefügt
                //Normale Hindernisse
                byte zufall = (byte)this.rnd.Next(0, 4);
                switch (zufall)
                {
                    case (0):
                        this.emptyRectangle.Height = 60;
                        this.emptyRectangle.Width = 60;
                        this.hindernisse_vert.Add(new Asteroid(this.emptyBitmap, this.emptyRectangle, this.velocityAsteroid, this.flag, this.flag));
                        break;
                    case (1):
                        this.emptyRectangle.Height = 70;
                        this.emptyRectangle.Width = 70;
                        this.hindernisse_vert.Add(new Satellit(this.emptyBitmap, this.emptyRectangle, this.velocitySatellit, this.flag, this.flag));
                        break;
                    case (2):
                        this.emptyRectangle.Height = 50;
                        this.emptyRectangle.Width = 80;
                        this.hindernisse_vert.Add(new FeindlichesSchiff(this.emptyBitmap, this.emptyRectangle, this.velocityFeindlichesSchiff, this.flag, this.flag));
                        break;
                    case (3):
                        this.emptyRectangle.Height = 80;
                        this.emptyRectangle.Width = 103;
                        this.hindernisse_vert.Add(new Skelettstation(this.emptyBitmap, this.emptyRectangle, this.velocitySkelettstation, this.flag, this.flag));
                        break;
                    default: break;
                }

                //Größere Hindernisse
                byte mittel = (byte)this.rnd.Next(0, 51);
                switch (mittel)
                {
                    case (20):
                        this.emptyRectangle.Height = 150;
                        this.emptyRectangle.Width = 150;
                        this.hindernisse_vert.Add(new Bioschiff(this.emptyBitmap, this.emptyRectangle, this.velocityBioschiff, this.flag, this.flag));
                        break;
                    case (40):
                        this.emptyRectangle.Height = 189;
                        this.emptyRectangle.Width = 189;
                        this.hindernisse_vert.Add(new Metallplanet(this.emptyBitmap, this.emptyRectangle, this.velocityMetallplanet, this.flag, this.flag));
                        break;
                    default: break;
                }

                //Schneller Komet
                byte random = (byte)this.rnd.Next(0, 50);
                if (random == 15 || random == 25)
                {
                    this.emptyRectangle.Height = 245;
                    this.emptyRectangle.Width = 100;
                    this.hindernisse_vert.Add(new Blauer_Komet(this.emptyBitmap, this.emptyRectangle, this.velocityBlauer_Komet, this.flag, this.flag));
                }

                //Schild
                else if (random == 45 | random == 30)
                {
                    this.emptyRectangle.Height = 25;
                    this.emptyRectangle.Width = 25;
                    this.hindernisse_vert.Add(new Schild(this.emptyBitmap, this.emptyRectangle, this.velocitySchild, this.flag, this.flag));
                }
                else if (random == 0 | random == 40)
                {
                    this.emptyRectangle.Height = 30;
                    this.emptyRectangle.Width = 30;
                    this.hindernisse_vert.Add(new Munition(this.emptyBitmap, this.emptyRectangle, this.velocityMunition, this.flag, this.flag));
                }

                //Ab Level 15 kommen größere Hindernisse
                if (this.level >= 15)
                {
                    int pech = this.rnd.Next(0, 401);
                    switch (pech)
                    {
                        case (100):
                            this.emptyRectangle.Height = 227;
                            this.emptyRectangle.Width = 291;
                            this.hindernisse_vert.Add(new Doppelstation(this.emptyBitmap, this.emptyRectangle, this.velocityDoppelstation, this.flag, this.flag));
                            break;
                        case (200):
                            this.emptyRectangle.Height = 222;
                            this.emptyRectangle.Width = 200;
                            this.hindernisse_vert.Add(new Einschlag(this.emptyBitmap, this.emptyRectangle, this.velocityEinschlag, this.flag, this.flag));
                            break;
                        case (300):
                            this.emptyRectangle.Height = 313;
                            this.emptyRectangle.Width = 417;
                            this.hindernisse_vert.Add(new Kreisschiff(this.emptyBitmap, this.emptyRectangle, this.velocityKreisschiff, this.flag, this.flag));
                            break;
                        case (400):
                            this.emptyRectangle.Height = 346;
                            this.emptyRectangle.Width = 350;
                            this.hindernisse_vert.Add(new Saturn(this.emptyBitmap, this.emptyRectangle, this.velocitySaturn, this.flag, this.flag));
                            break;
                        default: break;
                    }
                }

                //Wenn die Schwierigkeit höher ist als "Schwer"
                if (Speicher.Schwierigkeit < 1500)
                {
                    //Ab Level 20
                    if (this.level >= 20)
                    {
                        //Sehr grosse Hindernisse
                        int gross = this.rnd.Next(0, 501);
                        switch (gross)
                        {
                            case (200):
                                this.emptyRectangle.Height = 606;
                                this.emptyRectangle.Width = 600;
                                this.hindernisse_vert.Add(new Erde(this.emptyBitmap, this.emptyRectangle, this.velocityErde, this.flag, this.flag));
                                break;
                            case (400):
                                this.emptyRectangle.Height = 744;
                                this.emptyRectangle.Width = 800;
                                this.hindernisse_vert.Add(new Sonne(this.emptyBitmap, this.emptyRectangle, this.velocitySonne, this.flag, this.flag));
                                break;
                            default: break;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Diese Methode erstellt verschiedene Hindernisse, welche horizontal über die Spielflaeche bewegt werden
        /// </summary>
        private void HindernisseHoriList()
        {
            try
            {
                //XPosition des Hindernisses wird auf Rechte Panelseite gesetzt
                this.emptyRectangle.X = this.sizeWidthPanel;
                //YPosition des Hindernisses wird zufällig erzeugt
                this.emptyRectangle.Y = this.rnd.Next(40, this.sizeHeightPanel - 40);

                //Zufälliges Hindernis wird ausgewählt und der Liste hinzugefügt
                //Beliebig erweiterbar
                //Normale Hindernisse
                byte zufall = (byte)this.rnd.Next(0, 4);
                switch (zufall)
                {
                    case (0):
                        this.emptyRectangle.Height = 60;
                        this.emptyRectangle.Width = 60;
                        this.hindernisse_hori.Add(new Asteroid(this.emptyBitmap, this.emptyRectangle, this.velocityAsteroid, this.flag, this.flag));
                        break;
                    case (1):
                        this.emptyRectangle.Height = 70;
                        this.emptyRectangle.Width = 70;
                        this.hindernisse_hori.Add(new Satellit(this.emptyBitmap, this.emptyRectangle, this.velocitySatellit, this.flag, this.flag));
                        break;
                    case (2):
                        this.emptyRectangle.Height = 50;
                        this.emptyRectangle.Width = 80;
                        this.hindernisse_hori.Add(new FeindlichesSchiff(this.emptyBitmap, this.emptyRectangle, this.velocityFeindlichesSchiff, this.flag, this.flag));
                        break;
                    case (3):
                        this.emptyRectangle.Height = 80;
                        this.emptyRectangle.Width = 103;
                        this.hindernisse_hori.Add(new Skelettstation(this.emptyBitmap, this.emptyRectangle, this.velocitySkelettstation, this.flag, this.flag));
                        break;
                    default: break;
                }

                //Größere Hindernisse
                byte mittel = (byte)this.rnd.Next(0, 51);
                switch (mittel)
                {
                    case (20):
                        this.emptyRectangle.Height = 150;
                        this.emptyRectangle.Width = 150;
                        this.hindernisse_hori.Add(new Bioschiff(this.emptyBitmap, this.emptyRectangle, this.velocityBioschiff, this.flag, this.flag));
                        break;
                    case (40):
                        this.emptyRectangle.Height = 189;
                        this.emptyRectangle.Width = 189;
                        this.hindernisse_hori.Add(new Metallplanet(this.emptyBitmap, this.emptyRectangle, this.velocityMetallplanet, this.flag, this.flag));
                        break;
                }

                //Schneller Komet
                byte random = (byte)this.rnd.Next(0, 50);
                if (random == 15 | random == 25)
                {
                    this.emptyRectangle.Height = 65;
                    this.emptyRectangle.Width = 273;
                    this.hindernisse_hori.Add(new Komet(this.emptyBitmap, this.emptyRectangle, this.velocityKomet, this.flag, this.flag));
                }

                //ab Level 10
                if (this.level >= 10)
                {
                    //Schild
                    if (random == 45 | random == 30)
                    {
                        this.emptyRectangle.Height = 25;
                        this.emptyRectangle.Width = 25;
                        this.hindernisse_hori.Add(new Schild(this.emptyBitmap, this.emptyRectangle, this.velocitySchild, this.flag, this.flag));
                    }
                    else if (random == 0 | random == 40)
                    {
                        this.emptyRectangle.Height = 30;
                        this.emptyRectangle.Width = 30;
                        this.hindernisse_hori.Add(new Munition(this.emptyBitmap, this.emptyRectangle, this.velocityMunition, this.flag, this.flag));
                    }
                }

                //Ab Level 15 kommen größere Hindernisse
                if (this.level >= 15)
                {
                    int pech = this.rnd.Next(0, 401);
                    switch (pech)
                    {
                        case (100):
                            this.emptyRectangle.Height = 227;
                            this.emptyRectangle.Width = 291;
                            this.hindernisse_hori.Add(new Doppelstation(this.emptyBitmap, this.emptyRectangle, this.velocityDoppelstation, this.flag, this.flag));
                            break;
                        case (200):
                            this.emptyRectangle.Height = 222;
                            this.emptyRectangle.Width = 200;
                            this.hindernisse_hori.Add(new Einschlag(this.emptyBitmap, this.emptyRectangle, this.velocityEinschlag, this.flag, this.flag));
                            break;
                        case (300):
                            this.emptyRectangle.Height = 313;
                            this.emptyRectangle.Width = 417;
                            this.hindernisse_hori.Add(new Kreisschiff(this.emptyBitmap, this.emptyRectangle, this.velocityKreisschiff, this.flag, this.flag));
                            break;
                        case (400):
                            this.emptyRectangle.Height = 346;
                            this.emptyRectangle.Width = 350;
                            this.hindernisse_hori.Add(new Saturn(this.emptyBitmap, this.emptyRectangle, this.velocitySaturn, this.flag, this.flag));
                            break;
                        default: break;
                    }
                }

                //Wenn die Schwierigkeit höher ist als "Schwer"
                if (Speicher.Schwierigkeit < 1500)
                {
                    //Ab Level 20
                    if (this.level >= 20)
                    {
                        //Sehr grosse Hindernisse
                        int gross = this.rnd.Next(0, 61);
                        switch (gross)
                        {
                            case (200):
                                this.emptyRectangle.Height = 606;
                                this.emptyRectangle.Width = 600;
                                this.hindernisse_hori.Add(new Erde(this.emptyBitmap, this.emptyRectangle, this.velocityErde, this.flag, this.flag));
                                break;
                            case (400):
                                this.emptyRectangle.Height = 744;
                                this.emptyRectangle.Width = 800;
                                this.hindernisse_hori.Add(new Sonne(this.emptyBitmap, this.emptyRectangle, this.velocitySonne, this.flag, this.flag));
                                break;
                            default: break;
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Mit dieser Methode werden alle Hindernisse bewegt, die Geschwindigkeit der Hindernisse erhöht und Hindernisse gelöscht    
        /// </summary>
        public void HindernisseBewegen()
        {
            try
            {
                //Für normale Hindernisse (Löschkoordinate)
                int x = -380;
                //ab Level 15 kommen größere Hindernisse (Löschkoordinate)
                if (this.level >= 15)
                {
                    x = -420;
                }
                //Wenn die Schwierigkeit höher ist als "Schwer" 
                if (Speicher.Schwierigkeit < 1500)
                {
                    //Sehr große Hindernisse (Löschkoordinate)
                    if (this.level >= 20)
                    {
                        x = -810;
                    }
                }
                for (int i = 0; i < this.hindernisse_hori.Count(); i++)
                {
                    this.hindernisse_hori[i].BewegenHori();
                    //Wenn Hindernis das Panel auf der linken Seite verlässt wird es gelöscht

                    if (this.hindernisse_hori[i].Rectangle.X < x)
                    {
                        this.hindernisse_hori[i].Dispose();
                        this.hindernisse_hori[i] = null;
                        this.hindernisse_hori.Remove(this.hindernisse_hori[i]);

                        //Wenn ein Hindernis gelöscht wird wird der Highscore um 10 erhöht
                        if (this.level >= 10)
                        {
                            this.score += 10;
                        }
                        else
                        {
                            this.score += 5;
                        }
                    }
                }
                //Es kommen vertikale Hindernisse erst ab Level 10
                if (this.level >= 10)
                {
                    //Für normale Hindernisse (Löschkoordinate
                    int y = -250;
                    //ab Level 15 kommen größere Hindernisse (Löschkoordinate)
                    if (this.level >= 15)
                    {
                        y = -350;
                    }
                    //Wenn die Schwierigkeit höher ist als "Schwer" 
                    if (Speicher.Schwierigkeit < 1500)
                    {
                        //Sehr große Hindernisse (Löschkoordinate)
                        if (this.level >= 20)
                        {
                            y = -750;
                        }
                    }
                    for (int h = 0; h < this.hindernisse_vert.Count(); h++)
                    {
                        this.hindernisse_vert[h].BewegenVert();
                        //Wenn Hindernis das Panel auf der oberen Seite verlässt wird es gelöscht
                        if (this.hindernisse_vert[h].Rectangle.Y < y)
                        {
                            this.hindernisse_vert[h].Dispose();
                            this.hindernisse_vert[h] = null;
                            this.hindernisse_vert.Remove(this.hindernisse_vert[h]);
                            //Wenn ein Hindernis gelöscht wird wird der Highscore um 10 erhöht
                            this.score += 5;
                        }
                    }
                    for (int j = 0; j < this.schuss.Count(); j++)
                    {
                        this.schuss[j].BewegenHori();
                        if (this.schuss[j].Rectangle.X > this.sizeWidthPanel + 20)
                        {
                            this.schuss[j].Dispose();
                            this.schuss[j] = null;
                            this.schuss.Remove(this.schuss[j]);
                        }
                    }

                }
                //Jedes Level wird die Geschwindigkeit der Hindernisse erhöht bzw. ebenso dazu der Erzeugungsintervall verkleinert
                if (this.score / 500 == this.level)
                {
                    //Level wird erhöht
                    this.level++;
                    //scoreup verhindert mehrmaligen Aufruf der Anweisung  
                    if (this.scoreup)
                    {
                        //verhindert mehrmaliges Aufrugen
                        this.scoreup = false;
                        //Erhöhung der Geschwindigkeit
                        this.velocityAsteroid += 3;
                        this.velocitySatellit += 2;
                        this.velocityFeindlichesSchiff += 4;
                        this.velocityBlauer_Komet += 7;
                        this.velocityKomet += 7;
                        this.velocitySchild += 3;
                        this.velocityBioschiff += 3;
                        this.velocityMetallplanet += 4;
                        this.velocitySkelettstation += 4;
                        if (this.level >= 15)
                        {
                            this.velocityDoppelstation += 5;
                            this.velocityEinschlag += 3;
                            this.velocityKreisschiff += 5;
                            this.velocitySaturn += 3;
                        }

                        //Verkleinerung des Intervalls
                        if (this.hindernisseErzeugen.Interval > 100)
                        {
                            if (this.level < 7)
                            {
                                this.hindernisseErzeugen.Interval -= 40;
                            }
                            else if (this.level >= 7)
                            {
                                this.hindernisseErzeugen.Interval -= 60;
                            }
                        }
                    }
                }

                //Scoreup wird auf true gesetzt um beim nächsten Level die Geschwindigkeit zu erhöhen
                if (this.score % 500 > 0)
                {
                    this.scoreup = true;
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Diese Methode gibt den Status des Schutzschildes des Raumschiffs aus 
        /// </summary>
        /// <returns>aktuelle Status des Schildes</returns>
        public string SchildStatus()
        {
            try
            {
                //Schild aktiviert
                if (this.schild)
                {
                    this.erg = "aktiviert!";
                }

                //Schild deaktiviert
                else
                {
                    this.erg = "deaktiviert!";
                }

                return this.erg;
            }
            catch
            {
                this.erg = "deaktiviert!";
                return this.erg;
            }
        }

        /// <summary>
        /// Diese Methode aktiviert das Schutzschild des Raumschiffs
        /// </summary>
        public void Schildaktivieren()
        {
            try
            {
                //Ab Schiffen der Stufe 2
                if (Speicher.Schiff > 3)
                {
                    //Sofern das Schild nicht gerade aktiviert ist, wird es aktiviert
                    if (this.kristalle > 0 && !this.schild)
                    {
                        this.schild = true;
                        this.kristalle--;
                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Entfernt alle Hindernisse im Umkreis eines Rechtscks, Bombe
        /// </summary>
        /// <param name="rect">"Bombenkrater"</param>
        public void Krater(Rectangle rect)
        {
            try
            {
                if (Speicher.Schiff == 6 && this.bomben > 0)
                {
                    this.bomben--;
                    var detonation =
                            from flugkoerper in this.hindernisse_hori.Union(this.hindernisse_vert)
                            select flugkoerper;
                    List<Flugkoerper> opfer = detonation.ToList();
                    for (int i = 0; i < opfer.Count(); i++)
                    {
                        if (rect.Contains(opfer[i].Rectangle.Location))
                        {
                            opfer[i].Bitmap = new Bitmap(opfer[i].Rectangle.Width, opfer[i].Rectangle.Height);

                            using (Graphics graphics = Graphics.FromImage(opfer[i].Bitmap))
                            {
                                graphics.FillRectangle(Brushes.Black, 0, 0, opfer[i].Rectangle.Width, opfer[i].Rectangle.Height);
                                opfer[i].Setzen();
                            }

                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Schuss wird ausgelöst
        /// </summary>
        public void Schießen()
        {
            if (Speicher.Schiff > 3 && this.munition > 0)
            {
                this.emptyRectangle.X = this.raumschiff.Rectangle.X + 80;
                this.emptyRectangle.Y = this.raumschiff.Rectangle.Y + 11;

                this.emptyRectangle.Height = 5;
                this.emptyRectangle.Width = 10;
                this.schuss.Add(new Schuss(this.emptyBitmap, this.emptyRectangle, this.velocitySchuss, this.flag, this.flag));
                this.munition--;
            }
        }

        /// <summary>
        /// Diese Methode setzt alle Werte auf die Startwerte zurück 
        /// </summary>
        public void Zuruecksetzen()
        {
            this.bomben = 0;
            this.beams = 0;
            this.kristalle = 0;
            this.scoreup = true;
            this.wiederholung = true;
            this.score = 0;
            this.level = 1;
            this.velocityAsteroid = 7;
            this.velocitySatellit = 8;
            this.velocityFeindlichesSchiff = 10;
            this.velocityKomet = 100;
            this.velocityBlauer_Komet = 100;
            this.velocityRaumschiff = 10;
            this.velocitySchild = 20;
            this.velocityMunition = 20;
            this.velocityBioschiff = 9;
            this.velocityMetallplanet = 6;
            this.velocitySkelettstation = 12;
            this.velocityDoppelstation = 8;
            this.velocityEinschlag = 13;
            this.velocityKreisschiff = 10;
            this.velocitySaturn = 5;
            this.velocityErde = 5;
            this.velocitySonne = 4;
            this.velocitySchuss = 25;
            this.munition = 0;
            this.velocitySchild = 20;
            this.hindernisseErzeugen.Interval = Speicher.Schwierigkeit;
            this.bedingung = 0;
            Spiel.Wache = 10;
            Speicher.Schiff = 1;
        }

        /// <summary>
        /// Diese Methode ruft die Methode BewegenAUF() der Klasse Raumschiff auf
        /// </summary>
        public void RaumschiffAUF()
        {
            this.raumschiff.BewegenAuf();
        }

        /// <summary>
        /// Diese Methode ruft die Methode BewegenAB() der Klasse Raumschiff auf
        /// </summary>
        public void RaumschiffAB()
        {
            this.raumschiff.BewegenAb(this.sizeHeightPanel);
        }

        /// <summary>
        /// Diese Methode ruft die Methode BewegenLinks() der Klasse Raumschiff auf
        /// </summary>
        public void RaumschiffLinks()
        {
            this.raumschiff.BewegenLinks();
        }

        /// <summary>
        /// Diese Methode ruft die Methode BewegenRechts() der Klasse Raumschiff auf
        /// </summary>
        public void RaumschiffRechts()
        {
            this.raumschiff.BewegenRechts(this.sizeWidthPanel);
        }

        /// <summary>
        /// Diese Methode prüft das gewählte Ramschiff und ruft die Methode RaumschiffBeam() der Klasse Raumschiff auf
        /// </summary>
        /// <param name="x">neue x Koordinate des Raumschiffs</param>
        /// <param name="y">neue y Koordinate des Raumschiffs</param>
        public void Beam(int x, int y)
        {
            bool erg = false;
            //Schiff der Stufe 3
            if (Speicher.Schiff == 6)
            {
                //Beams müssen größer als 0 sein
                if (this.beams > 0)
                {
                    //Beam Methode der Raumschiff Klasse wird aufgerufen
                    erg = this.raumschiff.RaumschiffBeam(x, y, this.sizeWidthPanel, this.sizeHeightPanel);
                    if (erg)
                    {
                        this.beams--;
                    }
                }
            }
        }

        /// <summary>
        /// Diese Methode erhöht den Wert des Variable beams, wenn das Level über 14 ist
        /// </summary>
        private void BeamsMunitionBombenerhoehen()
        {
            if (this.level >= 10)
            {
                this.munition += 20;
            }

            //ab Level 15 werden Beams um fünf erhöht
            else if (this.level >= 15)
            {
                this.beams += 10;
                this.bomben++;
            }
        }

        /// <summary>
        /// Überprüfung ob ein Schuss ein Hinderniss getroffen hat 
        /// </summary>
        public void Treffer()
        {
            try
            {
                var ziel =
                    from flugkoerper in this.hindernisse_hori.Union(this.hindernisse_vert)
                    select flugkoerper;
                List<Flugkoerper> scheibe = ziel.ToList();

                for (int i = 0; i < this.schuss.Count(); i++)
                {
                    for (int j = 0; j < scheibe.Count(); j++)
                    {
                        if (scheibe[j].Rectangle.Contains(this.schuss[i].Rectangle.Location))
                        {
                            scheibe[j].Bitmap = new Bitmap(scheibe[j].Rectangle.Width, scheibe[j].Rectangle.Height);

                            using (Graphics graphics = Graphics.FromImage(scheibe[j].Bitmap))
                            {
                                graphics.FillRectangle(Brushes.Black, 0, 0, scheibe[j].Rectangle.Width, scheibe[j].Rectangle.Height);
                                scheibe[j].Setzen();
                            }

                            this.schuss[i].Bitmap = new Bitmap(this.schuss[i].Rectangle.Width, this.schuss[i].Rectangle.Height);

                            using (Graphics graphics = Graphics.FromImage(this.schuss[i].Bitmap))
                            {
                                graphics.FillRectangle(Brushes.Black, 0, 0, this.schuss[i].Rectangle.Width, this.schuss[i].Rectangle.Height);
                                this.schuss[i].Setzen();
                            }
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Diese Methode prüft auf Kollisionen des Raumschiffs mit allen Hindernissen, welche horizontal über die Spielflaeche bewegt wird
        /// </summary>
        /// <returns>flag ob Kollission stattgefunden hat oder nicht</returns>

        public bool PruefeKolission()
        {
            bool erg;
            try
            {
                var schiff =
                    from flugkoerper in this.hindernisse_hori.Union(this.hindernisse_vert)
                    where Math.Abs(flugkoerper.Rectangle.X - this.raumschiff.Rectangle.X) < 810
                    where Math.Abs(flugkoerper.Rectangle.Y - this.raumschiff.Rectangle.Y) < 810
                    select flugkoerper;

                List<Flugkoerper> hindernis = schiff.ToList();
                //Diese Flag zeigt die Kolission an
                erg = false;
                Rectangle rect1 = new Rectangle();
                //Jedes Hinderniss wird überprüft
                for (int i = 0; i < hindernis.Count(); i++)
                {
                    //Prüft ob es Überschneidungen gibt
                    if (this.raumschiff.Rectangle.IntersectsWith(hindernis[i].Rectangle))
                    {

                        //Überschneidungsrechteck wird gebildet
                        rect1 = Rectangle.Intersect(this.raumschiff.Rectangle, hindernis[i].Rectangle);
                        if (!rect1.IsEmpty)
                        {
                            //Wenn das Level kleiner als 10 ist, gibt es keine weitere Optionen
                            if (this.level < 10)
                            {
                                //Kolission hat stattgefunden
                                erg = true;
                                return erg;
                            }
                            //Ab Level 10 sind neue Optionen offen
                            else if (this.level >= 10)
                            {
                                if (hindernis[i].Munitionsflag)
                                {
                                    this.munition += 20;
                                    hindernis[i].Setzen();
                                    erg = false;
                                    return erg;
                                }
                                else if (hindernis[i].Schildflag)
                                {
                                    //Das Schild wird vom Raumschiff aufgesammelt
                                    hindernis[i].Setzen();
                                    //Kristalle erhöht sich um das aufgesammelte Schild
                                    this.kristalle++;
                                    erg = false;
                                    return erg;
                                }
                                //Das Schildflag der Hindernisses ist false, als kein Schilde
                                else if (!hindernis[i].Schildflag)
                                {
                                    //Wenn das Schutzschild aktiviert ist
                                    if (this.schild)
                                    {
                                        //Das Hindernis mit dem das Raumschiff kollidiert wird zerstört, da das Schutzschild aktiviert ist
                                        hindernis[i].Bitmap = new Bitmap(hindernis[i].Rectangle.Width, hindernis[i].Rectangle.Height);
                                        using (Graphics graphics = Graphics.FromImage(hindernis[i].Bitmap))
                                        {
                                            graphics.FillRectangle(Brushes.Black, 0, 0, hindernis[i].Rectangle.Width, hindernis[i].Rectangle.Height);
                                        }
                                        hindernis[i].Setzen();

                                        //Das Schutzschild wird deaktiviert
                                        this.schild = false;
                                        erg = false;
                                        return erg;
                                    }
                                    //Schutzschild ist nicht aktiviert
                                    else
                                    {
                                        //Kolission hat stattgefunden
                                        erg = true;
                                        return erg;
                                    }
                                }
                            }
                        }

                        //Wenn das Level höher als 15 ist, könnte der Spieler sich in ein großes Hindernis beamen, dies wird verhindert
                        if (this.level >= 15)
                        {
                            //Hindernis beinhaltet das Raumschiff
                            if (hindernis[i].Rectangle.Contains(this.raumschiff.Rectangle.Location))
                            {
                                //Raumschiff ist zerstört
                                erg = true;
                                return erg;
                            }
                            else
                            {
                                erg = false;
                                return erg;
                            }
                        }
                    }

                }
                return erg;
            }
            catch
            {
                erg = false;
                return erg;
            }
        }
    }
}
