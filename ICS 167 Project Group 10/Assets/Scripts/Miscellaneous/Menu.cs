using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Menu script
 * @ Author: Samantha Purganan
 */
public class Menu : MonoBehaviour
{
     
    public static bool isSingle { get; set; }

    public void SingleGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        isSingle = true;
    }

    public void MultiGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        isSingle = false;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
