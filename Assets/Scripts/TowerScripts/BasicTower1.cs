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
          Price = GameValues.PriceBasicTower;
          UpgradeCost = GameValues.UpgradeCostBasicTower1;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Stage = "BasicStageOne";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          TowerDamage = GameValues.DamageBasicTower1;
          Range = GameValues.RangeBasicTower1;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateBasicTower1;
          FireCountdown = GameValues.FireCountdownBasicTower1;
          soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

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
