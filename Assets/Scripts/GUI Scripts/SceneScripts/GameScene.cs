using System;
using System.Collections;
using Classes;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {
    public Sprite[] playPauseButtonSprites; // 0: play , 1: Pause
    public Sprite[] doubleButtonSprites; // 0: inactive, 1: active 

    public Sprite OneStar;
    public Sprite TwoStar;
    public Sprite ThreeStar;

    private GameManager _gameManager;
    private SoundManager _soundManager;

    private TextMeshProUGUI _live;
    private TextMeshProUGUI _money;

    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgefuehrt wird
    /// </summary>
    private void Start() {
        _gameManager = GameManager.GetInstance();

        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManager.StartGameBackground();

        //TextObjekt für Live und Money wird Wert(String) zugewiesen
        _live = GameObject.FindWithTag("Life").GetComponent<TextMeshProUGUI>();
        _money = GameObject.FindWithTag("Money").GetComponent<TextMeshProUGUI>();

        RefreshPlayPauseButtons();
    }

    /// <summary>
    /// Methode die jedes Frame aufgerufen wird, waehrend das Skript laeuft
    /// </summary>
    public void Update() {
        if(!_gameManager.Paused) {
            //Defeat Overlay wird aufgerufen wenn Leben auf 0 fallen
            if(_gameManager.Lives <= 0) {
                _gameManager.PauseGame();
                RefreshPlayPauseButtons();
                DefeatOverlay();
            }

            if(_gameManager.LastEnemyKilled) {
                _gameManager.PauseGame();
                RefreshPlayPauseButtons();
                CalculateAndSaveStars();
                UnlockNextLevel();
                WinOverlay();
            }
        }

        _live.text = _gameManager.Lives.ToString();
        _money.text = _gameManager.Coins.ToString();

        //Cheat für mehr geld
        if(Input.GetKeyDown(KeyCode.M)) {
            _gameManager.AddCoins(1000);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _gameManager.StartGame();
            RefreshPlayPauseButtons();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _gameManager.DoubleGame();
            RefreshPlayPauseButtons();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameManager.PauseGame();
            RefreshPlayPauseButtons();
        }
    }

    /// <summary>
    /// Defeat Overlay wird aktiviert, wenn Leben auf 0 fallen
    /// </summary>
    private void DefeatOverlay() {
        GameObject DefeatMenu =
            GameObject.FindWithTag("LevelCanvas").transform.Find("DefeatMenu")
                .gameObject; //->funktioniert mit Fehlermeldung im Log
        DefeatMenu.SetActive(true);
    }

    /// <summary>
    /// Win Overlay wird aufgerufen, wenn kein Vogel mehr kommt und Leben über 0 sind
    /// </summary>
    private void WinOverlay() {

        GameObject WinMenu = GameObject.FindWithTag("LevelCanvas").transform.Find("WinMenu").gameObject;

        //Sterne setzen

        switch(_gameManager.Level.Stars) {
            case 1:
                WinMenu.transform.Find("Stars").GetComponent<CanvasRenderer>().GetComponent<Image>().sprite = OneStar;
                break;
            case 2:
                WinMenu.transform.Find("Stars").GetComponent<CanvasRenderer>().GetComponent<Image>().sprite = TwoStar;
                break;
            case 3:
                WinMenu.transform.Find("Stars").GetComponent<CanvasRenderer>().GetComponent<Image>().sprite = ThreeStar;
                break;
            default:
                return;
        }

        //Overlay aktiv setzen
        WinMenu.SetActive(true);
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
                if((i + 1) < levelManager.Levels.Count) {
                    levelManager.Levels[i + 1].Unlocked = true;
                    break;
                }
            }
        }
    }

    /// <summary>
    /// Setzt die Bilder der Play/Pause/Double Buttons neu
    /// </summary>
    private void RefreshPlayPauseButtons() {
        Button playPauseButton = GameObject.FindGameObjectWithTag("PlayPauseButton").GetComponent<Button>();
        Button fastForwardButton = GameObject.FindGameObjectWithTag("FastForwardButton").GetComponent<Button>();
        
        if(_gameManager.DoubleSpeed) {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[1]; // active
        } else if(_gameManager.Paused) {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[0]; // inactive
        } else if(!_gameManager.Paused) {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[1]; // pauseImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[0]; // inactive
        }
    }
}