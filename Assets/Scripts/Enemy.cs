using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int pathPointIndex = 0;


    private void Start()
    {
        target = PathPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            UpdatePathPoint();
        }
    }

    private void UpdatePathPoint()
    {
        if(pathPointIndex >= PathPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        pathPointIndex++;
        target = PathPoints.points[pathPointIndex];
    }
}
