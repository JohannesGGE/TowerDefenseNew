using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drop : MonoBehaviour, IDropHandler
{
    private GameObject _tower;
 
    private Transform FolderToBuild;
   
    private bool isTower = false;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn ein Objekt losgelassen wird, nach Drag
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrop(PointerEventData eventData) {

        if (eventData != null)
        { 
        //Tower werden im Slot platziert und können so angesprochen werden
        FolderToBuild = gameObject.transform.GetChild(0);
        
        Debug.Log("OnDrop");

            if (CompareTag("TowerSlot") && !isTower)
            {
                // TODO entscheiden, ob Genug Geld
                // mit eventData.pointerDrag.name kann man das Object bekommen, wo es hergezogen wurde

                Debug.Log("Ausgewählter Kaktus: " + eventData.pointerDrag.name);

                // Ueberpruefung welche Farbe der gedraggte Kaktus hat
                switch (eventData.pointerDrag.name)
                {
                    case "Red":
                        if (_gameManager.Coins >= GameValues.PriceFireTower)
                        {
                            _tower = Resources.Load("TowerPrefabs/TowerRed") as GameObject;
                            _gameManager.ReduceCoins(GameValues.PriceFireTower);
                        }
                        break;
                    case "Green":
                        if (_gameManager.Coins >= GameValues.PriceBasicTower)
                        {
                            _tower = Resources.Load("TowerPrefabs/TowerGreen") as GameObject;
                            _gameManager.ReduceCoins(GameValues.PriceBasicTower);
                        }
                        //else
                        //{ Debug.Log("zu wenig money"); }
                        break;
                    case "Blue":
                        if (_gameManager.Coins >= GameValues.PriceIceTower)
                        {
                            _tower = Resources.Load("TowerPrefabs/TowerBlue") as GameObject;
                            _gameManager.ReduceCoins(GameValues.PriceIceTower);
                        }
                        //else
                        //{ Debug.Log("zu wenig money"); }
                        break;
                }

                //Kaktus wird platziert
                GameObject newT = Instantiate(_tower, GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, FolderToBuild);
                newT.transform.position = GetComponent<RectTransform>().transform.position;

                isTower = true;
            }
        }
    }
}
