using Classes;
using UnityEngine;

namespace Backbone {
    
    public class SmallBird : Enemy {
        private GameManager _gameManager;

        public SmallBird() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            Health = 50;
            Worth = 5;
            BirdDamage = 1;
            
        }
        
    }
}
