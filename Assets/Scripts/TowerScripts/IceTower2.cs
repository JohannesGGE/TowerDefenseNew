using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{
    public class IceTower2 : Tower
    {
        // Start is called before the first frame update
        void Start()
        {
          UpgradeCost = GameValues.UpgradeCostIceTower2;
          gameObject.GetComponent<TowerOverlay>().ActualCost = UpgradeCost;
          Debug.Log("Upgrade success"); //DEBUG
          Stage = "IceStageTwo";
          gameObject.GetComponent<TowerOverlay>().ActualStage = Stage;
          FirePoint =gameObject.GetComponent<IceTower1>().FirePoint;
          PartToRotate=gameObject.GetComponent<IceTower1>().FirePoint;
          StingPrefab=gameObject.GetComponent<IceTower1>().StingPrefab;
          TowerDamage = GameValues.DamageIceTower2;
          Range = GameValues.RangeIceTower2;
          gameObject.GetComponent<TowerOverlay>().ActualRange = Range;
          FireRate = GameValues.FireRateIceTower2;
          FireCountdown = GameValues.FireCountdownIceTower2;
          IceDelay=GameValues.IceDelayIceTower2;
          IceDuration=GameValues.IceDurationIceTower2;
          TowerEffect = "ice";
          soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();

          InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        public override void Upgrade()
        {
          gameObject.AddComponent<IceTower3>();
          DestroyScriptInstance();
        }
    }
}
