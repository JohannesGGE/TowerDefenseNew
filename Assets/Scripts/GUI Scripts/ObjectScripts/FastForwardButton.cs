using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastForwardButton : GameStateButton
{
    /// <summary>
    /// Verdoppelt die Geschwindigkeit im Spiel
    /// </summary>
    public void FastForwardButtonClick() {
        if(_gameManager.DoubleSpeed) {
            _gameManager.StartGame();
        } else if(_gameManager.Paused) {
            _gameManager.DoubleGame();
        } else if(!_gameManager.Paused) {
            _gameManager.DoubleGame();
        }

        RefreshPlayPauseButtons();
    }
}
