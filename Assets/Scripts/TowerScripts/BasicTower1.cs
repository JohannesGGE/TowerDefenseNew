using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower1 : Tower
    {
        // Start is called before the first frame update
        //outdated: new keyword if hiding the Base Class Method is needed
        void Start()
        {
          Price = 20;
          UpgradeCost = 10;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Stage = "BasicStageOne";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          TowerDamage = 5;
          Range = 300f;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = 1f;
          FireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
            Debug.Log("Skript2 added");

            gameObject.AddComponent<BasicTower2>();
            DestroyScriptInstance();

        }


    }
}
