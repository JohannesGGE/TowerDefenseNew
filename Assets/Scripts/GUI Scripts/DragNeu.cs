using System.Collections;
using System.Collections.Generic;
using Backbone;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

using Classes;

public class DragNeu : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{

    public bool isDragged = false;

    private Transform PlacedTowerFolder;
    private Transform OverlayFolder;

    public GameObject Tower;
    public GameObject Circle;

    //temporaere Variable, um die Groesseneigenschaften eines Objektes anzusprechen
    private RectTransform _rectTransform;
    private RectTransform _rectTransform2;

    private GameObject towerDrag;
    private GameObject circleDrag;

    GameManager _gameManager;
    private bool buildable;

    private GameObject _popup;



    


    public void Start()
    {
        _gameManager = GameManager.GetInstance();
        
        OverlayFolder = GameObject.Find("KeinGeldPopup").transform;
       

    }

    public void Update()
    {

    }

    /// <summary>
    /// Methode die ausgef�hrt wird, wenn der Drag eines Objektes beginnt
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        PlacedTowerFolder = gameObject.transform.Find("TowerImage");

        buildable = false;

        switch (eventData.pointerDrag.name)
        {
            case "Green":
                if (_gameManager.Coins >= GameValues.PriceBasicTower)
                { buildable = true; }
                else
                {
                    _popup = Instantiate(Resources.Load("TowerPrefabs/NotEnoughMoney") as GameObject, OverlayFolder);   
                    Debug.Log("zu wenig money"); 
                }
                break;
            case "Red":
                if (_gameManager.Coins >= GameValues.PriceFireTower)
                { buildable = true; }
                else
                {
                    _popup = Instantiate(Resources.Load("TowerPrefabs/NotEnoughMoney") as GameObject, OverlayFolder);
                    Debug.Log("zu wenig money");
                }
                break;
            case "Blue":
                if (_gameManager.Coins >= GameValues.PriceIceTower)
                { buildable = true; }
                else
                {
                    _popup = Instantiate(Resources.Load("TowerPrefabs/NotEnoughMoney") as GameObject, OverlayFolder);
                    Debug.Log("zu wenig money");
                }
                break;
            default:
                break;
        }

        if (buildable)
        {
            Vector3 mousePosition = Input.mousePosition;
            circleDrag = Instantiate(Circle, mousePosition, Quaternion.identity, PlacedTowerFolder);
            towerDrag = Instantiate(Tower, mousePosition, Quaternion.identity, PlacedTowerFolder);
            _rectTransform2 = circleDrag.GetComponent<RectTransform>();
            _rectTransform = towerDrag.GetComponent<RectTransform>();

            Debug.Log("OnBeginDrag");

            this.isDragged = true;
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
            Destroy(_popup);
            Debug.Log("OnEndDrag");

            GameObject.Find($"Tower Slot {(int)Input.mousePosition.x / 120} {(int)Input.mousePosition.y / 120}").GetComponent<Drop>().SetIsGrass(false);
            this.isDragged = false;
        }
    }
}
