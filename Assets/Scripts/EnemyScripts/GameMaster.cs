using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;

public class GameMaster : MonoBehaviour
{

    private GameManager _gameManager;
    
    public GameMaster()
    {
        _gameManager = GameManager.GetInstance();
    }
    void Start()
    {
        _gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
          {
              if(!_gameManager.Paused && !_gameManager.DoubleSpeed)
              {
                _gameManager.PauseGame();
                if(_gameManager.Paused)
                {
                  Debug.Log("Pause");
                }
              }
              else
              {
                _gameManager.StartGame();
                if(!_gameManager.Paused)
                {
                  Debug.Log("Start");
                }
              }

          }

          if(Input.GetKeyDown(KeyCode.Alpha2))
          {
              _gameManager.DoubleGame();
          }
    }
}
