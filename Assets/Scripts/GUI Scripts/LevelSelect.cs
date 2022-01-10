using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] LevelButtons;
    public GameObject Child;
    public Sprite ZeroStar;
    public Sprite OneStar;
    public Sprite TwoStar;
    public Sprite ThreeStar;
    public int StarsReached;



    private void Start()
    {
        ///levelSolved muss im GameManager gespeichert werden
        int levelSolved = PlayerPrefs.GetInt("levelSolved", 5);

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            ///das zu verändernde Object muss erst in child gespeichert werden, damit änderungen möglich sind
            Child = LevelButtons[i].transform.GetChild(1).gameObject; 

            if (i + 1 > levelSolved)
            { LevelButtons[i].interactable = false;
                
                Child.GetComponent<Image>().color = Color.grey;

                //**Ausgabe zum testen
                //Debug.Log("Kind: " + child.name);
                //Debug.Log("gefundene Sterne: " + levelButtons[i].transform.GetChild(1).name + GameObject.Find("Stars").GetComponent<Image>().color);   
                
            }
            else
            {
                if (StarsReached == 0)
                { Child.gameObject.GetComponent<Image>().sprite = ZeroStar; }
                else if (StarsReached == 1)
                { Child.gameObject.GetComponent<Image>().sprite = OneStar; }
                else if (StarsReached == 2)
                { Child.gameObject.GetComponent<Image>().sprite = TwoStar; }
                else if (StarsReached == 3)
                { Child.gameObject.GetComponent<Image>().sprite = ThreeStar; }
            }
        }
    }
    /// Methoden zum aufrufen verschiedener Level
    public void StartLevelOne()
    { SceneManager.LoadScene("LevelOne"); }
    public void StartLevelTwo()
    { SceneManager.LoadScene("LevelTwo"); }
    public void StartLevelThree()
    { SceneManager.LoadScene("LevelThree"); }
    public void StartLevelFour()
    { SceneManager.LoadScene("LevelFour"); }
    public void StartLevelFive()
    { SceneManager.LoadScene("LevelFive"); }
    public void StartLevelSix()
    { SceneManager.LoadScene("LevelSix"); }
    public void StartLevelSeven()
    { SceneManager.LoadScene("LevelSeven"); }
    public void StartLevelEight()
    { SceneManager.LoadScene("LevelEight"); }
    public void StartLevelNine()
    { SceneManager.LoadScene("LevelNine"); }
    public void StartLevelTen()
    { SceneManager.LoadScene("LevelTen"); }
}

