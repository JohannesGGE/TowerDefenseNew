using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    
   
    public void Update()
    {
        
    }

    
    public void OpenMain()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    } 

    
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
