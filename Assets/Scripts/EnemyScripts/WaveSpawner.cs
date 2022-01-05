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
    /// Variable <c> waves </c> 
    /// </summary>
    public Wave[] waves;
    /// <summary>
    /// Variable <c> spawnPoint </c> 
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
    /// berechnet Zeit zwischen Wellen
    /// </summary>
    void Update ()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
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
    }
}
