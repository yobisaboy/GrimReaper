using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] public GameObject loading;
    [SerializeField] public GameObject tutorial1;
    [SerializeField] public GameObject tutorial2;
    [SerializeField] public GameObject tutorial3;
    [SerializeField] public GameObject tutorial4;
    void Start()
    {
        SoundController.instance.Play("NewStart");
        tutorial1.SetActive(false);
        tutorial2.SetActive(false);
        tutorial3.SetActive(false);
        tutorial4.SetActive(false);
        loading.SetActive(true);
        Invoke("DisableLoading", 2.0f);

    }

    void DisableLoading()
    {
        loading.SetActive(false);
        tutorial1.SetActive(true);
        Invoke("DisableTutorial1", 2.0f);
    }

    void Update()
    {

        // tutorial 2
        if (loading.activeSelf == false && tutorial1.activeSelf == false && GameObject.FindGameObjectWithTag("Item") != null)
        {
            tutorial2.SetActive(true);
        }
        else
        {
            tutorial2.SetActive(false);
        }

        // tutorial 3
        if (GameObject.FindGameObjectWithTag("Item") == null && GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            tutorial3.SetActive(true);
        }
        else
        {
            tutorial3.SetActive(false);
        }

        // finsih tutorial
        if (GameObject.FindGameObjectWithTag("Item") == null && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            
            tutorial4.SetActive(true);
            Invoke("FinishTutorial", 4.0f);
        }
        
    }

    void DisableTutorial1()
    {
        tutorial1.SetActive(false);
    }

    void FinishTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


}
