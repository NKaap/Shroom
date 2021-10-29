using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    //Money and text for your Towers
    [Header("Health")]  
    public Text moneyText;
    public Text moneyTextUI;
    public int money;

    //Needed for Shop
    [Header("Raycast Settings")]
    private Vector3 raycastHitPostion;
    public GameObject shopCanvas;
    public GameObject signRaycast;
    public RaycastHit raycastHit;
    public GameObject moneyGameUI;

    //Towers
    [Header("Towers")]
    public GameObject punch;
    public GameObject jump;
    public GameObject shoot;
    public GameObject spray;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(shopCanvas.activeInHierarchy == true)
        {
            moneyGameUI.SetActive(false);
        }
        else
        {
            moneyGameUI.SetActive(true);
        }
        //Weergave van geld op je scherm
        moneyText.text = money.ToString();

        moneyTextUI.text = moneyText.text;
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
            moneyGameUI.SetActive(false);
        }
    }



    public void Punch()
    {
        if (money >= punch.GetComponent<Towers>().costs)
        {
            money -= punch.GetComponent<Towers>().costs;
            Debug.Log("Punch Spawned");
            Instantiate(punch, raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
            moneyGameUI.SetActive(true);
        }
    }

    public void Jump()
    {
        if (money >= jump.GetComponent<Towers>().costs)
        {
            money -= jump.GetComponent<Towers>().costs;
            Debug.Log("Jump Spawned");
            Instantiate(jump, raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
            moneyGameUI.SetActive(true);
        }
    }

    public void Shoot()
    {
        if (money >= shoot.GetComponent<Towers>().costs)
        {
            money -= shoot.GetComponent<Towers>().costs;
            Debug.Log("Shoot Spawned");
            Instantiate(shoot, raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
            moneyGameUI.SetActive(true);
        }
    }

    public void Spray()
    {
        if (money >= spray.GetComponent<Towers>().costs)
        {
            money -= spray.GetComponent<Towers>().costs;
            Debug.Log("Spray Spawned");
            Instantiate(spray, raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
            moneyGameUI.SetActive(true);
        }
    }

    public void Bomb()
    {
        if (money >= bomb.GetComponent<Towers>().costs)
        {
            money -= bomb.GetComponent<Towers>().costs;
            Debug.Log("Bomb Spawned");
            Instantiate(bomb, raycastHitPostion, Quaternion.identity);
            shopCanvas.SetActive(false);
            Destroy(signRaycast);
            moneyGameUI.SetActive(true);
        }
    }

    public void DestroySign()
    {
        Destroy(signRaycast);
    }
}
