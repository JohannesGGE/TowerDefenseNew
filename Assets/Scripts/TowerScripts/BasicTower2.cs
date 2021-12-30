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
        new void Start()
        {
          firePoint=gameObject.GetComponent<BasicTower1>().firePoint;
          partToRotate=gameObject.GetComponent<BasicTower1>().firePoint;
          stingPrefab=gameObject.GetComponent<BasicTower1>().stingPrefab;
          towerDamage = 50;
          towerEffect = "none";
          range = 5f;
          fireRate = 1f;
          fireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        protected override void Upgrade()
        {
          gameObject.AddComponent<BasicTower3>();
          DestroyScriptInstance();
        }
    }
}
