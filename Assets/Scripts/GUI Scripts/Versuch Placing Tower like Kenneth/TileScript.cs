using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    
    public Point GridPosition { get; private set; }
    
    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2 (transform.position.x + LevelManagerTobi.Instance.SlotSize, transform.position.y - LevelManagerTobi.Instance.SlotSize);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Point gridPos, Vector3 worldPos, Transform parent)
    {
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManagerTobi.Instance.Slots.Add(gridPos, this);

        //set the TilePosition inside the Levelmanager
    }

    public void OnMouseOver()
    {
        Debug.Log("TilePosition: " + GameObject.FindObjectOfType<RectTransform>().position);
    }
}
