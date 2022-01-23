using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayButton : GameStateButton
{
    public void Pause_PlayButtonClick() {
        if(_gameManager.DoubleSpeed) {
            _gameManager.StartGame();
        } else if(!_gameManager.Paused) {
            _gameManager.PauseGame();
        } else if(_gameManager.Paused) {
            _gameManager.StartGame();
        }

        RefreshPlayPauseButtons();
    }
}
