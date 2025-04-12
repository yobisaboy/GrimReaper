using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    GamePlayUIController GamePlayUIController;
    bool hasKey = false;

    private void Start()
    {

    }
    public void Update()
    {
        hasKey = KeyController._instance.hasKey;
    }
    private void OnTriggerEnter(Collider collision)
    {
        //if player reach the door, go to the next level
        if (collision.gameObject.tag == "Player" && hasKey)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void LoadNextLevel(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
