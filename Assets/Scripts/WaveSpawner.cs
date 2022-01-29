using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    #region Script Parameters
    public Transform EnemyPrefab;
    public Transform spawnPoint;
    public float TimeBetweenWaves;
    public TextMeshProUGUI WaveCountDownText;
    #endregion

    #region Fields
    private float countDown = 2f;
    private int waveNumber = 1;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if(countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = TimeBetweenWaves;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        WaveCountDownText.text = string.Format("{0:00.00}", countDown);
    }
    #endregion

    #region Implementations
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
    #endregion
}
