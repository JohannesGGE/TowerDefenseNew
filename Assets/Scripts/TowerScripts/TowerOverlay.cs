using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Backbone
{

    public class TowerOverlay : Tower
    {

        public string ActualStage;

        private GameManager _gameManager;

        public TowerOverlay()
        {
            _gameManager = GameManager.GetInstance();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Chosen()
        {
            //TODO
            //Radius anzeigen hier einfügen

            ///Upgrade Button wird aktiv gesetzt, wenn Turm ausgewählt wurde
            //TODO
            //if Upgrade possible/enough Money -> gameObject.transform.GetChild(1).gameObject.SetActive(true);
            
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log("Turm ausgewählt");
        }


        public void StageUpgrade()
        {
            //gameObject.GetComponent<BasicTower1>().Stage


            Debug.Log("Stage des Turms: " + ActualStage);

            switch (ActualStage)
            {
                case "BasicStageOne":
                    ///if money = enough
                    Debug.Log("actuel coins: " +_gameManager.Coins);
                    if (_gameManager.Coins >= 10)
                    { gameObject.GetComponent<BasicTower1>().Upgrade();
                        _gameManager.ReduceCoins(10);
                    }
                    else
                    { Debug.Log("nicht genug geld"); }
                    break;
                    ///
                case "IceStageOne":
                    gameObject.GetComponent<IceTower1>().Upgrade();
                    break;
                case "FireStageOne":
                    gameObject.GetComponent<FireTower1>().Upgrade();
                    break;
                case "BasicStageTwo":
                    gameObject.GetComponent<BasicTower2>().Upgrade();
                    break;
                case "IceStageTwo":
                    gameObject.GetComponent<IceTower2>().Upgrade();
                    break;
                case "FireStageTwo":
                    gameObject.GetComponent<FireTower2>().Upgrade();
                    break;
                default:
                    gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    Debug.Log("KeinUpgradeMöglich");
                    return;
            }

            gameObject.transform.GetChild(1).gameObject.SetActive(false);

        }
    }
}