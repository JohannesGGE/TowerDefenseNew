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
        Destroy(towerDrag);   
        Debug.Log("OnEndDrag");
    }
}
