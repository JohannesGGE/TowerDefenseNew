using System;
using Classes;
using UnityEngine;

public class MainMenuScene : MonoBehaviour {
    
    private SoundManager _soundManager;
    private LevelManager _levelManager;

    void Start() {
        _levelManager = LevelManager.GetInstance();
        _levelManager.LoadLevelStatus();
        _levelManager.LoadSettings();

        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        _soundManager.StartHauptmenueBackground();

        _soundManager.SetVolumeBackground(_levelManager.BackgroundVolume);
        _soundManager.SetVolumeSounds(_levelManager.SoundVolume);
    }

    private void OnDisable() {
        _levelManager.SaveSettings();
    }

    public void OnValueChangedBackground(float newValue) {
        _soundManager.SetVolumeBackground(newValue);
    }

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