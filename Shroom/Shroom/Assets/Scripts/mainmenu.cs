using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenu : MonoBehaviour
{
    public Transform[] targets;
    public float speed;
    public int index;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targets[index].position) < 0.4)

        {
            index += 1;

            if (index == targets.Length)
            {
                index = 0;
            }
        }

        transform.LookAt(targets[index]);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}

