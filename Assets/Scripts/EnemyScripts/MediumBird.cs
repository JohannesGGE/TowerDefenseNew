using Classes;
using UnityEngine;

namespace Backbone {
    
    public class MediumBird : Enemy {
        private GameManager _gameManager;

        public MediumBird() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            Health = 75;
            Worth = 10;
            BirdDamage = 5;
            
        }
    }
}