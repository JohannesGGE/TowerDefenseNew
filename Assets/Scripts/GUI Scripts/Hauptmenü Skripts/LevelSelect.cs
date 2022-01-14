using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //Buttons die im Levelauswahlmenü gedrückt werden können, um ein entsprechendes Level aufzurufen
    public Button[] LevelButtons;

    //temporäres Objekt zum ansprechen eines Child-Objekts
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
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgeführt wird
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {

            _child = LevelButtons[i].transform.GetChild(1).gameObject; 


            if (!_levelManager.Levels[i].Unlocked)
            { 
                LevelButtons[i].interactable = false;
                
                _child.GetComponent<Image>().color = Color.grey;

                //**Ausgabe zum testen
                //Debug.Log("Kind: " + child.name);
                //Debug.Log("gefundene Sterne: " + levelButtons[i].transform.GetChild(1).name + GameObject.Find("Stars").GetComponent<Image>().color);   
                
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

    public void StartLevelSix() {
        SceneManager.LoadScene("LevelSix");
        _gameManager.PrepareLevel(_levelManager.Levels[5]);
    }

    public void StartLevelSeven() {
        SceneManager.LoadScene("LevelSeven");
        _gameManager.PrepareLevel(_levelManager.Levels[6]);
    }

    public void StartLevelEight() {
        SceneManager.LoadScene("LevelEight");
        _gameManager.PrepareLevel(_levelManager.Levels[7]);
    }

    public void StartLevelNine() {
        SceneManager.LoadScene("LevelNine");
        _gameManager.PrepareLevel(_levelManager.Levels[8]);
    }

    public void StartLevelTen() {
        SceneManager.LoadScene("LevelTen");
        _gameManager.PrepareLevel(_levelManager.Levels[9]);
    }

}

