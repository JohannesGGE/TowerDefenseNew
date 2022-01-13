using Classes;
using UnityEngine;

namespace Backbone {
    
    public class BigBird : Enemy {
        

        void Start() {
            _health = 100;
            _worth = 20;
            _birdDamage = 10;
            
        }
    }
}