using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drop : MonoBehaviour, IDropHandler
{
    
    
    /// <summary>
    /// Methode die ausgeführt wird, wenn ein Objekt losgelassen wird, nach Drag
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
                
        if(eventData.pointerDrag)
        {
            Debug.Log("dropped at: " +eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }       
    }






    /// <summary>
    /// Methode, die ausgeführt wird, wenn die Maus über einem Objekt ist
    /// </summary>
    private void OnMouseOver()
    {

        Debug.Log("Maus befindet sich über: " + this.gameObject);
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
    }

    /// <summary>
    /// Methode, die überprüft, ob die Maus in den Bereich des Objekts eingetreten ist
    /// </summary>
    private void OnMouseEnter()
    {
        Debug.Log("Maus entered : " + this.gameObject);
    }

    /// <summary>
    /// Methode, die ein Turm Objekt erzeugt
    /// </summary>
    private void PlaceTower()
    {
        Debug.Log("Placing a tower");
        //Instantiate(LevelMenu.GameObject.TowerPrefab, transform.position, Quaternion.identity);
    }
}
