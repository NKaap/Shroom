using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateTowerScript : MonoBehaviour
{
    //Needed for Shop
    [Header("Raycast Settings")]
    private Vector3 raycastHitPostion;
    public GameObject rotateCanvas;
    public GameObject hittedTower;
    public RaycastHit raycastHit;
    public GameObject moneyGameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                    if (raycastHit.collider.CompareTag("Tower"))
                    {
                        Debug.Log("Clicked On Tower");
                        raycastHitPostion = raycastHit.transform.position;
                        hittedTower = raycastHit.transform.gameObject;
                    }
                }
            }
            if(rotateCanvas.activeInHierarchy == true)
            {
                if (raycastHit.collider.CompareTag("Untagged"))
                {
                    rotateCanvas.SetActive(false);
                }
            }
        }
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "Tower")
        {
            rotateCanvas.SetActive(true);
            moneyGameUI.SetActive(false);
        }
    }
    public void RotateLeft()
    {
        hittedTower.transform.Rotate(0, -90, 0);
    }
    public void RotateRight()
    {
        hittedTower.transform.Rotate(0, 90, 0);
    }
}
