using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower3 : Tower
    {
        private GameManager _gameManager;

        public BasicTower3()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        //new keyword because hiding the Base Class Method is intended
        new void Start()
        {
          firePoint=gameObject.GetComponent<BasicTower2>().firePoint;
          partToRotate=gameObject.GetComponent<BasicTower2>().firePoint;
          stingPrefab=gameObject.GetComponent<BasicTower2>().stingPrefab;
          towerDamage = 100;
          towerEffect = "none";
          range = 5f;
          fireRate = 1f;
          fireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
