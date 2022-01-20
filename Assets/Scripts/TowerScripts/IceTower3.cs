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
          UpgradeCost = GameValues.UpgradeCostIceTower3;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Debug.Log("Upgrade success"); //DEBUG
          Stage = "IceStageThree";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<IceTower2>().FirePoint;
          PartToRotate=gameObject.GetComponent<IceTower2>().FirePoint;
          StingPrefab=gameObject.GetComponent<IceTower2>().StingPrefab;
          TowerDamage = GameValues.DamageIceTower3;
          Range = GameValues.RangeIceTower3;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateIceTower3;
          FireCountdown = GameValues.FireCountdownIceTower3;
          IceDelay=GameValues.IceDelayIceTower3;
          IceDuration=GameValues.IceDurationIceTower3;
          TowerEffect = "ice";
          soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
}
