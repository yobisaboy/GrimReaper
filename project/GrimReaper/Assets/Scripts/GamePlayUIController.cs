using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    public static GamePlayUIController Instance;

    [SerializeField] GameObject pauseMsg;
    [SerializeField] GameObject saveMsg;
    [SerializeField] Button saveBtn;
    public Slider health;

    [SerializeField] GameObject inventory;
    [SerializeField] GameObject minimap;

    [SerializeField] GameObject Key;
    [SerializeField] GameObject noKey;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    public void Start()
    {
        pauseMsg.SetActive(false);
        saveMsg.SetActive(false);
        //inventory.SetActive(false);
        minimap.SetActive(false);
        //Debug.Log(Application.persistentDataPath + "/MySaveData.txt");
    }

    private void Update()
    {
        //if tag "key" is found, show key icon
        if (GameObject.FindGameObjectWithTag("Key"))
        {
            Key.SetActive(false);
            noKey.SetActive(true);
        }
        else
        {
            Key.SetActive(true);
            noKey.SetActive(false);
        }
    }

    public void PauseGame()
    {
        SoundController.instance.Play("Click");
        pauseMsg.SetActive(true);
        Time.timeScale = 0;
        GameObject.Find("Player").GetComponent<PlayerAnimation>().enabled = false;
        GameObject.Find("AudioManager").GetComponent<AudioListener>().enabled = false;

    }

//resume game after pause
    public void ResumeGame()
    {
        SoundController.instance.Play("Click");
        pauseMsg.SetActive(false);
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<PlayerAnimation>().enabled = true;
        GameObject.Find("AudioManager").GetComponent<AudioListener>().enabled = true;
    }

//save game
    public void SaveGame()
    {
        SoundController.instance.Play("Click");
        GetDataAndSave();
        saveMsg.SetActive(true);
        saveMsg.SetActive(true);
        saveBtn.interactable = false;
        saveBtn.interactable = true;
        Invoke("CloseSaveMsg", 1);

    }

    public void GetDataAndSave()
    {  
        int level = SceneManager.GetActiveScene().buildIndex;
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //count how many object with tag "Life"
        int life = GameObject.FindGameObjectsWithTag("Life").Length;

        int banana = 0;
        int watermelon = 0;
        int cherry = 0;
        for (int i = 0; i < InventoryManager.Instance.inventoryItems.Length; i++)
        {
            if (InventoryManager.Instance.inventoryItems[i] == 'B')
            {
                banana++;
            }
            else if (InventoryManager.Instance.inventoryItems[i] == 'W')
            {
                watermelon++;
            }
            else if (InventoryManager.Instance.inventoryItems[i] == 'C')
            {
                cherry++;
            }
        }
        
        //int life = DataKeeper.Instance.lifeAmount;
        //int banana = DataKeeper.Instance.bananaAmount;
        //int watermelon = DataKeeper.Instance.watermelonAmount;
        //int cherry = DataKeeper.Instance.cherryAmount;
        int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        bool hasKey = KeyController._instance.hasKey;
        //Debug.Log(banana);
        SaveGameManager.Instance().SaveGame(level, playerTransform, life, banana, watermelon, cherry, enemies, hasKey);
        DataKeeper.Instance.LoadGame(System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), playerTransform);
    }
//close the noti after save game
    public void CloseSaveMsg()
    {
        saveMsg.SetActive(false);
    }

//open&close inventory panel
    public void Inventory()
    {
        SoundController.instance.Play("Click");
        if (inventory.activeSelf)
        {
            inventory.SetActive(false);
        }
        else
        {
            inventory.SetActive(true);
        }
    }

    //open&close minimap panel
    public void Minimap()
    {
        SoundController.instance.Play("Click");
        if (minimap.activeSelf)
        {
            minimap.SetActive(false);
        }
        else
        {
            minimap.SetActive(true);
        }
    }

    public void UpdateHealth(float value)
    {
        health.GetComponent<Slider>().value += value;
    }






}

