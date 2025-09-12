using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIEvents : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void StartNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
                mainMenu.SetActive(true);
            }
            else if (mainMenu.activeSelf)
            {
                mainMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
