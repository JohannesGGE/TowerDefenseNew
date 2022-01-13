using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //temporäre Variable, um die Größeneigenschaften eines Objektes anzusprechen
    private RectTransform _rectTransform;



    //temporäre Variable, um die CanvasGroup Eigenschaft eines Objektes anzusprechen
    private CanvasGroup _canvasGroup;


    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgeführt wird
    /// </summary>
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();    
        _canvasGroup = GetComponent<CanvasGroup>();    
    }


    /// <summary>
    /// Methode die ausgeführt wird, wenn der Drag eines Objektes beginnt
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        _canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// Methode die ausgeführt wird, wenn der Drag eines Objektes stattfindet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        _rectTransform.anchoredPosition += eventData.delta;
    }

    /// <summary>
    /// Methode die ausgeführt wird, wenn der Drag eines Objektes endet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// Methode die ausgeführt wird, wenn mit der Maus geklickt wird
    /// </summary>
    /// <param name="eventData"> Objekt welches geklickt/param>
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        
    }
    
}
