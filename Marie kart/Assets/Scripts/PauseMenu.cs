using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    // Pauser spillet
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    // Genoptager spillet
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    // Skifter scene tilbage til hovedmenuen
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Hvis der trykkes på escape, så pauser spillet, hvis der trykkes på escape igen, genoptages spillet.
    private void Update()
    {
        if (pauseMenu.active)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }        
    }
}


