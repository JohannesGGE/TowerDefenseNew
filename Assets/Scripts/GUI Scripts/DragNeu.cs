using System.Collections;
using System.Collections.Generic;
using Backbone;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNeu : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //tempor�re Variable, um die Gr��eneigenschaften eines Objektes anzusprechen
    private RectTransform _rectTransform;



    //tempor�re Variable, um die CanvasGroup Eigenschaft eines Objektes anzusprechen
    private CanvasGroup _canvasGroup;


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
        _canvasGroup = towerDrag.GetComponent<CanvasGroup>();   
        
        Debug.Log("OnBeginDrag");
        // kA, was das macht
        // _canvasGroup.alpha = .6f;
        // _canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// Methode die ausgef�hrt wird, wenn der Drag eines Objektes stattfindet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta;
    }

    /// <summary>
    /// Methode die ausgef�hrt wird, wenn der Drag eines Objektes endet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(towerDrag);
        Debug.Log("OnEndDrag");
        //_canvasGroup.alpha = 1f;
        //_canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }
}
