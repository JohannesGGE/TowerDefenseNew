using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower2 : Tower
    {
        private GameManager _gameManager;

        public BasicTower2()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        //new keyword because hiding the Base Class Method is intended
        void Start()
        {
          FirePoint=gameObject.GetComponent<BasicTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<BasicTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<BasicTower1>().StingPrefab;
          TowerDamage = 50;
          Range = 5f;
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
