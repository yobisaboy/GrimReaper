using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestChannel : MonoBehaviour, IObserver
{
    public static QuestChannel Instance;
    bool is1stItem, is1stEnemy;
    [SerializeField] private PlayerController _playerController;
    

    void Awake()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (!Instance) Instance = this;
    }

    void OnEnable()
    {
        _playerController.AddObserver(this);
    }
    void OnDisable()
    {
        _playerController.RemoveObserver(this);
    }

    void Start()
    {
        is1stItem = false;
        is1stEnemy = false;
    }

    void Update()
    {

   
    }
    public void Reward()
    {
        SoundController.instance.Play("NewStart");
        Vector3 position = new Vector3(200, 20, 0);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = position;
    }
    public void OnNotify(QuestState state, Quest quest)
    {
        switch (state)
        {
            case QuestState.Pending:
                quest.state = QuestState.Pending;
                ChangeToPending(quest);
                //Debug.Log(quest.name + " is " + quest.state);
                break;
            case QuestState.Active:
                quest.state = QuestState.Active;
                ChangeToActive(quest);
                //Debug.Log(quest.name + " is " + quest.state);
                break;
            case QuestState.Completed:               
                quest.state = QuestState.Completed;
                ChangeToCompleted(quest);
                //Debug.Log(quest.name + " is " + quest.state);
                break;

            default:
                break;
        }

    }

    public void ChangeToPending(Quest quest)
    {
        if (quest.id == 2)
        {
            AchievementManager.Instance.title2.GetComponent<Text>().color = new Color(0, 0, 0, 0.20f);
        }
        if (quest.id == 3)
        {
            AchievementManager.Instance.title3.GetComponent<Text>().color = new Color(0, 0, 0, 0.20f);
        }
    }

    public void ChangeToActive(Quest quest)
    {
        if (quest.id == 2)
        {
            AchievementManager.Instance.title2.GetComponent<Text>().color = new Color(0, 0, 0, 0.78f);
        }
        if (quest.id == 3)
        {
            AchievementManager.Instance.title3.GetComponent<Text>().color = new Color(0, 0, 0, 0.78f);
        }
    }

    public void ChangeToCompleted(Quest quest)
    {
        if(quest.id == 1)
        {
            AchievementManager.Instance.tick1.SetActive(true);
        }
        if(quest.id == 2)
        {
            if (!is1stItem)
            {
                AchievementManager.Instance.FlashPanel();
                is1stItem = true;
            }
            AchievementManager.Instance.tick2.SetActive(true);
            
        }
        if(quest.id == 3)
        {
            if (!is1stEnemy)
            {
                AchievementManager.Instance.FlashPanel();
                is1stEnemy = true;
            }
            AchievementManager.Instance.tick3.SetActive(true);
            
        }
    }



    public void TutorialScene()
    {
        //Debug.Log("Tutorial Scene");
        DataKeeper.Instance.isTutorialDone = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }




}
