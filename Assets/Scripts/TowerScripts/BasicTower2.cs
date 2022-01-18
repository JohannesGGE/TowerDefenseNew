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
          UpgradeCost = 10;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Stage = "BasicStageTwo";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<BasicTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<BasicTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<BasicTower1>().StingPrefab;
          TowerDamage = 7;
          Range = 300f;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = 1f;
          FireCountdown = 0f;

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
          gameObject.AddComponent<BasicTower3>();
          DestroyScriptInstance();
        }
    }
}
