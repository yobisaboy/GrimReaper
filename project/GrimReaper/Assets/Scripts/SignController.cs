using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignController : MonoBehaviour
{
    [SerializeField] GameObject Sign;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Sign.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Sign.SetActive(false);
        }
    }


}
