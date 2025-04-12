using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpItem : MonoBehaviour
{
    public int banana;
    public int watermelon;
    public int cherry;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundController.instance.Play("Item");
            ////if the game object name is banana
            //if (this.gameObject.name == "Banana(Clone)")
            //{
            //    InventoryController.Instance.bananaCount++;
            //    //sent to datakeeper, then show on inventory (stage 3)
            //}
            ////if the game object name is watermelon
            //if (this.gameObject.name == "Watermelon(Clone)")
            //{
            //    InventoryController.Instance.watermelonCount++;
            //    //sent to datakeeper, then show on inventory (stage 3)
            //}
            ////if the game object name is cherry 
            //if (this.gameObject.name == "Cherry(Clone)")
            //{
            //    InventoryController.Instance.cherryCount++;
            //    //sent to datakeeper, then show on inventory (stage 3)
            //}
            string itemName = this.gameObject.name;
            InventoryManager.Instance.PickUpItems(itemName);
            Destroy(this.gameObject);
        }
    }
}
