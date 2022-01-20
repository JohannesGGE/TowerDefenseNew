using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class FireTower2 : Tower
    {
        // Start is called before the first frame update
        void Start()
        {
          UpgradeCost = GameValues.UpgradeCostFireTower2;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Debug.Log("Upgrade success"); //DEBUG
          Stage = "FireStageTwo";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<FireTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<FireTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<FireTower1>().StingPrefab;
          TowerDamage = GameValues.DamageFireTower2;
          Range = GameValues.RangeFireTower2;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateFireTower2;
          FireCountdown = GameValues.FireCountdownFireTower2;
          TowerEffect = "fire";
          soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
          gameObject.AddComponent<FireTower3>();
          DestroyScriptInstance();
        }
    }
}
