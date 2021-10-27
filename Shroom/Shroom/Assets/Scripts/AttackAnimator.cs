using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimator : MonoBehaviour
{
    public Animator animator;
    public GameObject mushroom;
    public GameObject punchMushroom;
    public int damage;
    //davido's edit animation
    public int animPlay;

    // Start is called before the first frame update
    void Start()
    {
        animator = mushroom.GetComponent<Animator>();
        damage = punchMushroom.GetComponent<Punch>().punchDamage;

        animPlay = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kinda works");
        if(other.gameObject.tag == "enemy")
        {
            Debug.Log("Fakka Neef");
            animator.SetBool("Attack1", true);
            animPlay = 1;
            other.gameObject.GetComponent<EnemyProperties>().enemyHealth -= damage;
            other.GetComponent<EnemyProperties>().OnDeath();
            other.GetComponent<EnemyProperties>().healthSlider.value = other.GetComponent<EnemyProperties>().enemyHealth;
        }
    }




}
