using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    [SerializeField] private Animator animationController;

    public float maxHealth = 100;
    public float currentHealth;
    public int dmgToDo;
    public bool canAttack;

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

            animationController.SetBool("Attack", true);

            

            GetComponent<EnemyProperties>().enemyHealth -= dmgToDo;

            //GetComponent<EnemyProperties>().enemyHealth -= dmgToDo;

        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "enemy") {
            animationController.SetBool("Attack", false);
        }
    }

}
