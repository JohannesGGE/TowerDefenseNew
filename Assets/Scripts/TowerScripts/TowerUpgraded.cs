using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class TowerUpgraded : Tower
    {
        private GameManager _gameManager;

        public TowerUpgraded()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
          firePoint=gameObject.GetComponent<Tower>().firePoint;
          partToRotate=gameObject.GetComponent<Tower>().firePoint;
          stingPrefab=gameObject.GetComponent<Tower>().stingPrefab;
          towerDamage = 50;
          towerEffect = "ice";
          range = 5f;
          fireRate = 1f;
          fireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
