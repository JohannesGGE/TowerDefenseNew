using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    //public SceneFader fader;


    public void Update()
    {
        /*
         * Überprüfung auf Win oder Lose
         * Variable Leben aus GameManager holen
        if (Leben < 1)
            { End Level -> Lost }

        Variable lastEnemyKilled aus GameManager holen!
        if (lastEnemyKilled == true && Leben > 0)
        { End level -> Win  }
        */
    }

    public void BackToMain()
    { 
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}