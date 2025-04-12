using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class InventoryController : MonoBehaviour
{
    public static InventoryController _instance;
    public static InventoryController Instance
    {
        get
        {
            return _instance;
        }
    }
    private DataKeeper dataKeeper;
    [SerializeField] public Image banana;
    [SerializeField] public int bananaCount;
    [SerializeField] public Text bananaText;
    [SerializeField] public Image watermelon;
    [SerializeField] public int watermelonCount;
    [SerializeField] public Text watermelonText;
    [SerializeField] public Image cherry;
    [SerializeField] public int cherryCount;
    [SerializeField] public Text cherryText;
    [SerializeField] public GameObject inventory;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        inventory.SetActive(true);
        //dataKeeper = DataKeeper.Instance;
        //bananaCount = dataKeeper.bananaAmount;
        //watermelonCount = dataKeeper.watermelonAmount;
        //cherryCount = dataKeeper.cherryAmount;
    }
    void Update()
    {
        colorItem(bananaCount, banana);
        countItem(bananaCount, bananaText);
        colorItem(watermelonCount, watermelon);
        countItem(watermelonCount, watermelonText);
        colorItem(cherryCount, cherry);
        countItem(cherryCount, cherryText);
    }

    void colorItem(int count, Image item)
    {
//"activate" when player acquire at least 1 item
        if (count == 0)
        {
            item.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        }
        else
        {
            item.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    void countItem(int count, Text text)
    {
//showing the count of the item on UI text
        text.text = count.ToString();
        if (count == 0)
        {
            text.enabled = false;
        }
        else if (count > 0)
        {
            text.enabled = true;
        }

    }

    public void useBanana()
    {
        //if (bananaCount > 0)
        //{
            SoundController.instance.Play("Click");
            Debug.Log("Banana used");
            bananaCount--;
            GamePlayUIController.Instance.UpdateHealth(1.0f);
        //}
    }
    public void useWatermelon()
    {
        if (watermelonCount > 0)
        {
            SoundController.instance.Play("Click");
            Debug.Log("Watermelon used");
            watermelonCount--;
            GamePlayUIController.Instance.UpdateHealth(1.0f);
        }
    }
    public void useCherry()
    {
        if (cherryCount > 0)
        {
            SoundController.instance.Play("Click");
            Debug.Log("Cherry used");
            cherryCount--;
            GamePlayUIController.Instance.UpdateHealth(1.0f);
        }
    }
}
