using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerTobi : Singleton<LevelManagerTobi>
{
    [SerializeField]
    private GameObject _towerSlot;

    public GameObject TowerSlot
    {
        get { return _towerSlot; }
    }

    public Dictionary<Point, TileScript>Slots { get; set; }


    //Breite des Slots
    public float SlotSize
    {
        get { return 100; } //SlotSize.GetComponent<SpriteRenderer>().sprite.bounds.size.x
    }

    public Transform FolderToBuild;

    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgeführt wird
    /// </summary>
    void Start()
    {
        CreateLevel();
    }

    /// <summary>
    /// Methode die jedes Frame aufgerufen wird, während das Skript läuft
    /// </summary>
    void Update()
    {
        
    }

    /// <summary>
    /// Methode, die eine Art Map erstellt, um darauf Tower platzieren zu können
    /// </summary>
    private void CreateLevel()
    {
        //Vector3 SlotStart = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height));
        Vector3 SlotStart = new Vector3(50, 950, 0);

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 16; x++)
            {
                PlaceSlot(x, y, SlotStart);
            }
        }
    }

    private void PlaceSlot(int x, int y, Vector3 SlotStart )
    { 
        GameObject NewSlot = Instantiate(_towerSlot, FolderToBuild);
        NewSlot.transform.position = new Vector3(SlotStart.x + (SlotSize * x), SlotStart.y - (SlotSize * y), 0);
    }
}
