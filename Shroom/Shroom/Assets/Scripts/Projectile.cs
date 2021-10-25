using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject enemy;
    public int damageAmount;
    public GameObject tower;

    public void Start()
    {
       damageAmount = tower.GetComponent<Shooter>().shooterDamage;
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        Destroy(gameObject);
        target.gameObject.GetComponent<EnemyProperties>().TakeDamage(damageAmount);
    }
    

}
