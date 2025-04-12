using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataKeeper : MonoBehaviour
{
    public static DataKeeper Instance;
    [Header("Menu")]
    public float musicVolume;
    public float soundVolume;
    public bool isOgKey;

    private OptionsController optionsController;
    private float musicSlide;
    private float soundSlide;

    //[Header("Inventory")]
    //public int bananaAmount;
    //public int watermelonAmount;
    //public int cherryAmount;
    //private InventoryController inventoryController;

    //[Header("Life")]
    //public int lifeAmount;
    //private LifeController lifeController;
    public bool isTutorialDone;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        isTutorialDone = false;
    }

    public void FixedUpdate()
    {
        optionsController = OptionsController.Instance;
        optionsController.musicVolumeLevel = DataKeeper.Instance.musicVolume;
        optionsController.soundVolumeLevel = DataKeeper.Instance.soundVolume;
        optionsController.isOgKey = DataKeeper.Instance.isOgKey;

        //inventoryController = InventoryController.Instance;
        //inventoryController.bananaCount = DataKeeper.Instance.bananaAmount;
        //inventoryController.watermelonCount = DataKeeper.Instance.watermelonAmount;
        //inventoryController.cherryCount = DataKeeper.Instance.cherryAmount;

        //lifeController = LifeController.Instance;
        //lifeController.life = DataKeeper.Instance.lifeAmount;
    }

    public void Update()
    {
        //menu
        //bgm
        musicSlide = optionsController.musicVolumeLevel;
        //soundeffect
        soundSlide = optionsController.soundVolumeLevel;
        //key mapping
        isOgKey = optionsController.isOgKey;
        
        SetMusicVolume(musicSlide);
        SetSoundVolume(soundSlide);

        //inventory
        //bananaAmount = inventoryController.bananaCount;
        //watermelonAmount = inventoryController.watermelonCount;
        //cherryAmount = inventoryController.cherryCount;

        //life
        //lifeAmount = lifeController.life;
    }

    // store for music&sound volume from previous scene
    public void SetMusicVolume(float volume)
    {
        DataKeeper.Instance.musicVolume = volume;
    }
    public void SetSoundVolume(float volume)
    {
        DataKeeper.Instance.soundVolume = volume;
    }
    public Vector3 save1;
    public Vector3 save2;
    public Vector3 save3;
    public string timeStamp1;
    public void LoadGame(string timestamp, Transform playerTransform)
    {
        //if(LoadGameManager.Instance.saveSlot == 1)
        //{
        timeStamp1 = timestamp;
            save1 = playerTransform.position;
            Debug.Log("Save 1: " + playerTransform.position.ToString());
        //}

    }
    [SerializeField] GameObject player;
    public void Save1()
    {            
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        player.transform.position= save1;
    }

    public void Loading()
    {
        Invoke("Save1", 2.0f);
    }


}
