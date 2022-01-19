using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{

    public class TowerOverlay : Tower
    {
        /// <summary>
        /// Variable <c>_actualStage</c> is declared in <c>TowerOverlay</c>, but defined by the subclasses
        /// </summary>
        private string _actualStage;

        /// <summary>
        /// Getters and Setters <c>ActualStage</c> for <c>_actualStage</c>
        /// </summary>
        public string ActualStage
        {
            get { return _actualStage; }
            set { _actualStage = value; }
        }

        /// <summary>
        /// Variable <c>_actualCost</c> is declared in <c>TowerOverlay</c>, but defined by the subclasses
        /// </summary>
        private int _actualCost;

        /// <summary>
        /// Getters and Setters <c>ActualCost</c> for <c>_actualCost</c>
        /// </summary>
        public int ActualCost
        {
            get { return _actualCost; }
            set { _actualCost = value; }
        }

        /// <summary>
        /// Variable <c>_actualRange</c> is declared in <c>TowerOverlay</c>, but defined by the subclasses
        /// </summary>
        private float _actualRange;

        /// <summary>
        /// Getters and Setters <c>ActualRange</c> for <c>_actualRange</c>
        /// </summary>
        public float ActualRange
        {
            get { return _actualRange; }
            set { _actualRange = value; }
        }

        ///<summary>
        ///Function <c>OnDrawGizmosSelected()</c> Draws circle Sphere around the Tower to marks up the Range (in scene View only)
        ///</summary>
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, ActualRange);
        }

        public void Chosen()
        {
            //TODO
            //Radius anzeigen hier einf�gen
            OnDrawGizmosSelected();


            ///if Stage could be upgraded -> set UpdateButton true
            if (ActualStage == "BasicStageOne" || ActualStage == "BasicStageTwo" ||
                ActualStage == "IceStageOne"   || ActualStage == "IceStageTwo" ||
                ActualStage == "FireStageOne"  || ActualStage == "FireStageTwo")
            { gameObject.transform.Find("UpgradeButton").gameObject.SetActive(true); }

            Debug.Log("Tower selected");
        }


        public void StageUpgrade()
        {

            Debug.Log("Stage des Turms: " + ActualStage);

            switch (ActualStage)
            {
                ///Basictower
                case "BasicStageOne":
                    ///if money = enough

                    Debug.Log("actual coins: " + _gameManager.Coins);
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<BasicTower1>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage1").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(true);
                    }
                    else
                    { Debug.Log("not enough gold"); }
                    break;
                ///
                case "IceStageOne":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<IceTower1>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage1").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(true);
                    }
                    else
                    { Debug.Log("not enough gold"); }
                    break;
                case "FireStageOne":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<FireTower1>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage1").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(true);
                    }
                    else
                    { Debug.Log("not enough gold"); }
                    gameObject.GetComponent<FireTower1>().Upgrade();
                    break;
                case "BasicStageTwo":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<BasicTower2>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage3").gameObject.SetActive(true);
                    }
                    else
                    { Debug.Log("not enough gold"); }
                    break;
                case "IceStageTwo":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<IceTower2>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage3").gameObject.SetActive(true);
                    }
                    else
                    { Debug.Log("not enough gold"); }
                    break;
                case "FireStageTwo":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<FireTower2>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage3").gameObject.SetActive(true);
                    }
                    else
                    { Debug.Log("not enough gold"); }
                    break;

                default:
                    return;
            }

            gameObject.transform.Find("UpgradeButton").gameObject.SetActive(false);

        }

    }
}