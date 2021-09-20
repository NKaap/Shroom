using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptWalk2 : MonoBehaviour
{
    public float movementSpeed = 10f;

    public RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3();
        move.x = h;
        move.z = v;

        transform.Translate(move * movementSpeed * Time.deltaTime);
    }
}
