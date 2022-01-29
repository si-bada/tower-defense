using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Script Parameters
    public float Speed;
    public float Health;
    public int Reward;
    public GameObject DeathEffect;
    #endregion

    #region Fields
    private Transform target;
    private int pathPointIndex = 0;
    #endregion

    #region Unity Methods

    private void Start()
    {
        target = PathPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            UpdatePathPoint();
        }
    }
    #endregion

    #region Methods
    public void TakeDamage(int amount)
    {
        Health -= amount;
        if(Health <=0)
        {
            Die();
        }
    }
    #endregion

    #region Implementation
    private void Die()
    {
        PlayerManager.sIntance.GainMoney(Reward);

        GameObject effect = Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }

    private void UpdatePathPoint()
    {
        if(pathPointIndex >= PathPoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        pathPointIndex++;
        target = PathPoints.points[pathPointIndex];
    }

    private void EndPath()
    {
        PlayerManager.sIntance.LoseLife();
        Destroy(gameObject);
    }

    #endregion

}
