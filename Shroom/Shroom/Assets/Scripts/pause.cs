using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject settingscanvas;
    public GameObject pausecanvas;
    public static bool GameIsPaused = false;
    public GameObject ingamecanvas;
    public GameObject helpp;
    // Start is called before the first frame update
    void Start()
    {
        pausecanvas.SetActive(false);
        settingscanvas.SetActive(false);
        helpp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                resume();
            }
            else
            {
                Pause();
            }

        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("sjoerd!");
    }
    public void resume()
    {
        ingamecanvas.SetActive(true);
        Time.timeScale = 1;
        pausecanvas.SetActive(false);
        settingscanvas.SetActive(false);
        GameIsPaused = false;
    }
    void Pause()
    {
        pausecanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ingamecanvas.SetActive(false);
    }
    public void backpause()
    {
        pausecanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void help()
    {
        helpp.SetActive(true);
        this.gameObject.SetActive(false);
        
    }
    public void settings()
    {
        settingscanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
