using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z);
    }
}
