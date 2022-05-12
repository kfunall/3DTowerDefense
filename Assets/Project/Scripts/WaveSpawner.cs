using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTime = 5f;
    PlayerStats playerStats;
    float spawnStartTime = 2f;
    int waveNumber = 0;

    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    private void Start()
    {
        InvokeRepeating("Spawn", spawnStartTime, spawnTime);
    }
    void Spawn()
    {
        StartCoroutine(SpawnWave());
    }
    IEnumerator SpawnWave()
    {
        waveNumber++;
        playerStats.IncreaseRound();
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
}