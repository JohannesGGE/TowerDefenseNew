using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class BasicTower2 : Tower
    {
        // Start is called before the first frame update
        void Start()
        {
          UpgradeCost = GameValues.UpgradeCostBasicTower2;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Stage = "BasicStageTwo";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<BasicTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<BasicTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<BasicTower1>().StingPrefab;
          TowerDamage = GameValues.DamageBasicTower2;
          Range = GameValues.RangeBasicTower2;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateBasicTower2;
          FireCountdown = GameValues.FireCountdownBasicTower2;
          soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
          gameObject.AddComponent<BasicTower3>();
          DestroyScriptInstance();
        }
    }
}
