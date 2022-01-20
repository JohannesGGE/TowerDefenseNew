using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone {
    
    public class BigBird : Enemy {
        
        new void Start() {

            base.Start();
            _health = GameValues.BigBirdHealth;
            _worth = GameValues.BigBirdWorth;
            _birdDamage = GameValues.BigBirdDamage;
        }
    }
}