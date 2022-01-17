using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower2 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatianting the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public BasicTower2()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
          FirePoint=gameObject.GetComponent<BasicTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<BasicTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<BasicTower1>().StingPrefab;
          TowerDamage = 7;
          Range = 300f;
          FireRate = 1f;
          FireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        protected override void Upgrade()
        {
          gameObject.AddComponent<BasicTower3>();
          DestroyScriptInstance();
        }
    }
}
