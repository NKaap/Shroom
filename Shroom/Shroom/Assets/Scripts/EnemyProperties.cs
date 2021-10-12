using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int enemyHealth;
    public int moneyWhenKilled;

    public void DoDamage(int damageToDo, Towers tower) {
        enemyHealth -= damageToDo;
        if(enemyHealth <= 0) {
            tower.RemoveEnemy(this);
            //GetComponent<ShopController>().money += moneyWhenKilled;
            Destroy(gameObject);
        }
    }
}
