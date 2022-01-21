using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour {
    
    void Start() {
        LevelManager levelManager = LevelManager.GetInstance();
        Slider sliderBackground = GameObject.FindGameObjectWithTag("AudioReglerBackground").GetComponent<Slider>();
        sliderBackground.value = levelManager.BackgroundVolume;
        Slider sliderSounds = GameObject.FindGameObjectWithTag("AudioReglerSounds").GetComponent<Slider>();
        sliderSounds.value = levelManager.SoundVolume;
    }
}