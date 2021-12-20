namespace Classes {
    
    /// <summary>
    /// Klasse <c>GameManager</c> ist Singleton und dient der Datenverwaltung im Spiel
    /// </summary>
    public class GameManager {
        
        /// <summary>
        /// Variable <c>_instance</c> ist das Objekt der Klasse <c>GameManager</c>
        /// </summary>
        private static GameManager _instance;
        
        /// <summary>
        /// Variable <c>_paused</c> enthaelt, ob das Spiel pausiert ist
        /// </summary>
        private bool _paused;
        
        /// <summary>
        /// Variable <c>_lives</c> enthaelt die verbleibenden Leben 
        /// </summary>
        private int _lives;
        
        /// <summary>
        /// Variable <c>_coins</c> enthaelt die aktuell vorhandenen Coins
        /// </summary>
        private int _coins;
        
        /// <summary>
        /// Variable <c>_level</c> enhaelt die aktuellen Levelinformationen
        /// </summary>
        private Level _level;

        /// <summary>
        /// Erstellt das <c>GameManager</c> Objekt falls null
        /// </summary>
        /// <returns>Das <c>GameManager</c> Objekt</returns>
        public static GameManager GetInstance() {
            if(_instance == null) {
                _instance = new GameManager();
            }

            return _instance;
        }

        /// <summary>
        /// Resetet den <c>GameManager</c> und setzt neues Level
        /// </summary>
        /// <param name="level">Levelinformation fuer neues Level</param>
        public void PrepareLevel(Level level) {
            ResetGameManager();
            _level = level;
        }

        /// <summary>
        /// Resetet den <c>GameManager</c>
        /// </summary>
        public void ResetGameManager() {
            _paused = true;
            _lives = 100;
            _coins = 0;
            _level = null;
        }
        
        /// <summary>
        /// Startet das Spiel/Setzt das Spiel fort
        /// </summary>
        public void StartGame() {
            _paused = false;
        }

        /// <summary>
        /// Pausiert das Spiel
        /// </summary>
        public void PauseGame() {
            _paused = true;
        }

        /// <summary>
        /// Reduziert die Leben um mitgegebene Wert
        /// </summary>
        /// <param name="lives">abzuziehende Leben</param>
        public void ReduceLives(int lives) {
            _lives -= lives;
        }

        /// <summary>
        /// Erhöht die Coins um die mitgegebene Menge
        /// </summary>
        /// <param name="coins">zu addierende Coins</param>
        public void AddCoins(int coins) {
            _coins += coins;
        }

        /// <summary>
        /// Reduziert die Coins um mitgegebene Wert
        /// </summary>
        /// <param name="coins">abzuziehende Coins</param>
        public void ReduceCoins(int coins) {
            _coins -= _coins;
        }

        /// <summary>
        /// enthaelt, ob das Spiel pausiert ist
        /// </summary>
        public bool Paused => _paused;

        /// <summary>
        /// enthaelt die verbleibenden Leben 
        /// </summary>
        public int Lives => _lives;

        /// <summary>
        /// enthaelt die aktuell vorhandenen Coins
        /// </summary>
        public int Coins => _coins;

        /// <summary>
        /// enhaelt die aktuellen Levelinformationen
        /// </summary>
        public Level Level {
            get => _level;
            set => _level = value;
        }
    }
}