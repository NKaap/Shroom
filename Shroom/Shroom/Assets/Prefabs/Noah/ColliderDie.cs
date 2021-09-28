using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ik heb je aangeraakt");
        if (gameObject.tag == "Enemy")
        {
            Debug.Log("Gatcha Bitch");
            Destroy(gameObject);
        }
    }
}
