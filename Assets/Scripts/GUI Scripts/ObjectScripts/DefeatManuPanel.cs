using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatManuPanel : MonoBehaviour
{
    
    private GameManager _gameManager;
    private LevelManager _levelManager;
    
    private void Start() {
        _gameManager = GameManager.GetInstance();
        _levelManager = LevelManager.GetInstance();
    }

    /// <summary>
    /// Methode <c> BackToMain </c> ermoeglicht den Wechsel aus der Spielszene zurueck in die Hauptmenue Szene
    /// </summary>
    public void BackToMain() {
        _gameManager.PauseGame();
        SceneManager.LoadScene(1);
    }
    
    /// <summary>
    /// Methode <c> ReloadLevel </c> macht das was sie sagt, sie lädt das Level erneut
    /// </summary>
    public void ReloadLevel() {
        _gameManager.PrepareLevel(_levelManager.Levels[SceneManager.GetActiveScene().buildIndex - 2]);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
