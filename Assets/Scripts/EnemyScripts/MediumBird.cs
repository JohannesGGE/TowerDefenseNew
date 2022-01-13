using Classes;
using UnityEngine;

namespace Backbone {
    
    public class MediumBird : Enemy {


        void Start() {
            _health = 75;
            _worth = 10;
            _birdDamage = 5;
            
        }
    }
}