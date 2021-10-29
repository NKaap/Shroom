using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerRotation : MonoBehaviour
{
    public GameObject rotateCanvas;

    [Header("Raycast")]
    private Vector3 raycastHitPostion;
    public GameObject clickedTower;
    public RaycastHit raycastHit;
    public GameObject shopCanvas;
    public GameObject sign;
    private int costss;

    // Update is called once per frame
    void Update()
    { 
        if (rotateCanvas.activeInHierarchy == true)
        {
            shopCanvas.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Yessir");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                    if (raycastHit.collider.CompareTag("Tower"))
                    {
                        Debug.Log("Tower Geraakt");
                        raycastHitPostion = raycastHit.transform.position;
                        clickedTower = raycastHit.transform.gameObject;
                        //rotateCanvas.transform.position = clickedTower.transform.position;
                    }
                }
            }
        }
    }
    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "Tower")
        {
            rotateCanvas.SetActive(true);
        }
    }

    public void RotateLeft()
    {
        clickedTower.transform.Rotate(0, -90, 0);
        rotateCanvas.SetActive(false);
    }
    public void RotateRight()
    {
        clickedTower.transform.Rotate(0, 90, 0);
        rotateCanvas.SetActive(false);

    }

    public void SellButton()
    {
        costss = clickedTower.GetComponent<Towers>().costs;
        costss /= 2;
        GameObject.Find("shopcontroller").GetComponent<ShopController>().money += costss;
        Destroy(clickedTower);
        Instantiate(sign, raycastHitPostion, Quaternion.identity);
        rotateCanvas.SetActive(false);
    }
}
