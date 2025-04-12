using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameManager : MonoBehaviour
{
    public static LoadGameManager _instance;
    public static LoadGameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    [SerializeField] GameObject panel;
    [SerializeField] Button save1;

    //private int saveCount;
    //public int saveSlot;
    private string timeStamp;

    public Transform save1Position;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        panel.SetActive(false);
        //saveCount = 0;
        if(DataKeeper.Instance.timeStamp1 == null)
        {
            save1.interactable = false;
        }
        else
        {
            save1.interactable = true;
            save1.GetComponentInChildren<Text>().text = DataKeeper.Instance.timeStamp1;
        }
        

    }

    private void Update()
    {
        //saveSlot = saveCount % 3 + 1;
        timeStamp = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void UpdateButton()
    {
        //switch (saveSlot)
        //{
        //    case 1:
                save1.interactable = true;
                save1.GetComponentInChildren<Text>().text = timeStamp;
                GamePlayUIController.Instance.GetDataAndSave();
        //        break;
        //    default:
        //        break;
        //}
        //saveCount++;
    }
    public void Loading()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        //SceneManager.LoadSceneAsync(4);
        //DataKeeper.Instance.Loading();
        MainMenuController.Instance.CloseMenu();
        panel.SetActive(false);
        Invoke("LoadGame", 1.0f);
    }

    public void LoadGame()
    {
        Debug.Log("Load Game");
        var playerData = SaveGameManager.Instance().LoadGame();        

        //position
        Vector3 position = JsonUtility.FromJson<Vector3>(playerData.position);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = position;

        //life
        int life = int.Parse(playerData.life);

        //inventory
        int banana = int.Parse(playerData.inventoryBanana);
        int watermelon = int.Parse(playerData.inventoryWatermelon);
        int cherry = int.Parse(playerData.inventoryCherry);
        Debug.Log("Load Game: " + banana);

        //key
        bool hasKey = bool.Parse(playerData.hasKey);

        Debug.Log("Load Game: " + hasKey);

    }

}
