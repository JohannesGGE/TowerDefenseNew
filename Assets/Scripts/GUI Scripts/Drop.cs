using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drop : MonoBehaviour, IDropHandler
{

    private GameObject _tower;
    
    private Transform FolderToBuild;

    private bool isTower = false;
    
    /// <summary>
    /// Methode die ausgef�hrt wird, wenn ein Objekt losgelassen wird, nach Drag
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrop(PointerEventData eventData) {
        FolderToBuild = GameObject.FindGameObjectsWithTag("PlacedTowerObject")[0].transform;
        
        Debug.Log("OnDrop");
        
        if(CompareTag("TowerSlot") && !isTower) {
            // TODO entscheiden, ob Genug Geld
            // mit eventData.pointerDrag.name kann man das Object bekommen, wo es hergezogen wurde


            Debug.Log("Ausgewählter Kaktus: " + eventData.pointerDrag.name);

            // Überprüfung welche Farbe der gedraggte Kaktus hat
            switch (eventData.pointerDrag.name) {
                case "Red":
                    _tower = Instantiate(Resources.Load("TowerRed", typeof(GameObject))) as GameObject;
                    break;
                case "Green":
                _tower = Instantiate(Resources.Load("TowerGreen", typeof(GameObject))) as GameObject;
                    break;
                case "Yellow":
                _tower = Instantiate(Resources.Load("TowerYellow", typeof(GameObject))) as GameObject;
                    break;
            }

            //Kaktus wird platziert
            GameObject newT = Instantiate(_tower, GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, FolderToBuild);
            newT.transform.position = GetComponent<RectTransform>().transform.position;

            isTower = true;
        }
    }
}