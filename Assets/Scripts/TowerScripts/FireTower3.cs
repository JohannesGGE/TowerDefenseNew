using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class FireTower3 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatianting the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public FireTower3()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
          Debug.Log("Upgrade success"); //DEBUG
          FirePoint=gameObject.GetComponent<FireTower2>().FirePoint;
          PartToRotate=gameObject.GetComponent<FireTower2>().FirePoint;
          StingPrefab=gameObject.GetComponent<FireTower2>().StingPrefab;
          TowerDamage = 7;
          Range = 300f;
          FireRate = 1f;
          FireCountdown = 0f;
          TowerEffect = "fire";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
