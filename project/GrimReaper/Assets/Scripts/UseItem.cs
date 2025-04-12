using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UseItem : MonoBehaviour
{

    public void useItem()
    {
        SoundController.instance.Play("Click");
        Debug.Log("Item used");
        GamePlayUIController.Instance.UpdateHealth(1.0f);
        GetComponent<Image>().sprite = null;
        GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
