using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public static KeyController _instance;
    private void Awake()
    {
        _instance = this;
    }

    public bool hasKey = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SoundController.instance.Play("Item");
            hasKey = true;
            Destroy(gameObject);
        }
    }
}
