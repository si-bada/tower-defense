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
    #endregion

    #region Fields
    private Transform target;
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
            return;
        Vector3 dir = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dir);
        Vector3 smoothRotation = Quaternion.Lerp(ToRotate.rotation, rotation, Time.deltaTime * RotSpeed).eulerAngles;
        ToRotate.rotation = Quaternion.Euler(0, smoothRotation.y, 0);
    
        if(fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / FireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }
    #endregion

    #region Implementation
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
