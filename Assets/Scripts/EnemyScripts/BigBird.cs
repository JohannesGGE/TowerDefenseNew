using Classes;
using UnityEngine;

namespace Backbone {
    
    public class BigBird : Enemy {
        private GameManager _gameManager;

        public BigBird() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            Health = 100;
            Worth = 20;
            BirdDamage = 10;
            
        }
    }
}