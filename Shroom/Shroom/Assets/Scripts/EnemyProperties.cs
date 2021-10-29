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
    private GameObject Particle;
    //hier word de damage gedaan, en hij removed zichzelf uit de lijst in tower als hij dood gaat en destroyed zichzelf
    public void DoDamage(int damageToDo, Towers tower) {
        enemyHealth -= damageToDo;
        healthSlider.value = enemyHealth;
        if (enemyHealth <= 0)
        {
            tower.RemoveEnemy(this);
            OnDeath();
        }
    }
    public void OnDeath()
    {
        WaveSpawner.EnemiesAlive--;
        Debug.Log("Hij is dood!");
        Destroy(gameObject);
        GameObject.Find("shopcontroller").GetComponent<ShopController>().money += moneyWhenKilled;
    }
}

