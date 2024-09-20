using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; 
        isPaused = true;
        pauseMenuUI.SetActive(true); 
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuUI.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Debug.Log(" pulsa o ");
        SceneManager.LoadScene("Tutorial"); 

        Time.timeScale = 1f; 
       
    }

    public void QuitGame()
    {
        Application.Quit(); // Salir de la aplicación
    }

}
