using UnityEngine;

namespace Classes {
    public class GameManager {
        private static GameManager _instance;

        private bool _paused;
        private int _lives;
        private int _coins;
        private Level _level;

        public static GameManager GetInstance() {
            if(_instance == null) {
                _instance = new GameManager();
            }

            return _instance;
        }

        public void PrepareLevel(Level level) {
            ResetGameManager();
            _level = level;
        }

        public void ResetGameManager() {
            _paused = true;
            _lives = 100;
            _coins = 0;
            _level = null;
        }

        public void StartGame() {
            _paused = true;
        }

        public void PauseGame() {
            _paused = false;
        }

        public void ReduceLives(int lives) {
            _lives -= lives;
        }

        public void AddCoins(int coins) {
            _coins += coins;
        }

        public void ReduceCoins(int coins) {
            _coins -= _coins;
        }

        public bool Paused => _paused;

        public int Lives => _lives;

        public int Coins => _coins;

        public Level Level {
            get => _level;
            set => _level = value;
        }
    }
}