using Classes;
using UnityEngine;

namespace Backbone {
    
    public class MediumBird : Enemy {
        private GameManager _gameManager;

        public MediumBird() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            health = 75;
            worth = 10;
            birdDamage = 5;
            
        }
    }
}