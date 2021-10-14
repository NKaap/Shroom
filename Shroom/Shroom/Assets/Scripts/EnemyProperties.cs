using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int enemyHealth;
    public int moneyWhenKilled;
    //hier word de damage gedaan, en hij removed zichzelf uit de lijst in tower als hij dood gaat en destroyed zichzelf
    public void DoDamage(int damageToDo, Towers tower) {
        enemyHealth -= damageToDo;
        if(enemyHealth <= 0) {
            tower.RemoveEnemy(this);
            //GetComponent<ShopController>().money += moneyWhenKilled;
            Destroy(gameObject);
        }
    }
}
