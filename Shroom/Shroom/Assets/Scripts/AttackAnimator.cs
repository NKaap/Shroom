using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimator : MonoBehaviour
{
    public Animator animator;
    public GameObject mushroom;

    // Start is called before the first frame update
    void Start()
    {
        animator = mushroom.GetComponent<Animator>();
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
        }
    }




}
