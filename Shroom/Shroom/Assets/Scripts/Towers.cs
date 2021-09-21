using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public float MaxHealth = 100;
    public float CurrentHealth;
    public int dmgToDo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "enemy") {
            other.GetComponent<EnemyProperties>().enemyHealth -= dmgToDo;
        }
    }
}
