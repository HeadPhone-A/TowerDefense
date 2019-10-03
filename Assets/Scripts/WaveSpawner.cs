using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefabs;
    public GameObject spawnPoint;

    public TextMeshProUGUI waveCountdownText;

    public float timeBetweenWaves = 5f;

    private float countdown = 2f;

    private int waveNumber = 0;

    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:0.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        PlayerStats.Rounds++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = (GameObject)Instantiate(enemyPrefabs, spawnPoint.transform.position, Quaternion.identity);
        enemy.transform.parent = gameObject.transform;
    }
}
