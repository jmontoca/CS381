using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool isDead = false;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits_Scene");
    }

    public void MenuStart()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level_1"); //needs to change to adjust for different levels being loaded in
    }

    public void GameOver()
    {
        if(isDead == false)
        {
            isDead = true;
            SceneManager.LoadScene("Game_Over");
        }
    }

    public void Completion()
    {
        SceneManager.LoadScene("Level_Complete");
    }
}
