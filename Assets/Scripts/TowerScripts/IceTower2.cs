using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class IceTower2 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatiating the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public IceTower2()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {
          FirePoint=gameObject.GetComponent<IceTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<IceTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<IceTower1>().StingPrefab;
          TowerDamage = 0;
          Range = 5f;
          FireRate = 1f;
          FireCountdown = 0f;
          IceDuration=3f;
          IceDelay=0.15f;
          TowerEffect = "ice";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        protected override void Upgrade()
        {
          gameObject.AddComponent<IceTower3>();
          DestroyScriptInstance();
        }
    }
}
