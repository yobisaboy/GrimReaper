using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class OptionsController : MonoBehaviour
{
    public static OptionsController _instance;
    public static OptionsController Instance
    {
        get
        {
            return _instance;
        }
    }

    private DataKeeper dataKeeper;

    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject keyOption1On;
    [SerializeField] GameObject keyOption2On;
    [SerializeField] GameObject keyOption1Off;
    [SerializeField] GameObject keyOption2Off;
    [SerializeField] GameObject musicSlide;
    [SerializeField] GameObject soundSlide;
    public float musicVolumeLevel;
    public float soundVolumeLevel;
    public bool isOgKey;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            

        }


    }

    public void Start()
    {
        
        dataKeeper = DataKeeper.Instance;
        isOgKey = dataKeeper.isOgKey;
        if(!isOgKey)
        {
            SetKeyToOption2();
        }
        else
        {
            SetKeyToOption1();
        }
        musicSlide.GetComponent<Slider>().value = dataKeeper.musicVolume;
        soundSlide.GetComponent<Slider>().value = dataKeeper.soundVolume;
    }

    public void Update()
    {
        isOgKey = dataKeeper.isOgKey;
        musicVolumeLevel = musicSlide.GetComponent<Slider>().value;
        soundVolumeLevel = soundSlide.GetComponent<Slider>().value;
    }

//open options panel
    public void OpenOptionsPanel()
    {
        SoundController.instance.Play("Click");
        optionsPanel.SetActive(true);
    }

//close options panel
    public void CloseOptionsPanel()
    {
        SoundController.instance.Play("Click");
        optionsPanel.SetActive(false);
    }

//show player chose key option 1 ui
    public void SetKeyToOption1()
    {
        keyOption1On.SetActive(true);
        keyOption1Off.SetActive(false);
        keyOption2On.SetActive(false);
        keyOption2Off.SetActive(true);
        isOgKey = true;
    }

//show player chose key option 2 ui
    public void SetKeyToOption2()
    {
        keyOption1On.SetActive(false);
        keyOption1Off.SetActive(true);
        keyOption2On.SetActive(true);
        keyOption2Off.SetActive(false);
        isOgKey = false;
    }

//button for switching between key options
    public void SwitchKey()
    {
        SoundController.instance.Play("Click");
        if (keyOption1On.activeSelf)
        {
            SetKeyToOption2();
        }
        else
        {
            SetKeyToOption1();
        }
    }
}
