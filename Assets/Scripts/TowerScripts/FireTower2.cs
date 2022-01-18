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
          UpgradeCost = 10;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Debug.Log("Upgrade success"); //DEBUG
          Stage = "FireStageTwo";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<FireTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<FireTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<FireTower1>().StingPrefab;
          TowerDamage = 5;
          Range = 300f;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = 1f;
          FireCountdown = 0f;
          TowerEffect = "fire";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
          gameObject.AddComponent<FireTower3>();
          DestroyScriptInstance();
        }
    }
}
