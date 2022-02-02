using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region Script Parameters
    public Image            HeathBar;
    public GameObject       DeathEffect;
    public EnemyType        Type;
    public float            StartSpeed;
    public float            StartHealth;
    public int              Reward;
    public int              PenaltyPerHit;
    [HideInInspector]
    public float            Speed;
    #endregion

    #region Fields
    private float           health;
    private int             hitsTaken = 0;
    #endregion

    #region Unity Methods
    private void Start()
    {
        Speed = StartSpeed;
        health = StartHealth;
    }
    #endregion

    #region Methods
    public void TakeDamage(float amount, TurretType from)
    {
        if(from != TurretType.LaserBeam)
            hitsTaken++;

        health -= amount;
        HeathBar.fillAmount = health / StartHealth;
        if(health <=0)
        {
            Die();
        }
    }
    public void Slow(float ratio)
    {
        Speed = StartSpeed * (1f - ratio);
    }
    #endregion

    #region Implementation
    private void Die()
    {
        PlayerManager.sIntance.GainMoney(Reward - (hitsTaken - 1) * PenaltyPerHit);

        GameObject effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
        Debug.LogWarning("Remaning " + WaveSpawner.EnemiesAlive);
        PlayerManager.sIntance.UpadateScore(Reward);
    }

    #endregion

}

[System.Serializable]
public enum EnemyType
{
    Normal,
    Strong,
    Fast
}
