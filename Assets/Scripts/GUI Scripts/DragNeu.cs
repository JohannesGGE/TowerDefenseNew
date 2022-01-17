using System.Collections;
using System.Collections.Generic;
using Backbone;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNeu : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //temporaere Variable, um die Groesseneigenschaften eines Objektes anzusprechen
    private RectTransform _rectTransform;

    public GameObject Tower;
    public Transform FolderToBuild;
   
    private GameObject towerDrag;

    /// <summary>
    /// Methode die ausgef�hrt wird, wenn der Drag eines Objektes beginnt
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = Input.mousePosition;
        towerDrag = Instantiate(Tower, mousePosition, Quaternion.identity, FolderToBuild);
        
        _rectTransform = towerDrag.GetComponent<RectTransform>();

        ///funktioniert eigentlich, platziertes Objekt hat dann aber trotzdem kein aktiviertes Skript
        //towerDrag.GetComponent<FireTower1>().enabled = false;
        //towerDrag.GetComponent<BasicTower1>().enabled = false;
        //towerDrag.GetComponent<IceTower1>().enabled = false;
        //Debug.Log("Script: " + towerDrag.GetComponent<FireTower1>().enabled);


        Debug.Log("OnBeginDrag");

    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn der Drag eines Objektes stattfindet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta;
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn der Drag eines Objektes endet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnEndDrag(PointerEventData eventData)
    {
        ///funktioniert eigentlich, platziertes Objekt hat dann aber trotzdem kein aktiviertes Skript
        //towerDrag.GetComponent<FireTower1>().enabled = true;
        //towerDrag.GetComponent<BasicTower1>().enabled = true;
        //towerDrag.GetComponent<IceTower1>().enabled = true;
        //Debug.Log("Script: " + towerDrag.GetComponent<FireTower1>().enabled);


        Destroy(towerDrag);   
        Debug.Log("OnEndDrag");
    }

}
