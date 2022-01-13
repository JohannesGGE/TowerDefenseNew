using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drop : MonoBehaviour, IDropHandler
{
    
        
    public GameObject Tower;
    
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

            // TODO eventData.pointerDrag.name als Entscheidung für prefab
            GameObject newT = Instantiate(Tower, GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, FolderToBuild);
            newT.transform.position = GetComponent<RectTransform>().transform.position;

            isTower = true;
        }
    }
}
