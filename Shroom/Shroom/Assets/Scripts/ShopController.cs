using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    //Money and text for your Towers
    public Text moneyText;
    public float money;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Weergave van geld op je scherm
        moneyText.text = money.ToString();

    }
}
