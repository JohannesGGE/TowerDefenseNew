using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    public GameObject Tower;
    public Transform FolderToBuild;

    public void InstantiateObject()
    {
        Vector2 spawn = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Debug.Log("spawnPosition: " + gameObject.transform.position.x + gameObject.transform.position.y);
        Instantiate(Tower, new Vector3(spawn.x, spawn.y + 250, 0), Quaternion.identity, FolderToBuild);
     
     // alternatives instanziieren
        //GameObject tmp = Instantiate(tower, createPlace, false);
        //tmp.gameObject.transform.position = createPlace.position;
    }
}
