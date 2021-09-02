using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex;
    // Start is called before the first frame update
    void Start()
    {
        target = WaypointScript.points[0];
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            NextWaypoint();
        }
    }
    void NextWaypoint()
    {
        if (wavepointIndex >= WaypointScript.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WaypointScript.points[wavepointIndex];
    }
}
