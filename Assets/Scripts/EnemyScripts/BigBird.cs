using Classes;
using UnityEngine;

namespace Backbone {
    
    public class BigBird : Enemy {
        

        void Start() {
            _health = GameValues.BigBirdHealth;
            _worth = GameValues.BigBirdWorth;
            _birdDamage = GameValues.BigBirdDamage;
            
        }
    }
}