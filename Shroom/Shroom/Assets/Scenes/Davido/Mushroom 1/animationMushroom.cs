using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationMushroom : MonoBehaviour
{
    public Animator mushAnimate;
    public int atAnimation;
    public GameObject mushroom;

    // Start is called before the first frame update
    void Start()
    {
        atAnimation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Kinda works");
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("Fakka Neef");

            atAnimation = 1;
            
        }
    }

}
