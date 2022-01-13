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
    /// Variable <c> enemyPrefab </c>  entaehlt Position und Skalierung des Vogels
    /// </summary>
    public Transform _enemyPrefab;
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
    }

    /// <summary>
    /// berechnet Zeit zwischen Wellen
    /// </summary>
    void Update ()
    {

       GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);


        if(_countdown <= 0f && _gameManager.AllEnemySpawned == false)
        {
            StartCoroutine(SpawnWave());
            _countdown = timeBetweenWaves;
            _canSpawn = false;
            return;
        }

        if (_canSpawn == true)
        {
            _countdown -= Time.deltaTime;
        }

        if (_waveIndex == waves.Length && _canSpawn == true)
        {

            _gameManager.AllEnemySpawned = true;
            Debug.Log("Last Enemy spawned");

            if(enemies.Length == 0)
            {
                _gameManager.LastEnemyKilled = true;
                Debug.Log("Last Enemy killed");
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
            yield return new WaitForSeconds(1f / 2);
        }

        _canSpawn = true;
        _waveIndex++;
    }
    /// <summary>
    /// Spawnt den Vogel
    /// </summary>
    void SpawnEnemy(BirdLevel birdLevel)
    {
        Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
 
    }
}
