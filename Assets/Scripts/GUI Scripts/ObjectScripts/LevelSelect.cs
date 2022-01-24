using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //Buttons die im Levelauswahlmenue gedrueckt werden koennen, um ein entsprechendes Level aufzurufen
    public Button[] LevelButtons;

    //temporaeres Objekt zum ansprechen eines Child-Objekts
    private GameObject _child;
    
    //verschiedene Sprites, zur Darstellung der erreichten Sterne eines Levels
    public Sprite ZeroStar;
    public Sprite OneStar;
    public Sprite TwoStar;
    public Sprite ThreeStar;


    private LevelManager _levelManager;
    private GameManager _gameManager;
    
    public LevelSelect() {
        _levelManager = LevelManager.GetInstance();
        _gameManager = GameManager.GetInstance();
    }

    //Variable die speichert wie viele Sterne in einem Level erreicht wurden
    public int StarsReached;


    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgefuehrt wird
    /// </summary>
    private void Start()
    {

        for (int i = 0; i < _levelManager.Levels.Count; i++)
        {
            _child = LevelButtons[i].transform.GetChild(1).gameObject; 
            
            if (!_levelManager.Levels[i].Unlocked)
            { 
                LevelButtons[i].interactable = false;
                _child.GetComponent<Image>().color = Color.grey;
            }
            else
            {
                switch(_levelManager.Levels[i].Stars) {
                    case 0:
                        _child.gameObject.GetComponent<Image>().sprite = ZeroStar;
                        break;
                    case 1:
                        _child.gameObject.GetComponent<Image>().sprite = OneStar;
                        break;
                    case 2:
                        _child.gameObject.GetComponent<Image>().sprite = TwoStar;
                        break;
                    case 3:
                        _child.gameObject.GetComponent<Image>().sprite = ThreeStar;
                        break;
                }
            }
        }
    }

    public void Update()
    {
        if (_levelManager.Levels[4].Stars > 0)
        { GameObject.Find("LevelsPanel").transform.GetChild(1).gameObject.SetActive(true); }
    }


    /// <summary>
    /// Methoden zum aufrufen verschiedener Level
    /// </summary>
    public void StartLevelOne() {
        _gameManager.PrepareLevel(_levelManager.Levels[0]);
        SceneManager.LoadScene("LevelOne");
    }

    public void StartLevelTwo() {
        _gameManager.PrepareLevel(_levelManager.Levels[1]);
        SceneManager.LoadScene("LevelTwo");
    }

    public void StartLevelThree() {
        _gameManager.PrepareLevel(_levelManager.Levels[2]);
        SceneManager.LoadScene("LevelThree");
    }

    public void StartLevelFour() {
        _gameManager.PrepareLevel(_levelManager.Levels[3]);
        SceneManager.LoadScene("LevelFour");
    }

    public void StartLevelFive() {
        _gameManager.PrepareLevel(_levelManager.Levels[4]);
        SceneManager.LoadScene("LevelFive");
    }

    public void StartLevelSix() { }

    public void StartLevelSeven() { }

    public void StartLevelEight() { }

    public void StartLevelNine() { }

    public void StartLevelTen() { }

}

