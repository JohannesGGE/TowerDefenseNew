using System;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// 
    /// </summary>
    public void LoadNextLevel() {
        // TODO Bei 5 aushoeren!
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Pausiert oder setzt das Spiel fort
    /// </summary>
    public void Pause_PlayButtonClick() {
        if(_gameManager.DoubleSpeed) {
            _gameManager.StartGame();
        } else if(!_gameManager.Paused) {
            _gameManager.PauseGame();
        } else if(_gameManager.Paused) {
            _gameManager.StartGame();
        }

        RefreshPlayPauseButtons();
    }

    /// <summary>
    /// Wird bei Aenderung des LautstaerkeSliders fuer Backgroundmusik aufgerufen
    /// </summary>
    public void OnValueChangedBackground(float newValue) {
        _soundManager.SetVolumeBackground(newValue);
    }

    /// <summary>
    /// Wird bei Aenderung des LautstaerkeSliders fuer NormaleSOunds aufgerufen
    /// </summary>
    public void OnValueChangedSound(float newValue) {
        _soundManager.SetVolumeSounds(newValue);
    }

    /// <summary>
    /// Verdoppelt die Geschwindigkeit im Spiel
    /// </summary>
    public void DoubleButtonClick() {
        if(_gameManager.DoubleSpeed) {
            _gameManager.StartGame();
        } else if(_gameManager.Paused) {
            _gameManager.DoubleGame();
        } else if(!_gameManager.Paused) {
            _gameManager.DoubleGame();
        }

        RefreshPlayPauseButtons();
    }

    /// <summary>
    /// Pausiert das Spiel, wenn Options oder ExitButton gedrueckt wird
    /// </summary>
    public void Option_ExitButtonClick() {
        _gameManager.PauseGame();
        RefreshPlayPauseButtons();
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
        //string StarRoot = "Stars/" + _gameManager.Level.Stars.ToString();
        //Stars.image = Resources.Load(StarRoot) as Image;

        //Debug.Log("Object im WinOverlay" +gameObject.name); -> Canvas

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

        /*
        Debug.Log("Sternobject? sprite.texture.name " +WinMenu.transform.Find("Stars").GetComponent<CanvasRenderer>().GetComponent<Image>().sprite.texture.name); //works!!!!
        Debug.Log("Sternobject? sprite.name" + WinMenu.transform.Find("Stars").GetComponent<CanvasRenderer>().GetComponent<Image>().sprite.name); //works!!!!
        Debug.Log("Sternobject? maintexture.name " + WinMenu.transform.Find("Stars").GetComponent<CanvasRenderer>().GetComponent<Image>().mainTexture.name); //works!!!!
        
        Texture Stars;
        Image Staaaars;
        Sprite TheStars;

        Debug.Log("Reached Stars: " + _gameManager.Level.Stars.ToString()); //works!
        string StarRoot = "Stars/" + _gameManager.Level.Stars.ToString();
        Stars = Resources.Load(StarRoot) as Texture;  // -> works with Texture ! Doesnt work with sprite or image
        Staaaars = Resources.Load(StarRoot) as Image;
        TheStars = Resources.Load("Stars/2") as Sprite;
        Debug.Log("Stars resource loaded: " + Stars.name);
        Debug.Log("Staaaars resource loaded: " + Staaaars.name);


        WinMenu.transform.Find("Stars").GetComponent<CanvasRenderer>().GetComponent<Image>().sprite = TheStars;
        */


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