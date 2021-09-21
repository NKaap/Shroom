using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public int enemyHealth;
    public GameObject enemy;
    public float moneyWhenKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0) {
            Destroy(enemy);
            GetComponent<ShopController>().money += moneyWhenKilled;
        }
    }
}
