using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_ExitButton : GameStateButton
{
    /// <summary>
    /// Pausiert das Spiel, wenn Options oder ExitButton gedrueckt wird
    /// </summary>
    public void Option_ExitButtonClick() {
        _gameManager.PauseGame();
        RefreshPlayPauseButtons();
    }
}
