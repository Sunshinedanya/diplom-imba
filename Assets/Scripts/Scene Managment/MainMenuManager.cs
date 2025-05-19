using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject OptionsUI;
    
    public void StarGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void OpenOptions()
    {
        OptionsUI.SetActive(true);
    }
    
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            OptionsUI.SetActive(false);
    }
}
