using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    
    private AudioSource BuySound;
    private AudioSource click1;
    private AudioSource click2;
    private AudioSource click3;
    private AudioSource DeathSound1;
    private AudioSource DeathSound2;
    private AudioSource Defeat;
    private AudioSource fire_long;
    private AudioSource fire_short;
    private AudioSource HitSound1;
    private AudioSource HitSound2;
    private AudioSource HitSound3;
    private AudioSource ice_long;
    private AudioSource ice_short;
    private AudioSource TowerBuild;
    private AudioSource WaveSpawn;
    private AudioSource Win;


    private void Start() {
        BuySound = gameObject.AddComponent<AudioSource>();
        click1 = gameObject.AddComponent<AudioSource>();
        click2 = gameObject.AddComponent<AudioSource>();
        click3 = gameObject.AddComponent<AudioSource>();
        DeathSound1 = gameObject.AddComponent<AudioSource>();
        DeathSound2 = gameObject.AddComponent<AudioSource>();
        Defeat = gameObject.AddComponent<AudioSource>();
        fire_long = gameObject.AddComponent<AudioSource>();
        fire_short = gameObject.AddComponent<AudioSource>();
        HitSound1 = gameObject.AddComponent<AudioSource>();
        HitSound2 = gameObject.AddComponent<AudioSource>();
        HitSound3 = gameObject.AddComponent<AudioSource>();
        ice_long = gameObject.AddComponent<AudioSource>();
        ice_short = gameObject.AddComponent<AudioSource>();
        TowerBuild = gameObject.AddComponent<AudioSource>();
        WaveSpawn = gameObject.AddComponent<AudioSource>();
        Win = gameObject.AddComponent<AudioSource>();
        
        BuySound.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/BuySound");
        click1.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/click1");
        click2.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/click2");
        click3.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/click3");
        DeathSound1.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/DeathSound1");
        DeathSound2.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/DeathSound2");
        Defeat.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/Defeat");
        fire_long.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/fire_long");
        fire_short.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/fire_short");
        HitSound1.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/HitSound1");
        HitSound2.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/HitSound2");
        HitSound3.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/HitSound3");
        ice_long.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/ice_long");
        ice_short.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/ice_short");
        TowerBuild.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/TowerBuild");
        WaveSpawn.clip = (AudioClip)Resources.Load<AudioClip>("Sounds/WaveSpawn");
        Win.clip = (AudioClip) Resources.Load<AudioClip>("Sounds/Win");
        
        // TODO Background Music Loopen
        // Win.loop = true;
        // Win.volume = 0.1f;
        // Win.Play();
    }

    public void PlayBuy() {
        BuySound.Play();
    }
    
    public void PlayClick() {
        int rand = Random.Range(0,2);
        switch(rand) {
            case 0:
                click1.Play();
                break;
            case 1:
                click2.Play();
                break;
            default:
                click3.Play();
                break;
        }
    }

    public void PlayDeath() {
        int rand = Random.Range(0,1);
        switch(rand) {
            case 0:
                DeathSound1.Play();
                break;
            default:
                DeathSound2.Play();
                break;
        }
    }
    
    public void PlayDefeat() {
        Defeat.Play();
    }
    
    public void PlayFireLong() {
        fire_long.Play();
    }
    
    public void PlayFireShort() {
        fire_short.Play();
    }

    public void PlayHit() {
        int rand = Random.Range(0,2);
        switch(rand) {
            case 0:
                HitSound1.Play();
                break;
            case 1:
                HitSound2.Play();
                break;
            default:
                HitSound3.Play();
                break;
        }
    }
    
    public void PlayIceLong() {
        ice_long.Play();
    }
    
    public void PlayIceShort() {
        ice_short.Play();
    }
    
    public void PlayTowerBuild() {
        TowerBuild.Play();
    }
    
    public void PlayWaveSpawn() {
        WaveSpawn.Play();
    }
    
    public void PlayWin() {
        Win.Play();
    }
}
