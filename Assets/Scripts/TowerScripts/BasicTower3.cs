
using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower3 : Tower
    {
        // Start is called before the first frame update
        void Start()
        {
          UpgradeCost = GameValues.UpgradeCostBasicTower3;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Stage = "BasicStageThree";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<BasicTower2>().FirePoint;
          PartToRotate=gameObject.GetComponent<BasicTower2>().FirePoint;
          StingPrefab=gameObject.GetComponent<BasicTower2>().StingPrefab;
          TowerDamage = GameValues.DamageBasicTower3;
          Range = GameValues.RangeBasicTower3;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateBasicTower3;
          FireCountdown = GameValues.FireCountdownBasicTower3;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}



