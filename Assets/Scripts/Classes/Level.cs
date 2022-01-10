namespace Classes {
    
    /// <summary>
    /// Klasse <c>Level</c> enthaelt die Level-Informationen fuer ein Level
    /// </summary>
    public class Level {
        
        /// <summary>
        /// Variable <c>_waves</c> enthaelt die Wellen
        /// </summary>
        private Wave[] _waves;

        /// <summary>
        /// Variable <c>_unlocked</c> enthaelt ob das Level freigeschaltet ist (spielbar)
        /// </summary>
        private bool _unlocked;
        
        /// <summary>
        /// Variable <c>_stars</c> enthaelt die erreichten Sterne fuer das Level
        /// </summary>
        private int _stars;

        /// <summary>
        /// Konstruktor, setzt die Uebergebenen Wellen und setzt Sterne 0
        /// </summary>
        /// <param name="waves">zu setzende Wellen</param>
        public Level(Wave[] waves, bool unlocked) {
            _waves = waves;
            _unlocked = unlocked;
            _stars = 0;
        }

        /// <summary>
        /// enthaelt die Wellen
        /// </summary>
        public Wave[] Waves => _waves;

        /// <summary>
        /// enthaelt ob das Level freigeschaltet ist (spielbar)
        /// </summary>
        public bool Unlocked {
            get => _unlocked;
            set => _unlocked = value;
        }

        /// <summary>
        /// enthaelt die erreichten Sterne fuer das Level
        /// </summary>
        public int Stars {
            get => _stars;
            set => _stars = value;
        }
    }
}