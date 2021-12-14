using UnityEngine;

namespace Classes {
    public class GameManager {
        private static GameManager _instance;
        private bool _paused = false;

        public static GameManager GetInstance() {
            if(_instance == null) {
                _instance = new GameManager();
            }

            return _instance;
        }

        public bool Paused {
            get => _paused;
            set => _paused = value;
        }
        
    }
}