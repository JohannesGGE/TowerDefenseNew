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

        private bool _selected = false;
        /// <summary>
        /// Variable <c>_selected</c> checks if the Tower was clicked on
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            protected set { _selected = value; }
        }

        /// <summary>
        /// Methode die jedes Frame aufgerufen wird, waehrend das Skript laeuft
        /// </summary>
        public void Update()
        {
            ///mit Rechtsklick irgendwohin klicken verschwindet das Tower Overlay wieder
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                TowerOverlay[] allTower = FindObjectsOfType<TowerOverlay>();
                for (int i = 0; i < allTower.Length; i++)
                {
                    allTower[i].Selected = false;
                    allTower[i].transform.Find("UpgradeButton").gameObject.SetActive(false);
                    allTower[i].transform.Find("RangeCircle").gameObject.SetActive(false);
                }
            }
        }

        /// <summary>
        /// Methode die ausgefuehrt wird, wenn ein Tower angeklickt wird
        /// </summary>
        public void Chosen()
        {
            ///TowerOverlay wird auf nicht ausgewählten Kakteen deaktiviert        
            TowerOverlay [] allTower = FindObjectsOfType<TowerOverlay>();
            for (int i = 0; i < allTower.Length; i++)
            { 
                allTower[i].Selected = false;
                allTower[i].transform.Find("UpgradeButton").gameObject.SetActive(false);
                allTower[i].transform.Find("RangeCircle").gameObject.SetActive(false); 
            }

            this.Selected = true;
            
            if (Selected)
            {
                if (ActualStage == "BasicStageOne" || ActualStage == "BasicStageTwo" ||
                    ActualStage == "IceStageOne"   || ActualStage == "IceStageTwo" ||
                    ActualStage == "FireStageOne"  || ActualStage == "FireStageTwo")
                { gameObject.transform.Find("UpgradeButton").gameObject.SetActive(true); }

                ShowRange(Selected);
            }
        }


        /// <summary>
        /// Methode, die die Range eines Towers anzeigt
        /// </summary>
        /// <param name="Selected"></param>
        public void ShowRange(bool Selected)
        {
            if (Selected)
            {
                gameObject.transform.Find("RangeCircle").gameObject.SetActive(true);
                gameObject.transform.Find("RangeCircle").gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _actualRange*2);
                gameObject.transform.Find("RangeCircle").gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _actualRange*2);
                gameObject.transform.Find("RangeCircle").gameObject.GetComponent<RectTransform>().ForceUpdateRectTransforms();
                Debug.Log("Range should appear");
            }
        }

        /// <summary>
        /// Methode, die ausgeführt wird, wenn nicht mehr genug Geld vorhanden ist
        /// </summary>
        private IEnumerator NotEnoughMoney()
        {
            GameObject _popup;
            Transform OverlayFolder = GameObject.Find("KeinGeldPopup").transform;
            _popup = Instantiate(Resources.Load("TowerPrefabs/NotEnoughMoney") as GameObject, OverlayFolder);

            yield return new WaitForSecondsRealtime(2);

            Destroy(_popup);
        }

        /// <summary>
        /// Methode, die ausgefuehrt wird, wenn ein Tower upgegraded wird
        /// </summary>
        public void StageUpgrade()
        {
            switch (ActualStage)
            {
                ///Stage One
                case "BasicStageOne":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<BasicTower1>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage1").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(NotEnoughMoney());
                    }
                    break;
                case "IceStageOne":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<IceTower1>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage1").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(NotEnoughMoney());
                    }
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
                    {
                        StartCoroutine(NotEnoughMoney());
                    }
                    break;
                ///StageTwo
                case "BasicStageTwo":
                    if (_gameManager.Coins >= ActualCost)
                    {
                        gameObject.GetComponent<BasicTower2>().Upgrade();
                        _gameManager.ReduceCoins(ActualCost);
                        gameObject.transform.Find("TowerStage2").gameObject.SetActive(false);
                        gameObject.transform.Find("TowerStage3").gameObject.SetActive(true);
                    }
                    else
                    {
                        StartCoroutine(NotEnoughMoney());
                    }
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
                    {
                        StartCoroutine(NotEnoughMoney());
                    }
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
                    {
                        StartCoroutine(NotEnoughMoney());
                    }
                    break;

                default:
                    Debug.Log("this should never happen");
                    break;
            }

            gameObject.transform.Find("UpgradeButton").gameObject.SetActive(false);
            gameObject.transform.Find("RangeCircle").gameObject.SetActive(false);
            Selected = false;
        }
    }
}
