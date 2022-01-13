using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public GameObject TowerPrefab;

    private GameManager _gameManager;

    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgeführt wird
    /// </summary>
    private void Start() {
        _gameManager = GameManager.GetInstance();

        // TODO DISPLAY COINS AND LIVES ausprobieren wie man darauf zugreift!
        Debug.Log("");
    }

    /// <summary>
    /// Methode die jedes Frame aufgerufen wird, während das Skript läuft
    /// </summary>
    public void Update()
    {
        if(_gameManager.Lives <= 0) {
            _gameManager.PauseGame();
            // TODO GAME OVER!!!
        }
        
        if(_gameManager.LastEnemyKilled) {
            _gameManager.PauseGame();
            // TODO WIN !!!!
            CalculateAndSaveStars();
            UnlockNextLevel();
        }


        // TODO DISPLAY COINS AND LIVES
        // _gameManager.Coins;  Zugriff für LevelManager ermöglichen
        // _gameManager.Lives;
    }

    /// <summary>
    /// Methode <c> BackToMain </c> ermöglicht den Wechsel aus der Spielszene zurück in die Hauptmenü Szene
    /// </summary>
    public void BackToMain()
    {
        _gameManager.PauseGame();
        SceneManager.LoadScene(1);
    }

    // TODO implement function call
    /// <summary>
    /// Pausiert oder setzt das Spiel fort
    /// </summary>
    public void PauseButtonClick() {
        if(_gameManager.Paused) {
            _gameManager.StartGame();
        } else {
            _gameManager.PauseGame();
        }
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

    
    /// <summary>
    /// Schaut wie viele Leben noch uebrig sind und speichert entsprechende Sterne, falls bis jetzt nur schlechter
    /// im Level
    /// </summary>
    private void CalculateAndSaveStars() {
        if(_gameManager.Level.Stars <= 0) {
            _gameManager.Level.Stars = 1;
        }
        
        if(_gameManager.Lives > 50 && _gameManager.Level.Stars <= 1) {
            _gameManager.Level.Stars = 2;
        }

        if(_gameManager.Lives > 95 && _gameManager.Level.Stars <= 2) {
            _gameManager.Level.Stars = 3;
        }
    }

    /// <summary>
    /// Unlocked das naechste Level, falls vorhanden
    /// </summary>
    private void UnlockNextLevel() {
        LevelManager levelManager = LevelManager.GetInstance();
        for(int i = 0; i < levelManager.Levels.Count; i++) {
            if(_gameManager.Level == levelManager.Levels[i]) {
                if((i+1) < levelManager.Levels.Count) {
                    levelManager.Levels[i + 1].Unlocked = true;
                    break;
                }
            }
        }
    }
}