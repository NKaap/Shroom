using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetweenWaves;
    public float countdown;
    public Text waveCountdownText;

    private int WaveIndex = 0;
    
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (WaveIndex == waves.Length)
        {
            this.enabled = false;
        }

        if (countdown<= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00:00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[WaveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            EnemiesAlive++;
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        for (int i = 0; i < wave.count2; i++)
        {
            EnemiesAlive++;
            SpawnEnemy(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate2);
        }
        WaveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
