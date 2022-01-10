using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenMain()
    {
        SceneManager.LoadScene(1);
        //** alternativer Aufruf der Szene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        //Debug.Log("Quit Game");
        Application.Quit();
    }
}
