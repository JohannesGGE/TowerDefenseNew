using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class FireTower1 : Tower
    {
        // Start is called before the first frame update
        //outdated: new keyword if hiding the Base Class Method is needed
        void Start()
        {
          Price = GameValues.PriceFireTower;
          UpgradeCost = GameValues.UpgradeCostFireTower1;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Stage = "FireStageOne";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          TowerDamage = GameValues.DamageFireTower1;
          Range = GameValues.RangeFireTower1;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateFireTower1;
          FireCountdown = GameValues.FireCountdownFireTower1;
          TowerEffect = "fire";
          soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
          gameObject.AddComponent<FireTower2>();
          DestroyScriptInstance();
        }
    }
}
