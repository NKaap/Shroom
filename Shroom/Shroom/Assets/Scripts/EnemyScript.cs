using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;

    public Transform target;
    private int waypointindex = 0;

    private void Start()
    {
        target = WaypointScript.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (waypointindex >= WaypointScript.points.Length - 1)
        {
            EndPath();
            return;
        }
        waypointindex++;
        target = WaypointScript.points[waypointindex];
    }
    void EndPath()
    {
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
