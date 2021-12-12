using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int level;
    private GameObject ob;

    public void Update()
    {
        
    }

    public void BackToMain()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

    public void StartLevel()
    {
        string lev = gameObject.name;
//            GetComponent<TextMesh>().text;
        Debug.Log("Level " +lev+ " geklickt");

        SceneManager.LoadScene(lev);
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
