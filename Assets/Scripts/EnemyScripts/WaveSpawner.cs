using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Classes;

public class WaveSpawner : MonoBehaviour
{
    private GameManager _gameManager;

    public Transform ordnerVoegel;

    public WaveSpawner()
    {
        _gameManager = GameManager.GetInstance();
    }

    /// <summary>
    /// Variable <c> enemyPrefab </c>  entaehlt Position,Skalierung und Art des Vogels
    /// </summary>
    public Transform smallPrefab;

    public Transform mediumPrefab;

    public Transform bigPrefab;

    /// <summary>
    /// Variable <c> waves </c> enthaelt die verschiedenen Wellen
    /// </summary>
    public Wave[] waves;
    /// <summary>
    /// Variable <c> spawnPoint </c> enthaelt die Stelle, an welcher die Voegel spawnen
    /// </summary>
    public Transform spawnPoint;
    /// <summary>
    /// Variable <c> timeBetweenWaves </c> enthaelt die Zeit zwischen den Wellen
    /// </summary>
    private float timeBetweenWaves = GameValues.TimeBetweenWaves;
    
    private float _countdown = GameValues.CountdownBeforeFirstBird;
    
    private int _waveIndex = 0;

    /// <summary>
    /// Variable <c> canSpawn </c> gibt an, ob vorherige Welle abgeschlossen ist 
    /// </summary>
    private bool _canSpawn = true;

    /// <summary>
    /// Initialisiert die Waves ueber den GameManager
    /// </summary>
    void Start ()
    {
      waves = _gameManager.Level.Waves;
    }

    /// <summary>
    /// berechnet Zeit zwischen Wellen
    /// </summary>
    void Update ()
    {
        if(_gameManager.LastEnemyKilled) {
            return;
        }

        /// wenn countdown abgelaufen ist und noch nicht die letzte Welle gespawnt wurde
        if (!_gameManager.Paused && _countdown <= 0f && _gameManager.AllEnemySpawned == false)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            _canSpawn = false;
            return;
        }

        /// wenn letzter Vogel gespawnt ist, beginnt der Timer
        if (!_gameManager.Paused && _canSpawn == true)
        {
            _countdown -= Time.deltaTime;
        }
    }
    /// <summary>
    /// Spawnt die Welle
    /// </summary>
    IEnumerator SpawnWave()
    {
        Wave wave = waves[_waveIndex];


        for (int i = 0; i < wave.Birds.Length; i++)
        {
            SpawnEnemy(wave.Birds[i]);
            yield return new WaitForSeconds(wave.SpawnRate);
        }

        _canSpawn = true;
        _waveIndex++;

        /// wenn letzte Welle gespawnt ist
        if (_waveIndex == waves.Length)
        {
            _gameManager.AllEnemySpawned = true;
        }
    }
    /// <summary>
    /// Spawnt den Vogel
    /// </summary>
    void SpawnEnemy(BirdLevel birdLevel)
    {
        if(birdLevel == BirdLevel.Small)
        {
        Instantiate(smallPrefab, spawnPoint.position, spawnPoint.rotation, ordnerVoegel);
        }
            else if(birdLevel == BirdLevel.Medium)
            {
            Instantiate(mediumPrefab, spawnPoint.position, spawnPoint.rotation, ordnerVoegel);
            }
                 else
                 Instantiate(bigPrefab, spawnPoint.position, spawnPoint.rotation, ordnerVoegel);

    }
}
