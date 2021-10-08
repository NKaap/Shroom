using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int enemyHealth;
    public GameObject enemy;
    public int moneyWhenKilled;
    public Towers towers;

    public void DoDamage(int damageToDo) {
        enemyHealth -= damageToDo;
        if(enemyHealth <= 0) {
            Destroy(enemy);
            towers.EnemyDied();
            GetComponent<ShopController>().money += moneyWhenKilled;
        }
    }
}
