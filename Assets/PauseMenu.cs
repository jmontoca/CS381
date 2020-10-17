using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//bug with going to main menu and then starting the game

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseUI;
    public GameObject playerUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        playerUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
