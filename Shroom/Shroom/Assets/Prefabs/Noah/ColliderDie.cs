using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderDie : MonoBehaviour
{
    public GameObject shopCanvas;
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
