using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * PauseMenu Script
 * @Author: Samantha Purganan
 */
public class PauseMenu : MonoBehaviour
{

    public static bool PausedGame = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            if (PausedGame)
            {
                Resume();
            } else
            {
                Pause();
            }
         }
    }

    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PausedGame = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PausedGame = true;
    }

    public void LoadMenuSingle()
    {
        //Unlock in the future if you are going to have animations for the Menu Art! -sam
        //Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadMenu()
    {
        if(Menu.isSingle)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
