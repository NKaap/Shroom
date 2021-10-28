using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
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
    void Pause()
    {
        pausecanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ingamecanvas.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("sjoerd!");
    }

    public void CloseCanvas()
    {
        this.gameObject.SetActive(false);
    }

    public void Level1()
    {
        SceneManager.LoadScene("level1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("level 2");
    }

    public void settings()
    {
        settingscanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void back()
    {
        maincanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void backpause()
    {
        pausecanvas.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void resume()
    {
        ingamecanvas.SetActive(true);
        Time.timeScale = 1;
        pausecanvas.SetActive(false);
        settingscanvas.SetActive(false);
        GameIsPaused = false;
    }
    public void help()
    {

    }

}
