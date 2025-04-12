using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            return _instance;
        }
    }
    public GameObject Inventory;
    public char[] inventoryItems;
    public int inventoryCount;
    public Sprite bananaSprite;
    public Sprite cherrySprite;
    public Sprite watermelonSprite;
    private void Awake()
    {
        _instance = this;
        
    }

    private void Start()
    {
        inventoryCount = 0;
        inventoryItems = new char[10];
        
        Invoke("CloseInventory", 0.1f);
    }



    public void CloseInventory()
    {
        Inventory.SetActive(false);
    }


    public void PickUpItems(string item)
    {
        
        switch (item)
        {
            case "Banana(Clone)":
                inventoryItems[inventoryCount] = 'B'; 
                inventoryCount++;
                ShowItem(inventoryItems);
                break;
            case "Cherry(Clone)":
                inventoryItems[inventoryCount] = 'C';
                inventoryCount++;
                ShowItem(inventoryItems);
                break;
            case "Watermelon(Clone)":
                inventoryItems[inventoryCount] = 'W';
                inventoryCount++;
                ShowItem(inventoryItems);
                break;

            default:
                break;
        }

    }

    void ShowItem(char[] inventoryItems)
    {
        // Show the items in the inventory
        
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == 'B')
            {
                string location = (i+1).ToString();
                Inventory.transform.Find(location).GetComponent<Image>().sprite = bananaSprite;
                Inventory.transform.Find(location).GetComponent<Image>().color = Color.white;
            }
            else if (inventoryItems[i] == 'C')
            {
                string location = (i + 1).ToString();
                Inventory.transform.Find(location).GetComponent<Image>().sprite = cherrySprite;
                Inventory.transform.Find(location).GetComponent<Image>().color = Color.white;

            }
            else if (inventoryItems[i] == 'W')
            {
                string location = (i + 1).ToString();
                Inventory.transform.Find(location).GetComponent<Image>().sprite = watermelonSprite;
                Inventory.transform.Find(location).GetComponent<Image>().color = Color.white;

            }
            
        }
    }
}
