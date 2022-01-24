using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Drop : MonoBehaviour, IDropHandler, IPointerExitHandler, IPointerEnterHandler
{
    private GameManager _gameManager;

    [SerializeField] 
    private GameObject _highlightGreen;

    [SerializeField] 
    private GameObject _highlightRed;

    private GameObject _tower;

    private Transform _folderToBuild;

    private bool _over;

    private bool _isGrass = true;

    private bool _isTower = false;

    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgefuehrt wird
    /// </summary>
    private void Start()
    {
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Methode die ausgefuehrt wird, wenn ein Objekt losgelassen wird/gedropped wird nach Drag
    /// </summary>
    /// <param name="eventData"> Objekt welches gedraggt wird </param>
    public void OnDrop(PointerEventData eventData) {

        if (DragNeu._buildable == true)
        {
            _folderToBuild = gameObject.transform.GetChild(0);

            if (CompareTag("TowerSlot") && !_isTower && _isGrass)
            {
                Debug.Log("Ausgewählter Kaktus: " + eventData.pointerDrag.name);

                /// Ueberpruefung welche Farbe der gedraggte Kaktus hat + abrufen des Tower Objekts aus dem Resources Ordner
                switch (eventData.pointerDrag.name)
                {
                    case "Red":
                        _tower = Resources.Load("TowerPrefabs/TowerRed") as GameObject;
                        _gameManager.ReduceCoins(GameValues.PriceFireTower);
                        break;
                    case "Green":
                        _tower = Resources.Load("TowerPrefabs/TowerGreen") as GameObject;
                        _gameManager.ReduceCoins(GameValues.PriceBasicTower);
                        break;
                    case "Blue":
                        _tower = Resources.Load("TowerPrefabs/TowerBlue") as GameObject;
                        _gameManager.ReduceCoins(GameValues.PriceIceTower);
                        break;
                }
                ///Kaktus wird platziert
                GameObject newT = Instantiate(_tower, GetComponent<RectTransform>().anchoredPosition, Quaternion.identity, _folderToBuild);
                newT.transform.position = GetComponent<RectTransform>().transform.position;

                _isTower = true;
            }
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        _over = true;
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        _over = false;
    }

    private void OnPointOver()
    {
        if (_isGrass)
        {
            this._highlightGreen.SetActive(true);
        }
        else
        {
            this._highlightRed.SetActive(true);
        }
    }

    public void ResetHighlight()
    {
        this._highlightGreen.SetActive(false);
        this._highlightRed.SetActive(false);
    }

    void Update()
    {
        if (_over && (GameObject.Find("Green").GetComponent<DragNeu>().isDragged
            || GameObject.Find("Red").GetComponent<DragNeu>().isDragged
            || GameObject.Find("Blue").GetComponent<DragNeu>().isDragged))
        {
            this.OnPointOver();
        }
        else
        {
            this.ResetHighlight();
        }
    }

    public void SetIsGrass(bool value)
    {
        this._isGrass = value;
    }
}
