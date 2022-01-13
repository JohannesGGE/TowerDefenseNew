using Classes;
using UnityEngine;

namespace Backbone {
    
    public class BigBird : Enemy {
        private GameManager _gameManager;

        public BigBird() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            health = 100;
            worth = 20;
            birdDamage = 10;
            
        }
    }
}