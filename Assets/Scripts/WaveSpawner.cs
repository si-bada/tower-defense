using System;
using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public Transform EnemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves;

    public TextMeshProUGUI waveCountDownText;

    private float countDown = 2f;

    private int waveNumber = 1;


    private void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        for (int i=0; i<waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
