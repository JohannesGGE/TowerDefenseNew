using System.Collections;
using System.Collections.Generic;
using Backbone;
using UnityEngine;
using UnityEngine.EventSystems;

using Classes;

public class DragNeu : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    private Transform FolderToBuild;

    public GameObject Tower;
    public GameObject Circle;

    //temporaere Variable, um die Groesseneigenschaften eines Objektes anzusprechen
    private RectTransform _rectTransform;
    private RectTransform _rectTransform2;

    private GameObject towerDrag;
    private GameObject circleDrag;

    GameManager _gameManager;
    private bool buildable;

    public void Start()
    {
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Methode die ausgef�hrt wird, wenn der Drag eines Objektes beginnt
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        FolderToBuild = gameObject.transform.Find("TowerImage");
        buildable = false;

        switch (eventData.pointerDrag.name)
        {
            case "Green":
                if (_gameManager.Coins >= GameValues.PriceBasicTower)
                { buildable = true; }
                else
                //TODO in GUI sichtbar ausgeben, dass zu wenig Geld da ist.
                { Debug.Log("zu wenig money"); }
                break;
            case "Red":
                if (_gameManager.Coins >= GameValues.PriceFireTower)
                { buildable = true; }
                else
                //TODO in GUI sichtbar ausgeben, dass zu wenig Geld da ist.
                { Debug.Log("zu wenig money"); }
                break;
            case "Blue":
                if (_gameManager.Coins >= GameValues.PriceIceTower)
                { buildable = true; }
                else
                //TODO in GUI sichtbar ausgeben, dass zu wenig Geld da ist.
                { Debug.Log("zu wenig money"); }
                break;
            default:
                break;
        }

        if (buildable)
        {
            Vector3 mousePosition = Input.mousePosition;
            circleDrag = Instantiate(Circle, mousePosition, Quaternion.identity, FolderToBuild);
            towerDrag = Instantiate(Tower, mousePosition, Quaternion.identity, FolderToBuild);
            _rectTransform2 = circleDrag.GetComponent<RectTransform>();
            _rectTransform = towerDrag.GetComponent<RectTransform>();

            Debug.Log("OnBeginDrag");
        }
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn der Drag eines Objektes stattfindet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData != null)
        {
            _rectTransform2.anchoredPosition += eventData.delta;
            _rectTransform.anchoredPosition += eventData.delta;
            Debug.Log("OnDrag");
        }
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn der Drag eines Objektes endet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData != null)
        {
            Destroy(towerDrag);
            Destroy(circleDrag);
            Debug.Log("OnEndDrag");


            /////////////////////////
            GameObject.Find($"Tower Slot {(int)Input.mousePosition.x / 120} {(int)Input.mousePosition.y / 120}").GetComponent<Drop>().SetIsGrass(false);
        }
    }
}
