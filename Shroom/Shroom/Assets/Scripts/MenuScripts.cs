using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
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
}
