using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Classes;

public class WaveSpawner : MonoBehaviour
{
    /// <summary>
    /// Variable <c> enemyPrefab </c> 
    /// </summary>
    public Transform enemyPrefab;
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
    private float countdown = 2f;
    /// <summary>
    /// Variable <c> waveIndex </c> 
    /// </summary>
    private int waveIndex = 0;

    /// <summary>
    /// Variable <c> canSpawn </c> gibt an, ob vorherige Welle abgeschlossen ist 
    /// </summary>
    private bool canSpawn = false;

    /// <summary>
    /// Variable <c> waveEnemies</c> gibt an, wie viele Voegel gespawnt wurden
    /// </summary>
    private int spawnedEnemies = 0;

    /// <summary>
    /// Variable <c> totalEnemies </c> gibt an, wie viele Voegel in einer Welle spawnen
    /// </summary>
    private int totalEnemies;

    /// <summary>
    /// berechnet Zeit zwischen Wellen
    /// </summary>
    void Update ()
    {
        if(spawnedEnemies == totalEnemies)
        {
            canSpawn = true;
        }

        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            canSpawn = false;
            return;
        }

        if (canSpawn == true)
        {
            countdown -= Time.deltaTime;
        }
    }
    /// <summary>
    /// Spawnt die Welle
    /// </summary>
    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];


        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }
    /// <summary>
    /// Spawnt den Vogel
    /// </summary>
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        spawnedEnemies += 1;
    }
}
