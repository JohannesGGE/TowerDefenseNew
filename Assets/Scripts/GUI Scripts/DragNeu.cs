using System.Collections;
using System.Collections.Generic;
using Backbone;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

using Classes;

public class DragNeu : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GameManager _gameManager;

    ///temporaere Variable, um die Groesseneigenschaften eines Objektes anzusprechen
    private RectTransform _rectTransform;
    private RectTransform _rectTransform2;

    /// Ordner, in welchem das Objekt erzeugt werden soll
    private Transform PlacedTowerFolder;
    private Transform OverlayFolder;

    /// Objekte welche erzeugt werden sollen beim drag
    public GameObject Tower;
    public GameObject Circle;

    /// temporaere Objekte um die Images während des Draggs anzuzeigen
    private GameObject _towerDrag;
    private GameObject _circleDrag;

    public bool isDragged = false;

    public static bool _buildable;



    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgefuehrt wird
    /// </summary>
    public void Start()
    {
        _gameManager = GameManager.GetInstance();     
    }

    private IEnumerator NotEnoughMoney()
    {
        GameObject _popup;
        Transform OverlayFolder = GameObject.Find("KeinGeldPopup").transform;
        _popup = Instantiate(Resources.Load("TowerPrefabs/NotEnoughMoney") as GameObject, OverlayFolder);

        yield return new WaitForSecondsRealtime(2);

        Destroy(_popup);
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn der Drag eines Objektes beginnt
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        PlacedTowerFolder = gameObject.transform.Find("TowerImage");

        _buildable = false;

        switch (eventData.pointerDrag.name)
        {
            case "Green":
                if (_gameManager.Coins >= GameValues.PriceBasicTower)
                { _buildable = true; }
                else
                { StartCoroutine(NotEnoughMoney()); }
                break;
            case "Red":
                if (_gameManager.Coins >= GameValues.PriceFireTower)
                { _buildable = true; }
                else
                { StartCoroutine(NotEnoughMoney()); }
                break;
            case "Blue":
                if (_gameManager.Coins >= GameValues.PriceIceTower)
                { _buildable = true; }
                else
                { StartCoroutine(NotEnoughMoney()); }
                break;
            default:
                break;
        }

        if (_buildable)
        {
            Vector3 mousePosition = Input.mousePosition;
            _circleDrag = Instantiate(Circle, mousePosition, Quaternion.identity, PlacedTowerFolder);
            _towerDrag = Instantiate(Tower, mousePosition, Quaternion.identity, PlacedTowerFolder);
            _rectTransform2 = _circleDrag.GetComponent<RectTransform>();
            _rectTransform = _towerDrag.GetComponent<RectTransform>();

            this.isDragged = true;
        }
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn der Drag eines Objektes stattfindet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrag(PointerEventData eventData)
    {
        if (_buildable)
        {
            _rectTransform2.anchoredPosition += eventData.delta;
            _rectTransform.anchoredPosition += eventData.delta;
        }
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn der Drag eines Objektes endet
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (_buildable)
        {
            Destroy(_towerDrag);
            Destroy(_circleDrag);

            this.isDragged = false;
        }
        GameObject.Find($"Tower Slot {(int)Input.mousePosition.x / 120} {(int)Input.mousePosition.y / 120}").GetComponent<Drop>().SetIsGrass(false);
    }
}
