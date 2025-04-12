using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    [SerializeField] private GameObject target;

    void Update()
    {
        if(target != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
