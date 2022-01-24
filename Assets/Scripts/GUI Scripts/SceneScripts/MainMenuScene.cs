using System;
using Classes;
using UnityEngine;

public class MainMenuScene : MonoBehaviour {
    
    private SoundManager _soundManager;
    private LevelManager _levelManager;


    /// <summary>
    /// Methode, die zu Beginn aufgerufen wird, wenn das Skript ausgefuehrt wird
    /// </summary>
    void Start() {
        _levelManager = LevelManager.GetInstance();

        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        
        _soundManager.SetVolumeBackground(_levelManager.BackgroundVolume);
        _soundManager.SetVolumeSounds(_levelManager.SoundVolume);
        
        _soundManager.StartHauptmenueBackground();
    }

    /// <summary>
    /// Speichert, die Einstellungen beim schließen der Scene
    /// </summary>
    private void OnDisable() {
        _levelManager.SaveSettings();
    }
    
    /// <summary>
    /// Wird bei Aenderung des LautstaerkeSliders fuer Backgroundmusik aufgerufen
    /// </summary>
    public void OnValueChangedBackground(float newValue) {
        _soundManager.SetVolumeBackground(newValue);
    }

    /// <summary>
    /// Wird bei Aenderung des LautstaerkeSliders fuer NormaleSOunds aufgerufen
    /// </summary>
    public void OnValueChangedSound(float newValue) {
        _soundManager.SetVolumeSounds(newValue);
    }

    /// <summary>
    /// Beendet bei Interaktion (Klick auf Button) das Spiel
    /// </summary>
    public void QuitGame() {
        _levelManager.SaveLevelStatus();
        Application.Quit();
    }
}