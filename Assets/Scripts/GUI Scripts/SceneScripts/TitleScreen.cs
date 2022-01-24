using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {
    
    private LevelManager _levelManager;

    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgefuehrt wird
    /// </summary>
    void Start() {
        _levelManager = LevelManager.GetInstance();
        _levelManager.LoadLevelStatus();
        _levelManager.LoadSettings();
    }
    
    /// <summary>
    /// Oeffnet bei Interaktion (Klick auf Button) das Hauptmenue
    /// </summary>
    public void OpenMain()
    {
        SceneManager.LoadScene(1);
    }
}