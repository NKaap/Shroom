using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignScript : MonoBehaviour
{
    public GameObject shopCanvas;
    public GameObject[] towers;
    private void OnMouseDown()
    {
        if (Physics.queriesHitTriggers)
        {
            shopCanvas.SetActive(true);
        }
    }
    public void Shoot()
    {
        if (GetComponent<ShopController>().money >= GetComponent<Shooter>().shooterCosts)
        {
            Instantiate(towers[0], this.gameObject.transform);
        }
    }

    public void Punch()
    {
        if (GetComponent<ShopController>().money >= GetComponent<Punch>().punchCosts)
        {
            Instantiate(towers[1], this.gameObject.transform);
        }
    }

    public void Spray()
    {
        if (GetComponent<ShopController>().money >= GetComponent<Spray>(). sprayCosts)
        {
            Instantiate(towers[2], this.gameObject.transform);
        }
    }

    public void Jump()
    {
        if (GetComponent<ShopController>().money >= GetComponent<Jump>().jumpCosts)
        {
            Instantiate(towers[3], this.gameObject.transform);
        }
    }

    public void Bomb()
    {
        if (GetComponent<ShopController>().money >= GetComponent<Bomb>(). bombCosts)
        {
            Instantiate(towers[4], this.gameObject.transform);
        }
    }
}
