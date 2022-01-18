using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class IceTower3 : Tower
    {
        // Start is called before the first frame update
        void Start()
        {
          UpgradeCost = 10;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Debug.Log("Upgrade success"); //DEBUG
          Stage = "IceStageThree";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<IceTower2>().FirePoint;
          PartToRotate=gameObject.GetComponent<IceTower2>().FirePoint;
          StingPrefab=gameObject.GetComponent<IceTower2>().StingPrefab;
          TowerDamage = 0;
          Range = 300f;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = 1f;
          FireCountdown = 0f;
          IceDuration=5f;
          IceDelay=0.2f;
          TowerEffect = "ice";

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
