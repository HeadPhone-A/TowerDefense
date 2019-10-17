using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public GameObject spawnPoint;
    public TMP_Text waveDisplayer;
    public TMP_Text waveCountdownDisplayer;
    public TMP_Text enemyAliveDisplayer;

    public float timeBetweenWaves = 5f;

    public Wave[] waves;

    public GameManager gameManager;

    private float countdown = 2f;

    private int waveIndex = 0;

    private void Update()
    {
        
        enemyAliveDisplayer.text = "Alive Enemy " + EnemiesAlive.ToString();

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        waveDisplayer.text = "Wave " + (waveIndex + 1).ToString();

        if (countdown <= 0f)
        {
            countdown = timeBetweenWaves;
            StartCoroutine(SpawnWave());
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownDisplayer.text = string.Format("{0:0.00}", countdown);
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
}
