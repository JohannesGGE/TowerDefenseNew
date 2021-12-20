using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public SceneFader fader;
    
   
    public void Update()
    {
        
    }

    public void BackToMain()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

    public void StartLevel(string levelName)
    {
        //fader.FadeTo(levelName);
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
