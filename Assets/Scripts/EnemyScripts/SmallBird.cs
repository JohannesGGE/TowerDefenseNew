using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone {
    
    public class SmallBird : Enemy {
        
        new void Start() {

            base.Start();
            _health = GameValues.SmallBirdHealth;
            _worth = GameValues.SmallBirdWorth;
            _birdDamage = GameValues.SmallBirdDamage;
        }
    }
}
