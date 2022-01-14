using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class IceTower3 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatiating the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public IceTower3()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
          FirePoint=gameObject.GetComponent<IceTower2>().FirePoint;
          PartToRotate=gameObject.GetComponent<IceTower2>().FirePoint;
          StingPrefab=gameObject.GetComponent<IceTower2>().StingPrefab;
          TowerDamage = 0;
          Range = 5f;
          FireRate = 1f;
          FireCountdown = 0f;
          IceDuration=5f;
          IceDelay=0.2f;
          TowerEffect = "ice";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
