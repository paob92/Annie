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

    public void QuitGame()
    {
        Application.Quit();
    } 
   
} 
