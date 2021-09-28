using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDamage : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ik heb je aangeraakt");
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("Gatcha Bitch");
            slider.value -= 10;
        }
    }
}
