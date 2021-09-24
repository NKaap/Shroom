using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    
    //Money and text for your Towers
    [Header("Health")]  
    public Text moneyText;
    public int money = 100;

    //Needed for Shop
    [Header("Raycast Settings")]
    private Vector3 raycastHitPostion;
    public GameObject shopCanvas;
    public GameObject signRaycast;
    public RaycastHit raycastHit;

    //Towers
    [Header("Towers")]
    public GameObject[] towers;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Weergave van geld op je scherm
        moneyText.text = money.ToString();
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("It works");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                    if (raycastHit.collider.CompareTag("Sign"))
                    {
                        raycastHitPostion = raycastHit.transform.position;
                        signRaycast = raycastHit.transform.gameObject;
                    }
                }
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "Sign")
        {
            shopCanvas.SetActive(true);
        }
    }



    public void Shoot()
    {
        if (money >= towers[0].GetComponent<Shooter>().shooterCosts)
        {
            money -= towers[0].GetComponent<Shooter>().shooterCosts;
            Debug.Log("Spawned");
            Instantiate(towers[0], raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
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
        if (GetComponent<ShopController>().money >= GetComponent<Spray>().sprayCosts)
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
        if (GetComponent<ShopController>().money >= GetComponent<Bomb>().bombCosts)
        {
            Instantiate(towers[4], this.gameObject.transform);
        }
    }

    public void DestroySign()
    {
        Destroy(signRaycast);
    }
}
