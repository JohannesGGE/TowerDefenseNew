using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower3 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatianting the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public BasicTower3()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
          FirePoint=gameObject.GetComponent<BasicTower2>().FirePoint;
          PartToRotate=gameObject.GetComponent<BasicTower2>().FirePoint;
          StingPrefab=gameObject.GetComponent<BasicTower2>().StingPrefab;
          TowerDamage = 10;
          Range = 300f;
          FireRate = 1f;
          FireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
