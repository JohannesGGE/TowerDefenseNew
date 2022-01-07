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
    }

    /// <summary>
    /// Variable <c> enemyPrefab </c> 
    /// </summary>
    private Transform _enemyPrefab;
    /// <summary>
    /// Variable <c> waves </c> enthaelt die verschiedenen Wellen
    /// </summary>
    public Wave[] waves;
    /// <summary>
    /// Variable <c> spawnPoint </c> enthaelt die Stelle, an welcher die Voegel spawnen
    /// </summary>
    public Transform spawnPoint;
    /// <summary>
    /// Variable <c> timeBetweenWaves </c> 
    /// </summary>
    public float timeBetweenWaves = 5f;
    /// <summary>
    /// Variable <c> countdown </c> 
    /// </summary>
    private float _countdown = 2f;
    /// <summary>
    /// Variable <c> waveIndex </c> 
    /// </summary>
    private int _waveIndex = 0;

    /// <summary>
    /// Variable <c> canSpawn </c> gibt an, ob vorherige Welle abgeschlossen ist 
    /// </summary>
    private bool _canSpawn = false;

    /// <summary>
    /// Variable <c> waveEnemies</c> gibt an, wie viele Voegel gespawnt wurden
    /// </summary>
    private int _spawnedEnemies = 0;

    /// <summary>
    /// Variable <c> totalEnemies </c> gibt an, wie viele Voegel in einer Welle spawnen
    /// </summary>
    private int _totalEnemies;

    public string enemyTag = "Bird";

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


        if(_countdown <= 0f)
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
            if(enemies.Length == 0)
            {
                /// GameManager irgendwas auf True
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
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        _canSpawn = true;
        _waveIndex++;
    }
    /// <summary>
    /// Spawnt den Vogel
    /// </summary>
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(_enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        _spawnedEnemies += 1;
    }
}
