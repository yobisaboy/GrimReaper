using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] public ItemsFactory _itemsFactory;
    [SerializeField] public int itemsNumber = 10;
    [SerializeField] public int leftX = 126;
    [SerializeField] public int rightX = 280;
    [SerializeField] public int leftY = 22;
    [SerializeField] public int rightY = 52;

    void Start()
    {
        for(int i = 0; i < itemsNumber; i++)
        {
            int randomX = Random.Range(leftX, rightX);
            int randomY = Random.Range(leftY, rightY);
            Vector3 position4 = new Vector3(randomX, -randomY, 0f);

            int randomItem = Random.Range(0, 3);
            switch (randomItem)
            {
                case 0:
                    Instantiate(_itemsFactory.CreateItems("Banana").GetItemsPrefab(), position4, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(_itemsFactory.CreateItems("Cherry").GetItemsPrefab(), position4, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(_itemsFactory.CreateItems("Watermelon").GetItemsPrefab(), position4, Quaternion.identity);
                    break;
            }
        }
    }

}
