using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour {
    
    private SoundManager _soundManager;

    private void Awake() {
        _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void OnEnable() {
        LevelManager levelManager = LevelManager.GetInstance();
        Slider sliderBackground = GameObject.FindGameObjectWithTag("AudioReglerBackground").GetComponent<Slider>();
        sliderBackground.value = levelManager.BackgroundVolume;
        Slider sliderSounds = GameObject.FindGameObjectWithTag("AudioReglerSounds").GetComponent<Slider>();
        sliderSounds.value = levelManager.SoundVolume;
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
}