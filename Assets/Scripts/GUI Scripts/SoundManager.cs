using System;
using Classes;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Wird einem Empty Object zugewiesen und enthaelt alle Sounds
/// </summary>
public class SoundManager : MonoBehaviour {

    private LevelManager _levelManager;
    
    private AudioSource BackgroundHauptmenue;
    private AudioSource BackgroundGame;
    private AudioSource DeathSound1;
    private AudioSource DeathSound2;

    private void Awake() {
        _levelManager = LevelManager.GetInstance();

        BackgroundHauptmenue = gameObject.AddComponent<AudioSource>();
        BackgroundGame = gameObject.AddComponent<AudioSource>();
        
        DeathSound1 = gameObject.AddComponent<AudioSource>();
        DeathSound2 = gameObject.AddComponent<AudioSource>();

        BackgroundHauptmenue.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/1_menu_music");
        BackgroundGame.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/1_level_music");
        
        DeathSound1.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/DeathSound1");
        DeathSound2.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/DeathSound2");
    }

    private void Start() {
        SetVolumeBackground(_levelManager.BackgroundVolume);
        SetVolumeSounds(_levelManager.SoundVolume);
    }

    /// <summary>
    /// Setzt die Lautstaerke der Hindergrundmusik
    /// </summary>
    /// <param name="value">zwischen 0 und 1</param>
    public void SetVolumeBackground(float value) {
        _levelManager.BackgroundVolume = value;

        BackgroundGame.volume = value;
        BackgroundHauptmenue.volume = value;
    }
    
    /// <summary>
    /// Setzt die Lautstaerke der normalen Sounds
    /// </summary>
    /// <param name="value">zwischen 0 und 1</param>
    public void SetVolumeSounds(float value) {
        _levelManager.SoundVolume = value;

        DeathSound1.volume = value;
        DeathSound2.volume = value;
    }

    /// <summary>
    /// Startet die Hintergrundmusik fuer Hauptmenue
    /// </summary>
    public void StartHauptmenueBackground() {
        BackgroundHauptmenue.loop = true;
        if(!BackgroundHauptmenue.isPlaying) {
            BackgroundHauptmenue.Play();
        }
    }

    /// <summary>
    /// Startet die Hintergrundmusik fuer Game
    /// </summary>
    public void StartGameBackground() {
        BackgroundGame.loop = true;
        if(!BackgroundGame.isPlaying) {
            BackgroundGame.Play();
        }
    }

    public void PlayDeath() {
        int rand = Random.Range(0,2);
        switch(rand) {
            case 0:
                DeathSound1.Play();
                break;
            default:
                DeathSound2.Play();
                break;
        }
    }
}
