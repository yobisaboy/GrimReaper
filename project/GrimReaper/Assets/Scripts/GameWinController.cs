using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinController : MonoBehaviour
{
    public void MenuScene()
    {
        // Menu
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        // Exit
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
