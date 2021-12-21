using Classes;
using UnityEngine;

namespace Backbone {

    // NUR EIN TEMPLATE FUER DIE TOWER
    public class TowerTemplate : MonoBehaviour {
        private GameManager _gameManager;

        public TowerTemplate() {
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
