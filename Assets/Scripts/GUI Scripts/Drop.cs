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
    /// Methode die ausgefuehrt wird, wenn ein Objekt losgelassen wird, nach Drag
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrop(PointerEventData eventData) {

        //Tower werden im Slot platziert und können so angesprochen werden
        FolderToBuild = gameObject.transform.GetChild(0);
        
       

        Debug.Log("OnDrop");
        
        if(CompareTag("TowerSlot") && !isTower) {
            // TODO entscheiden, ob Genug Geld
            // mit eventData.pointerDrag.name kann man das Object bekommen, wo es hergezogen wurde

            Debug.Log("Ausgewählter Kaktus: " + eventData.pointerDrag.name);

            // Ueberpruefung welche Farbe der gedraggte Kaktus hat
            switch (eventData.pointerDrag.name) {
                case "Red":
                    _tower = Resources.Load("TowerPrefabs/TowerRed") as GameObject;
                    break;
                case "Green":
                    _tower = Resources.Load("TowerPrefabs/TowerGreen") as GameObject;
                    break;
                case "Yellow":
                    _tower = Resources.Load("TowerPrefabs/TowerBlue") as GameObject;
                    break;
            }

            //Kaktus wird platziert
            GameObject newT = Instantiate(_tower, GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, FolderToBuild);
            newT.transform.position = GetComponent<RectTransform>().transform.position;
            
            isTower = true;
        }
    }
}
