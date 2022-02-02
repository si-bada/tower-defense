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
    private float countDown;
    private int waveNumber = 0;
    private bool lastWave = false;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        countDown = TimeBetweenWaves;
    }
    private void Update()
    {
        if(countDown <= 0f  && !lastWave)
        {
            StartCoroutine(SpawnWave());
            countDown = TimeBetweenWaves;
        }

        if(lastWave)
        {
            WaveCountDownText.text = "Last Wave";
            Debug.LogWarning("Last Wave" + EnemiesAlive);
            if (EnemiesAlive <= 0)
            {
                this.enabled = false;
                LevelManager.sIntance.WinLevel();
            }
        }

        if (!lastWave)
        {
            countDown -= Time.deltaTime;
            countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
            WaveCountDownText.text = string.Format("{0:00.00}", countDown);
        }

    }
    #endregion

    #region Implementations
    IEnumerator SpawnWave()
    {
        Wave wave = Waves[waveNumber];
        waveNumber++;
        EnemiesAlive += wave.count;
        yield return new WaitForEndOfFrame();
        Debug.LogWarning(EnemiesAlive);
        for (int i=0; i< wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);

        }
        if(waveNumber == Waves.Length)
        {
            lastWave = true;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
    #endregion
}
