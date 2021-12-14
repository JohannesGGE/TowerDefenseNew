using Classes;
using UnityEngine;

namespace Backbone {
    public class Bird : MonoBehaviour {
        private GameManager _gameManager;

        public Bird() {
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