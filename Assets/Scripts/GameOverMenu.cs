using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public static bool resetScore = false; 
    public void Restart()
    {
        resetScore = true;
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        resetScore = true;
        SceneManager.LoadScene("StartScene");
    }
    public void Quit()
    {
        resetScore = true;
        Application.Quit();
    }
}