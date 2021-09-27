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



    public void Punch()
    {
        if (money >= towers[0].GetComponent<Punch>().punchCosts)
        {
            money -= towers[0].GetComponent<Punch>().punchCosts;
            Debug.Log("Punch Spawned");
            Instantiate(towers[0], raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
        }
    }

    public void Jump()
    {
        if (money >= towers[1].GetComponent<Jump>().jumpCosts)
        {
            money -= towers[1].GetComponent<Jump>().jumpCosts;
            Debug.Log("Jump Spawned");
            Instantiate(towers[1], raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
        }
    }

    public void Shoot()
    {
        if (money >= towers[2].GetComponent<Shooter>().shooterCosts)
        {
            money -= towers[2].GetComponent<Shooter>().shooterCosts;
            Debug.Log("Shoot Spawned");
            Instantiate(towers[2], raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
        }
    }

    public void Spray()
    {
        if (money >= towers[3].GetComponent<Spray>().sprayCosts)
        {
            money -= towers[3].GetComponent<Spray>().sprayCosts;
            Debug.Log("Spray Spawned");
            Instantiate(towers[3], raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
        }
    }

    public void Bomb()
    {
        if (money >= towers[4].GetComponent<Bomb>().bombCosts)
        {
            money -= towers[4].GetComponent<Bomb>().bombCosts;
            Debug.Log("Bomb Spawned");
            Instantiate(towers[4], raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
        }
    }

    public void DestroySign()
    {
        Destroy(signRaycast);
    }
}
