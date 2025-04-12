using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemsFactory : MonoBehaviour
{
    [SerializeField] GameObject _bananaPrefab;
    [SerializeField] GameObject _cherryPrefab;
    [SerializeField] GameObject _watermelonPrefab;

    public Items CreateItems(string itemType)
    {
        switch (itemType)
        {
            case "Banana":
                Items banana = new Banana();
                banana.SetItemsPrefab(_bananaPrefab);
                return banana;
            case "Cherry":
                Items cherry = new Cherry();
                cherry.SetItemsPrefab(_cherryPrefab);
                return cherry;
            case "Watermelon":
                Items watermelon = new Watermelon();
                watermelon.SetItemsPrefab(_watermelonPrefab);
                return watermelon;
            default:
                return null;
        }
    }
}
