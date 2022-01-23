using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitManuPanel : MonoBehaviour
{
    
    private GameManager _gameManager;
    
    private void Start() {
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Methode <c> BackToMain </c> ermoeglicht den Wechsel aus der Spielszene zurueck in die Hauptmenue Szene
    /// </summary>
    public void BackToMain() {
        _gameManager.PauseGame();
        SceneManager.LoadScene(1);
    }
}
