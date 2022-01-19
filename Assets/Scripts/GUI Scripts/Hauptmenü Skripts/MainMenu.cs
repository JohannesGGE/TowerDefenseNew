using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    
    private SoundManager _soundManager;
    private GameManager _gameManager;
    private LevelManager _levelManager;
    
    private void Start() {
        _levelManager = LevelManager.GetInstance();
        _levelManager.LoadLevelStatus();
        _levelManager.LoadSettings();

        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManager.StartHauptmenueBackground();

        try {
            Slider sliderBackground = GameObject.FindGameObjectWithTag("AudioReglerBackground").GetComponent<Slider>();
            sliderBackground.value = _levelManager.BackgroundVolume;
            Slider sliderSounds = GameObject.FindGameObjectWithTag("AudioReglerSounds").GetComponent<Slider>();
            sliderSounds.value = _levelManager.SoundVolume;
        } catch(Exception e) {
            // Einfach NEIN!
        }
        
        
        _soundManager.SetVolumeBackground(_levelManager.BackgroundVolume);
        _soundManager.SetVolumeSounds(_levelManager.SoundVolume);
    }

    private void OnDestroy() {
        _levelManager.SaveSettings();
    }


    /// <summary>
    /// �ffnet bei Interaktion (Klick auf Button) das Hauptmen�
    /// </summary>
    public void OpenMain()
    {
        SceneManager.LoadScene(1);
        //** alternativer Aufruf der Szene
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void OnValueChangedBackground(float newValue)
    {
        _soundManager.SetVolumeBackground(newValue);
    }
    
    public void OnValueChangedSound(float newValue)
    {
        _soundManager.SetVolumeSounds(newValue);
    }
    

    

    /// <summary>
    /// beendet bei Interaktion (Klick auf Button) das Spiel
    /// </summary>
    public void QuitGame()
    {
        //Debug.Log("Quit Game");
        LevelManager levelManager = LevelManager.GetInstance();
        levelManager.SaveLevelStatus();
        Application.Quit();
    }
}
