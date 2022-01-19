using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class FireTower3 : Tower
    {
        // Start is called before the first frame update
        void Start()
        {
          UpgradeCost = GameValues.UpgradeCostFireTower3;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Debug.Log("Upgrade success"); //DEBUG
          Stage = "FireStageThree";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<FireTower2>().FirePoint;
          PartToRotate=gameObject.GetComponent<FireTower2>().FirePoint;
          StingPrefab=gameObject.GetComponent<FireTower2>().StingPrefab;
          TowerDamage = GameValues.DamageFireTower3;
          Range = GameValues.RangeFireTower3;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateFireTower3;
          FireCountdown = GameValues.FireCountdownFireTower3;
          TowerEffect = "fire";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
