using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    public float speed;
    private int waypointIndex;

    void Start()
    {
        target = WaypointScript.points[0];
    }




    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 0.7f)
        {
            NextWaypoint();
        }
            
        transform.LookAt(target);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void NextWaypoint()
    {
        if (waypointIndex >= WaypointScript.points.Length - 1)
        {
            WaveSpawner.EnemiesAlive--;
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = WaypointScript.points[waypointIndex];
    }
}

