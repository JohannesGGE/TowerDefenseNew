using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameStateButton : MonoBehaviour
{
    public Sprite[] playPauseButtonSprites; // 0: play , 1: Pause
    public Sprite[] doubleButtonSprites; // 0: inactive, 1: active 
    
    protected GameManager _gameManager;
    
    void Start()
    {
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Setzt die Bilder der Play/Pause/Double Buttons neu
    /// </summary>
    protected void RefreshPlayPauseButtons() {
        Button playPauseButton = GameObject.FindGameObjectWithTag("PlayPauseButton").GetComponent<Button>();
        Button fastForwardButton = GameObject.FindGameObjectWithTag("FastForwardButton").GetComponent<Button>();

        if(_gameManager.DoubleSpeed) {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[1]; // active
        } else if(_gameManager.Paused) {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[0]; // playImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[0]; // inactive
        } else if(!_gameManager.Paused) {
            playPauseButton.image.overrideSprite = playPauseButtonSprites[1]; // pauseImage
            fastForwardButton.image.overrideSprite = doubleButtonSprites[0]; // inactive
        }
    }
}
