using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    public float range;
    public Transform turretHead;
    public GameObject projectilePrefab;
    public Transform firepoint;

    public float fireRate = 1;
    private float fireCountDown = 0;

    public string enemyTag = "enemy";

    void Start()
    {
        InvokeRepeating("EnemyTarget", 0f, 0.5f);
    }

    void EnemyTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        //turretHead.LookAt(new Vector3(target.position.x, turretHead.position.y, target.position.z));

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject projectileGameObject = (GameObject)Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
        Projectile projectile = projectileGameObject.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.Seek(target);
        }
    }
}
