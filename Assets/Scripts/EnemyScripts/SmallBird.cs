using Classes;
using UnityEngine;

namespace Backbone {
    
    public class SmallBird : Enemy {
        private GameManager _gameManager;

        public SmallBird() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            health = 50;
            worth = 5;
            birdDamage = 1;
            
        }
        
    }
}
