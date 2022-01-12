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

    public void OpenMain()
    {
        SceneManager.LoadScene(1);
        //** alternativer Aufruf der Szene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        //Debug.Log("Quit Game");
        LevelManager levelManager = LevelManager.GetInstance();
        levelManager.SaveLevelStatus();
        Application.Quit();
    }
}
