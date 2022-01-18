using UnityEngine;

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
        /// Variable <c>_doubleSpeed</c> enthaelt, ob das Spiel mit doppelter Geschwindigkeit laeuft
        /// </summary>
        private bool _doubleSpeed;

        /// <summary>
        /// Variable <c>_allEnemySpawned</c> enthaelt, ob in der letzen Welle der letze Vogel gespawnt wurde
        /// </summary>
        private bool _allEnemySpawned;

        /// <summary>
        /// Variable <c>_lastEnemyKilled</c> enthaelt, ob der letzte Vogel getoetet wurde (nicht unbedingt letzer gespawnter!)
        /// </summary>
        private bool _lastEnemyKilled;
        
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
            _allEnemySpawned = false;
            _lastEnemyKilled = false;
            _lives = 100;
            _coins = 0;
            _level = null;
        }
        
        /// <summary>
        /// Startet das Spiel/Setzt das Spiel fort
        /// </summary>
        public void StartGame() {
            Time.timeScale = 1;
            _paused = false;
            _doubleSpeed = false;
        }

        /// <summary>
        /// Pausiert das Spiel
        /// </summary>
        public void PauseGame() {
            Time.timeScale = 0;
            _paused = true;
        }

        /// <summary>
        /// Verdoppelt die Spielgeschwindigkeit
        /// </summary>
        public void DoubleGame() {
            Time.timeScale = 2;
            _doubleSpeed = true;
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
            _coins -= coins;
        }

        /// <summary>
        /// enthaelt, ob das Spiel pausiert ist
        /// </summary>
        public bool Paused => _paused;

        /// <summary>
        /// enthaelt, ob das Spiel mit doppelter Geschwindigkeit laeuft
        /// </summary>
        public bool DoubleSpeed => _doubleSpeed;

        /// <summary>
        /// enthaelt, ob in der letzen Welle der letze Vogel gespawnt wurde
        /// </summary>
        public bool AllEnemySpawned {
            get => _allEnemySpawned;
            set => _allEnemySpawned = value;
        }

        /// <summary>
        /// enthaelt, ob der letzte Vogel getoetet wurde (nicht unbedingt letzer gespawnter!)
        /// </summary>
        public bool LastEnemyKilled {
            get => _lastEnemyKilled;
            set => _lastEnemyKilled = value;
        }

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