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
        target.GetComponent<EnemyProperties>().enemyHealth -= tower.GetComponent<Shooter>().shooterDamage;
        target.GetComponent<EnemyProperties>().OnDeath();
        target.GetComponent<EnemyProperties>().healthSlider.value = target.GetComponent<EnemyProperties>().enemyHealth;
        Debug.Log("Shot");
        Destroy(this.gameObject);
    }
    

}
