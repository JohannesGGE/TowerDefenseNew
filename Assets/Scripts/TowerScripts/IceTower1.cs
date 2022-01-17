using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class IceTower1 : Tower
    {
        /// <summary>
        /// Variable <c>_gameManager</c> for instatianting the GameManager class
        /// </summary>
        private GameManager _gameManager;

        public IceTower1()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        //outdated: new keyword if hiding the Base Class Method is needed
        void Start()
        {
          Stage = "IceStageOne";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          TowerDamage = 0;
          Range = 300f;
          FireRate = 1f;
          FireCountdown = 0f;
          IceDelay=0.2f;
          IceDuration=2f;
          TowerEffect = "ice";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
          gameObject.AddComponent<IceTower2>();
          DestroyScriptInstance();
        }
    }
}
