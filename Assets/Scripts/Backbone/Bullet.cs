using Classes;
using UnityEngine;

namespace Backbone {
    public class Bullet : MonoBehaviour {
        private GameManager _gameManager;

        public Bullet() {
            _gameManager = GameManager.GetInstance();
        }

        protected void Start() {
            
        }

        void Update() {
            if(!_gameManager.Paused) {
                //Do movement
            }
        }
    }
}