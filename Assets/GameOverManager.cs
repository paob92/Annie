using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public void ToLvlTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void ToLvl1()
    {
        SceneManager.LoadScene("Game");
    }
    public void ToLvl2()
    {
        SceneManager.LoadScene("Level2");
    }
}