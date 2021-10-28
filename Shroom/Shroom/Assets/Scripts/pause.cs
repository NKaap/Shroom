using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public GameObject settingscanvas;
    public GameObject maincanvas;
    public GameObject pausecanvas;
    public static bool GameIsPaused = false;
    public GameObject ingamecanvas;
    // Start is called before the first frame update
    void Start()
    {
        
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

    }

}
