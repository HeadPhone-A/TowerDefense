using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public GameObject spawnPoint;
    //public TMP_Text waveDisplayer;
    public TMP_Text waveCountdownDisplayer;
    //public TMP_Text enemyAliveDisplayer;

    public float timeBetweenWaves = 5f;

    public Wave[] waves;

    private float countdown = 2f;

    private int waveIndex = 0;

    private void Update()
    {

        if (EnemiesAlive > 0)
        {
            countdown = timeBetweenWaves;
            UpdateWaveCountdownDisplayer();
            return;
        }

        if (countdown <= 0f)
        {
            countdown = timeBetweenWaves;
            StartCoroutine(SpawnWave());
            return;
        }

        countdown -= Time.deltaTime;
        UpdateWaveCountdownDisplayer();
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(wave.rate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemy.transform.parent = gameObject.transform;
    }

    public void UpdateWaveCountdownDisplayer()
    {
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownDisplayer.text = string.Format("{0:0.00}", countdown);
    }
}
