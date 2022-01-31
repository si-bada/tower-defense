using System;
using UnityEngine;

public class Turret : MonoBehaviour
{
    #region Script Parameters
    public float range = 15f;
    public float FireRate = 1f;
    public float RotSpeed = 10f;
    public string enemyTag = "Enemy";
    public Transform ToRotate;
    public GameObject BulletPrefab;
    public Transform FirePoint;

    [Header("Laser Stuff")]
    public bool UseLaser = false;
    public LineRenderer LaserLineRenderer;
    public int DamageOverTime = 75;
    public float SlowRatio = 0.5f;
    #endregion

    #region Fields
    private Transform target;
    private Enemy enemyTarget;
    private float fireCountDown;
    #endregion

    #region Unity Methods
    private void Start()
    {
        InvokeRepeating("UpdateTarget",0f, 0.5f);
    }

    private void Update()
    {
        if (target == null)
        {
            if(UseLaser)
            {
                if(LaserLineRenderer.enabled)
                {
                    LaserLineRenderer.enabled = false;
                }
            }
            return;
        }
        LockTarget();

        if(UseLaser)
        {
            Laser();
        }
        else
        {
            if(fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / FireRate;
            }
            fireCountDown -= Time.deltaTime;
        }
    }

    #endregion

    #region Implementation

    private void Laser()
    {
        enemyTarget.TakeDamage(GameManager.sIntance.configuration.GetHitDamage(enemyTarget.Type, TurretType.LaserBeam) * Time.deltaTime);
        enemyTarget.Slow(SlowRatio);
        if (!LaserLineRenderer.enabled)
        {
            LaserLineRenderer.enabled = true;
        }
        LaserLineRenderer.SetPosition(0, FirePoint.position);
        LaserLineRenderer.SetPosition(1, target.position);
    }

    private void LockTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        Vector3 smoothRotation = Quaternion.Lerp(ToRotate.rotation, rotation, Time.deltaTime * RotSpeed).eulerAngles;
        ToRotate.rotation = Quaternion.Euler(0, smoothRotation.y, 0);
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if(distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = enemy;
            }
        }

        if(closestEnemy != null && minDistance <= range)
        {
            target = closestEnemy.transform;
            enemyTarget = closestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    #endregion
}
