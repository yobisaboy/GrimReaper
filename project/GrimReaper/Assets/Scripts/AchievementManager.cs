using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    [SerializeField] public GameObject panel;
    [SerializeField] public GameObject tick1;
    [SerializeField] public GameObject tick2;
    [SerializeField] public GameObject tick3;
    [SerializeField] public GameObject title2;
    [SerializeField] public GameObject title3;
    [SerializeField] public GameObject reward;
    [SerializeField] public GameObject rewardText;
    [SerializeField] public GameObject hint;
    [SerializeField] public GameObject pendingNoti;
    [SerializeField] public GameObject doneNoti;

    void Awake()
    {
        if (!Instance) Instance = this;
    }
    void Start()
    {
        hint.SetActive(false);
        panel.SetActive(false);
        tick1.SetActive(false);
        tick2.SetActive(false);
        tick3.SetActive(false);
        rewardText.SetActive(false);
        pendingNoti.SetActive(false);
        doneNoti.SetActive(false);
        
    }

    private void Update()
    {
        if(hint != null)
        {
            if (tick1.activeSelf == false)
            {
                hint.SetActive(true);
            }
            else
            {
                hint.SetActive(false);
            }
        }
        

        //if tick1 is active
        if (tick1.activeSelf == true && tick2.activeSelf == true && tick3.activeSelf == true)
        {
            reward.GetComponent<Button>().interactable = true;
        }
        else
        {             
            reward.GetComponent<Button>().interactable = false;
        }

        if (GameObject.FindGameObjectsWithTag("Tick").Length > 1)
        {
            Debug.Log("Noti");
            ShowNoti();
        }


    }

    public void ShowAchievementPanel()
    {
        SoundController.instance.Play("Click");
        if (panel.activeSelf == false)
        {
            panel.SetActive(true);
        }
        else if (panel.activeSelf == true)
        {
            panel.SetActive(false);
        }
    }

    public void CloseHint()
    {
        SoundController.instance.Play("Click");
        Destroy(hint);
        
    }

    public void DestroyPNoti()
    {
        Destroy(pendingNoti);
    }

    public void DestroyDNoti()
    {
        Destroy(doneNoti);
    }

    public void ShowNoti()
    {
        SoundController.instance.Play("NewStart");
        if(GameObject.FindGameObjectsWithTag("Tick").Length == 2)
        {
            pendingNoti.SetActive(true);
            Invoke("DestroyPNoti", 2.0f);
        }
        else if (GameObject.FindGameObjectsWithTag("Tick").Length == 3)
        {
            doneNoti.SetActive(true);
            Invoke("DestroyDNoti", 2.0f);
        }
        
    }
    public void ShowRewardText()
    {
        rewardText.SetActive(true);
        Invoke("HideRewardText", 2.0f);
    }

    public void HideRewardText()
    {
        rewardText.SetActive(false);
    }

    public void FlashPanel()
    {
        panel.SetActive(true);
        Invoke("ClosePanel", 0.01f);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
