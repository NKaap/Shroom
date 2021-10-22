using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScripts : MonoBehaviour
{
    public GameObject settingscanvas;
    public GameObject maincanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
