using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] LevelButtons;
    public GameObject Child; // TODO kann private sein, weil zu Laufzeit initialisiert?
    public Sprite ZeroStar;
    public Sprite OneStar;
    public Sprite TwoStar;
    public Sprite ThreeStar;

    private LevelManager _levelManager;
    
    public LevelSelect() {
        _levelManager = LevelManager.GetInstance();
    }


    private void Start()
    {
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            ///das zu ver�ndernde Object muss erst in child gespeichert werden, damit �nderungen m�glich sind
            Child = LevelButtons[i].transform.GetChild(1).gameObject;

            if (!_levelManager.Levels[i].Unlocked)
            { 
                LevelButtons[i].interactable = false;
                
                Child.GetComponent<Image>().color = Color.grey;

                //**Ausgabe zum testen
                //Debug.Log("Kind: " + child.name);
                //Debug.Log("gefundene Sterne: " + levelButtons[i].transform.GetChild(1).name + GameObject.Find("Stars").GetComponent<Image>().color);   
                
            }
            else
            {
                switch(_levelManager.Levels[i].Stars) {
                    case 0:
                        Child.gameObject.GetComponent<Image>().sprite = ZeroStar;
                        break;
                    case 1:
                        Child.gameObject.GetComponent<Image>().sprite = OneStar;
                        break;
                    case 2:
                        Child.gameObject.GetComponent<Image>().sprite = TwoStar;
                        break;
                    case 3:
                        Child.gameObject.GetComponent<Image>().sprite = ThreeStar;
                        break;
                }
            }
        }
    }

    /// Methoden zum aufrufen verschiedener Level
    public void StartLevelOne() {
        SceneManager.LoadScene("LevelOne");
    }

    public void StartLevelTwo() {
        SceneManager.LoadScene("LevelTwo");
    }

    public void StartLevelThree() {
        SceneManager.LoadScene("LevelThree");
    }

    public void StartLevelFour() {
        SceneManager.LoadScene("LevelFour");
    }

    public void StartLevelFive() {
        SceneManager.LoadScene("LevelFive");
    }

    public void StartLevelSix() {
        SceneManager.LoadScene("LevelSix");
    }

    public void StartLevelSeven() {
        SceneManager.LoadScene("LevelSeven");
    }

    public void StartLevelEight() {
        SceneManager.LoadScene("LevelEight");
    }

    public void StartLevelNine() {
        SceneManager.LoadScene("LevelNine");
    }

    public void StartLevelTen() {
        SceneManager.LoadScene("LevelTen");
    }
}

