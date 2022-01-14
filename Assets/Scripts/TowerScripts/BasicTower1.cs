using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower1 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatiating the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public BasicTower1()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        //outdated: new keyword if hiding the Base Class Method is needed
        void Start()
        {
          TowerDamage = 25;
          Range = 5f;
          FireRate = 1f;
          FireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        protected override void Upgrade()
        {
          gameObject.AddComponent<BasicTower2>();
          DestroyScriptInstance();
        }
    }
}
