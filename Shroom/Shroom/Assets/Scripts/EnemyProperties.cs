using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProperties : MonoBehaviour
{
    public int enemyHealth;
    public int moneyWhenKilled;
    public GameObject money;
    public Slider healthSlider;
    //hier word de damage gedaan, en hij removed zichzelf uit de lijst in tower als hij dood gaat en destroyed zichzelf
    public void DoDamage(int damageToDo, Towers tower) {
        enemyHealth -= damageToDo;
        if (enemyHealth <= 0) {
            tower.RemoveEnemy(this);
            //GetComponent<ShopController>().money += moneyWhenKilled;
            Destroy(gameObject);
        }
    }
/*public void DoDamage(int damageToDo, Towers tower) {
    {
        enemyHealth -= tower.dmgToDo;
        if (enemyHealth == 0) {
            tower.RemoveEnemy(this);
            //GetComponent<ShopController>().money += moneyWhenKilled;
            Destroy(this.gameObject);
        }
    }
}
*/

public void TakeDamage(int damageAmount)
    {
        enemyHealth -= damageAmount;
        if (enemyHealth <= 0)
        {
            Die();
        }
        healthSlider.value = enemyHealth;
    }
    
    public void Die()
    {
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
        Debug.Log("Hij is dood!");
        GameObject.Find("shopcontroller").GetComponent<ShopController>().money += moneyWhenKilled;

        //enemyHealth -= damageAmount;
    }





}


