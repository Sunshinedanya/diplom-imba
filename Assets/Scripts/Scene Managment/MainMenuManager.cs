using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StarGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GetToMainMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
