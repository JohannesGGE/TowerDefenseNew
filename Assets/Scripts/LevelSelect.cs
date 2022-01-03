using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
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


    public Button[] levelButtons;
    public GameObject child;
    public Sprite zeroStar;
    public Sprite oneStar;
    public Sprite twoStar;
    public Sprite threeStar;
    public int starsReached;



    private void Start()
    {

        int levelSolved = PlayerPrefs.GetInt("levelSolved", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            child = levelButtons[i].transform.GetChild(1).gameObject; //muss erst in child gespeichert werden, damit änderungen möglich sind

            if (i > levelSolved)
            { levelButtons[i].interactable = false;
                
                child.GetComponent<Image>().color = Color.grey;

               

                Debug.Log("Kind: " + child.name);
                Debug.Log("gefundene Sterne: " + levelButtons[i].transform.GetChild(1).name + GameObject.Find("Stars").GetComponent<Image>().color);   
            }
            else
            {
                if (starsReached == 0)
                { child.gameObject.GetComponent<Image>().sprite = zeroStar; }
                else if (starsReached == 1)
                { child.gameObject.GetComponent<Image>().sprite = oneStar; }
                else if (starsReached == 2)
                { child.gameObject.GetComponent<Image>().sprite = twoStar; }
                else if (starsReached == 3)
                { child.gameObject.GetComponent<Image>().sprite = threeStar; }
            }



        }
    }


}

