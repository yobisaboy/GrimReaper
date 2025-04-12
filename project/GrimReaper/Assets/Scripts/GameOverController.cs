using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public void NewGame()
    {
        // New game
        SceneManager.LoadScene(1);
    }
    public void MenuScene()
    {
        // Menu
        SceneManager.LoadScene(0);
    }
}
