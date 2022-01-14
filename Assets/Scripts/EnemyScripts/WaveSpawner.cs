using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Classes;

public class WaveSpawner : MonoBehaviour
{
    private GameManager _gameManager;

    public WaveSpawner()
    {
        _gameManager = GameManager.GetInstance();
        LevelManager levelManager = LevelManager.GetInstance();
        _gameManager.ResetGameManager();
        _gameManager.Level = levelManager.Levels[1];
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
    public float timeBetweenWaves = 5f;
    
    private float _countdown = 2f;
    
    private int _waveIndex = 0;

    /// <summary>
    /// Variable <c> canSpawn </c> gibt an, ob vorherige Welle abgeschlossen ist 
    /// </summary>
    private bool _canSpawn = true;

    public string enemyTag = "Bird";

    /// <summary>
    /// Initialisiert die Waves ueber den GameManager
    /// </summary>
    void Start ()
    {
      waves = _gameManager.Level.Waves;
      _gameManager.StartGame();
    }

    /// <summary>
    /// berechnet Zeit zwischen Wellen
    /// </summary>
    void Update ()
    {
       /// Array mit lebenden Voegeln anlegen
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        if (!_gameManager.Paused)
        { 
        /// wenn countdown abgelaufen ist und noch nicht die letzte Welle gespawnt wurde
        if (_countdown <= 0f && _gameManager.AllEnemySpawned == false)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            _canSpawn = false;
            return;
        }

        /// wenn letzter Vogel gespawnt ist, beginnt der Timer
        if (_canSpawn == true)
        {
            _countdown -= Time.deltaTime;
        }

        /// wenn letzte Welle gespawnt ist
        if (_waveIndex == waves.Length && _canSpawn == true)
        {

            _gameManager.AllEnemySpawned = true;

            /// wenn letzter Gegner getoetet ist 
            if(enemies.Length == 0)
            {
                _gameManager.LastEnemyKilled = true;
            }
        }
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
    }
    /// <summary>
    /// Spawnt den Vogel
    /// </summary>
    void SpawnEnemy(BirdLevel birdLevel)
    {
        if(birdLevel == BirdLevel.Small)
        {
        Instantiate(smallPrefab, spawnPoint.position, spawnPoint.rotation);
        }
            else if(birdLevel == BirdLevel.Medium)
            {
            Instantiate(mediumPrefab, spawnPoint.position, spawnPoint.rotation);
            }
                 else
                 Instantiate(bigPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}
