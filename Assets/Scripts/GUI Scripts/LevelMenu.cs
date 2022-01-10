using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    public GameObject TowerPrefab;

    public void Update()
    {
        /**
         * Überprüfung auf Win oder Lose
         * Variable Leben aus GameManager holen
        if (Leben < 1)
            { End Level -> Lost }

        Variable lastEnemyKilled aus GameManager holen!
        if (lastEnemyKilled == true && Leben > 0)
        { End level -> Win  }
        */
    }

    /// <summary>
    /// Methode <c> BackToMain </c> ermöglicht den wechsel aus der Spielszene zurück in die Hauptmenü Szene
    /// </summary>
    public void BackToMain()
    { 
        SceneManager.LoadScene(1);
    }





    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceTower();
        }
    }
    private void PlaceTower()
    {
        Debug.Log("Placing a tower");
        Instantiate(TowerPrefab, transform.position, Quaternion.identity);
    }
}