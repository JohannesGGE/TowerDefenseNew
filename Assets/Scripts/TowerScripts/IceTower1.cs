using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class IceTower1 : Tower
    {
        // Start is called before the first frame update
        //outdated: new keyword if hiding the Base Class Method is needed
        void Start()
        {
          Price = GameValues.PriceIceTower;
          UpgradeCost = GameValues.UpgradeCostIceTower1;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Stage = "IceStageOne";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          TowerDamage = GameValues.DamageIceTower1;
          Range = GameValues.RangeIceTower1;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateIceTower1;
          FireCountdown = GameValues.FireCountdownIceTower1;
          IceDelay=GameValues.IceDelayIceTower1;
          IceDuration=GameValues.IceDurationIceTower1;
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
