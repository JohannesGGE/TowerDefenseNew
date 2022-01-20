using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone {
    
    public class MediumBird : Enemy {

        new void Start() {

            base.Start();
            _health = GameValues.MediumBirdHealth;
            _worth = GameValues.MediumBirdWorth;
            _birdDamage = GameValues.MediumBirdDamage;
        }
    }
}