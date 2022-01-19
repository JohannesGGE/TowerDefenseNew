using Classes;
using UnityEngine;

namespace Backbone {
    
    public class MediumBird : Enemy {


        void Start() {
            _health = GameValues.MediumBirdHealth;
            _worth = GameValues.MediumBirdWorth;
            _birdDamage = GameValues.MediumBirdDamage;
            
        }
    }
}