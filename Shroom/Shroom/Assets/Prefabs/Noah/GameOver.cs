using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Slider hpSlider;

    // Start is called before the first frame update
    void Start()
    {
        hpSlider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(hpSlider.value == 0)
        {
            GameOverFunction();
        }
    }

    void GameOverFunction()
    {
        SceneManager.LoadScene("GameOver");
    }
}
