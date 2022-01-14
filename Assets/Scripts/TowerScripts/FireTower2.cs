using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class FireTower2 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatiating the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public FireTower2()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
          FirePoint=gameObject.GetComponent<FireTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<FireTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<FireTower1>().StingPrefab;
          TowerDamage = 5;
          Range = 5f;
          FireRate = 1f;
          FireCountdown = 0f;
          TowerEffect = "fire";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        protected override void Upgrade()
        {
          gameObject.AddComponent<FireTower3>();
          DestroyScriptInstance();
        }
    }
}
