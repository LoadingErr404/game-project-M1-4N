using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject controls;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
        controls.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }
       
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
        
    }

    public void Resume()
    {
       pauseMenuUI.SetActive(false);
       controls.SetActive(false);
       Time.timeScale = 1f;
       GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("0 - main_menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
