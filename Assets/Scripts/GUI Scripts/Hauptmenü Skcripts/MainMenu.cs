using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() {
        LevelManager levelManager = LevelManager.GetInstance();
        levelManager.LoadLevelStatus();
    }


    /// <summary>
    /// öffnet bei Interaktion (Klick auf Button) das Hauptmenü
    /// </summary>
    /**
    public void OpenMain()
    {
        SceneManager.LoadScene(1);
        //** alternativer Aufruf der Szene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    */

    

    /// <summary>
    /// beendet bei Interaktion (Klick auf Button) das Spiel
    /// </summary>
    public void QuitGame()
    {
        //Debug.Log("Quit Game");
        LevelManager levelManager = LevelManager.GetInstance();
        levelManager.SaveLevelStatus();
        Application.Quit();
    }
}
