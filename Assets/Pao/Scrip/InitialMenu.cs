using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    
    public void Play()
    {
       UI.SetActive(false); 
    }

    public void LoadMainMenu()
    {
        Debug.Log(" pulsa o ");
        SceneManager.LoadScene("Tutorial");

        Time.timeScale = 1f;

    }


    public void QuitGame()
    {
        Debug.Log("Cerrando Juego");
        Application.Quit();
    } 
   
} 
