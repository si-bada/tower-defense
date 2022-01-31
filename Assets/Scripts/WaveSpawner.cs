using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    #region Script Parameters
    public static int EnemiesAlive = 0;
    public Transform spawnPoint;
    public float TimeBetweenWaves;
    public TextMeshProUGUI WaveCountDownText;
    public Wave[] Waves;
    #endregion

    #region Fields
    private float countDown = 5f;
    private int waveNumber = 0;
    private bool lastWave = false;
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
        if(waveNumber == Waves.Length )
        {
            WaveCountDownText.text = "Last Herd";

            if ( EnemiesAlive == 0)
            {
                this.enabled = false;
                GameManager.sIntance.WinLevel();
            }
        }
        else
        {
            Wave wave = Waves[waveNumber];
            for (int i=0; i< wave.count; i++)
            {
                SpawnEnemy(wave.enemy);
                yield return new WaitForSeconds(1f / wave.rate);

            }
            waveNumber++;
            if(waveNumber == Waves.Length)
            {
                lastWave = true;
            }
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
    #endregion
}
