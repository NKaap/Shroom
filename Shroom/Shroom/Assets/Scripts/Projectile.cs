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
    public float canAttack;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            canAttack = 1;
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
        if (canAttack == 1) {
            target.GetComponent<EnemyProperties>().enemyHealth -= tower.GetComponent<Towers>().dmgToDo;
            if (target.GetComponent<EnemyProperties>().enemyHealth <= 0) {
                target.GetComponent<EnemyProperties>().OnDeath();
                Debug.Log("Kill");
            }
            target.GetComponent<EnemyProperties>().healthSlider.value = target.GetComponent<EnemyProperties>().enemyHealth;
            Debug.Log("Shot");
        }
        canAttack += 1;
    }
    

}
