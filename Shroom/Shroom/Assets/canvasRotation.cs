using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasRotation : MonoBehaviour
{
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Transform>();
        transform.LookAt(cam);
    }
}
