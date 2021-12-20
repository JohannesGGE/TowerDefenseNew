using Classes;
using UnityEngine;

namespace Backbone {
    
    // NUR EIN TEMPLATE FUER DIE TOWER
    public class Tower : MonoBehaviour {
        private GameManager _gameManager;

        public Tower() {
            _gameManager = GameManager.GetInstance();
        }

        void Start() {
            
        }

        void Update() {
            if(!_gameManager.Paused) {
                //Do shooting
            }
        }
    }
}