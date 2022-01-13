using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    //Objekt welches erzeugt werden soll, bei Button Click
    public GameObject Tower;

    //Ordner, in welchem das Objekt erzeugt werden soll
    public Transform FolderToBuild;

   

    /// <summary>
    /// Methode, die ein Turm Objekt erzeugt
    /// </summary>
    public void InstantiateObject()
    {
        Vector2 spawn = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        Debug.Log("spawnPosition: " + gameObject.transform.position.x + gameObject.transform.position.y);
        //Instanziieren des Kaktus
        GameObject tower =        Instantiate(Tower, new Vector3(spawn.x - 250, spawn.y, 0), Quaternion.identity, FolderToBuild);


        Debug.Log("Tower position: " + tower.GetComponent<Transform>().position);
        Debug.Log("rectTransform: " );

        // alternatives instanziieren
        //GameObject tmp = Instantiate(tower, createPlace, false);
        //tmp.gameObject.transform.position = createPlace.position;
    }


}
