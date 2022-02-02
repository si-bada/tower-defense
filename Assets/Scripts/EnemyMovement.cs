using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    #region Fields
    private Transform target;
    private int pathPointIndex = 0;
    private Enemy Enemy;
    #endregion

    #region Unity Methods

    private void Start()
    {
        Enemy = GetComponent<Enemy>();
        target = PathPoints.points[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Enemy.Speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            UpdatePathPoint();
        }
        Enemy.Speed = Enemy.StartSpeed;
    }
    #endregion

    #region Implementation

    private void UpdatePathPoint()
    {
        if (pathPointIndex >= PathPoints.points.Length - 1)
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
        WaveSpawner.EnemiesAlive--;
    }

    #endregion
}
