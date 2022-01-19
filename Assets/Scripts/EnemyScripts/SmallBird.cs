using Classes;
using UnityEngine;

namespace Backbone {
    
    public class SmallBird : Enemy {
        

        void Start() {
            _health = GameValues.SmallBirdHealth;
            _worth = GameValues.SmallBirdWorth;
            _birdDamage = GameValues.SmallBirdDamage;
            
        }
        
    }
}
