using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class camera : MonoBehaviour
{
    public Transform cam;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        cam.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
