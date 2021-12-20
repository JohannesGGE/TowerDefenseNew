using Classes;
using UnityEngine;

namespace Backbone {
    
    // NUR EIN TEMPLATE FUER DIE STACHEL
    public class Bullet : MonoBehaviour {
        private GameManager _gameManager;

        public Bullet() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            
        }

        void Update() {
            if(!_gameManager.Paused) {
                //Do movement
            }
        }
    }
}