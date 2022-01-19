using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class LevelMenu : MonoBehaviour
{
    public Sprite[] playPauseButtonSprites; // 0: play , 1: Pause
    public Sprite[] doubleButtonSprites; // 0: inactive, 1: active 
    
    private GameManager _gameManager;

    private TextMeshProUGUI _live;
    private TextMeshProUGUI _money;

    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgef�hrt wird
    /// </summary>
    private void Start() {
        _gameManager = GameManager.GetInstance();

        //TextObjekt für Live und Money wird Wert(String) zugewiesen
        _live = GameObject.FindWithTag("Life").GetComponent<TextMeshProUGUI>();
        _money = GameObject.FindWithTag("Money").GetComponent<TextMeshProUGUI>();


        Button playPauseButton = GameObject.FindGameObjectWithTag("PlayPauseButton").GetComponent<Button>();
        Button fastForwardButton = GameObject.FindGameObjectWithTag("FastForwardButton").GetComponent<Button>();

        if(_gameManager.Paused) {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
        } else {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[1]; // pauseImage
        }

        if(_gameManager.DoubleSpeed) {
            fastForwardButton.image.overrideSprite = doubleButtonSprites[1]; // active
        } else {
            fastForwardButton.image.overrideSprite = doubleButtonSprites[0]; // inactive
        }       
    }

    /// <summary>
    /// Methode die jedes Frame aufgerufen wird, w�hrend das Skript l�uft
    /// </summary>
    public void Update()
    {
        _live.text = _gameManager.Lives.ToString();
        _money.text = _gameManager.Coins.ToString();
  

        //Defeat Overlay wird aufgerufen wenn Leben auf 0 fallen
        if (_gameManager.Lives <= 0) {
            _gameManager.PauseGame();
            DefeatOverlay();
        }
        
        if(_gameManager.LastEnemyKilled) {
            //_gameManager.PauseGame();     //kann man eventuell rauslassen, da eh alle Vögel durch sind. Dann freezed das Spiel auch nicht
            CalculateAndSaveStars();
            UnlockNextLevel();
            WinOverlay();
        }

    }

    /// <summary>
    /// Methode <c> BackToMain </c> erm�glicht den Wechsel aus der Spielszene zur�ck in die Hauptmen� Szene
    /// </summary>
    public void BackToMain()
    {
        _gameManager.PauseGame();
        SceneManager.LoadScene(1);
    }


    /// <summary>
    /// Defeat Overlay wird aktiviert, wenn Leben auf 0 fallen
    /// </summary>
    private void DefeatOverlay()
    {
        GameObject DefeatMenu = gameObject.transform.Find("DefeatMenu").gameObject; //->funktioniert mit Fehlermeldung im Log
        DefeatMenu.SetActive(true);
    }

    /// <summary>
    /// Win Overlay wird aufgerufen, wenn kein Vogel mehr kommt und Leben über 0 sind
    /// </summary>
    private void WinOverlay()
    {
        //string StarRoot = "Stars/" + _gameManager.Level.Stars.ToString();
        //Stars.image = Resources.Load(StarRoot) as Image;
        
        GameObject WinMenu = gameObject.transform.Find("WinMenu").gameObject;
        WinMenu.SetActive(true);
    }








    /// <summary>
    /// Methode <c> ReloadLevel </c> macht das was sie sagt, sie lädt das Level erneut
    /// </summary>
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Pausiert oder setzt das Spiel fort
    /// </summary>
    public void Pause_PlayButtonClick() {
        Button playPauseButton = GameObject.FindGameObjectWithTag("PlayPauseButton").GetComponent<Button>();
        Button fastForwardButton = GameObject.FindGameObjectWithTag("FastForwardButton").GetComponent<Button>();

        if(_gameManager.DoubleSpeed) {
            _gameManager.StartGame();
            playPauseButton.image.overrideSprite = playPauseButtonSprites[1]; // pauseImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[0]; // inactive
        } else if(!_gameManager.Paused) {
            _gameManager.PauseGame();
            playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
        } else if(_gameManager.Paused) {
            _gameManager.StartGame();
            playPauseButton.image.overrideSprite = playPauseButtonSprites[1]; // pauseImage
        }
    }
    
    /// <summary>
    /// Verdoppelt die Geschwindigkeit im Spiel
    /// </summary>
    public void DoubleButtonClick() {
        Button playPauseButton = GameObject.FindGameObjectWithTag("PlayPauseButton").GetComponent<Button>();
        Button fastForwardButton = GameObject.FindGameObjectWithTag("FastForwardButton").GetComponent<Button>();
        
        if(_gameManager.DoubleSpeed) {
            _gameManager.StartGame();
            playPauseButton.image.overrideSprite = playPauseButtonSprites[1]; // pauseImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[0]; // inactive
        } else if(_gameManager.Paused) {
            _gameManager.DoubleGame();
            // playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[1]; // active
        } else if(!_gameManager.Paused) {
            _gameManager.DoubleGame();
            playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[1]; // active
        }
    }

    
    /// <summary>
    /// Schaut wie viele Leben noch uebrig sind und speichert entsprechende Sterne, falls bis jetzt nur schlechter
    /// im Level
    /// </summary>
    private void CalculateAndSaveStars() {
        if(_gameManager.Level.Stars <= GameValues.LivesToGet1Star) {
            _gameManager.Level.Stars = 1;
        }
        
        if(_gameManager.Lives > GameValues.LivesToGet2Star && _gameManager.Level.Stars <= 1) {
            _gameManager.Level.Stars = 2;
        }

        if(_gameManager.Lives >= GameValues.LivesToGet3Star && _gameManager.Level.Stars <= 2) {
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