using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController _instance;
    public static MainMenuController Instance
    {
        get
        {
            return _instance;
        }
    }
    [SerializeField] GameObject menu;
    [SerializeField] GameObject options;
    [SerializeField] GameObject loadGame;
    private void Awake()
    {
        _instance = this;
    }
    public void Start()
    {

        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "GameWin")
        {
            options.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
            options.SetActive(false);
        }

    }

// open main menu
    public void OpenMenu()
    {
        SoundController.instance.Play("Click");
        menu.SetActive(true);
    }

//close main menu
    public void CloseMenu()
    {
        SoundController.instance.Play("Click");
        menu.SetActive(false);
    }

//start new game
    public void NewGame()
    {
        SoundController.instance.Play("Click");
        SceneManager.LoadScene(1);
    }

//load saved game
    public void LoadGame()
    {
        // Load game
        SoundController.instance.Play("Click");
        loadGame.SetActive(true);
    }

//open options panel
    public void OpenOptions()
    {
        SoundController.instance.Play("Click");
        options.SetActive(true);
    }

//close options panel
    public void CloseOptions()
    {
        SoundController.instance.Play("Click");
        options.SetActive(false);
    }

//exit game
    public void ExitGame()
    {
        SoundController.instance.Play("Click");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
