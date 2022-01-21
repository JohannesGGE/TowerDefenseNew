using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //Buttons die im Levelauswahlmen� gedr�ckt werden k�nnen, um ein entsprechendes Level aufzurufen
    public Button[] LevelButtons;

    //tempor�res Objekt zum ansprechen eines Child-Objekts
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
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgef�hrt wird
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


    /// <summary>
    /// Methoden zum aufrufen verschiedener Level
    /// </summary>
    public void StartLevelOne() {
        SceneManager.LoadScene("LevelOne");
        _gameManager.PrepareLevel(_levelManager.Levels[0]);
    }

    public void StartLevelTwo() {
        SceneManager.LoadScene("LevelTwo");
        _gameManager.PrepareLevel(_levelManager.Levels[1]);
    }

    public void StartLevelThree() {
        SceneManager.LoadScene("LevelThree");
        _gameManager.PrepareLevel(_levelManager.Levels[2]);
    }

    public void StartLevelFour() {
        SceneManager.LoadScene("LevelFour");
        _gameManager.PrepareLevel(_levelManager.Levels[3]);
    }

    public void StartLevelFive() {
        SceneManager.LoadScene("LevelFive");
        _gameManager.PrepareLevel(_levelManager.Levels[4]);
    }

    public void StartLevelSix() { }

    public void StartLevelSeven() { }

    public void StartLevelEight() { }

    public void StartLevelNine() { }

    public void StartLevelTen() { }

}

