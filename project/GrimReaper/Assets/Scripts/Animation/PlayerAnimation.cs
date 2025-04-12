using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;

    private CharacterController controller;
    private Animator anim;
    private bool isGrounded = false;
    private bool isWalking = false;
    private bool isJumped = false;
    private bool isAttacking = false;
    private bool isIdle = true;

    GrimReaper_LossofMemories _inputs;
    Vector2 _move;

    [SerializeField] GameObject playerModel;
    [SerializeField] GameObject playerMarker;
    [SerializeField] GameObject playerSight;

    private void Awake()
    {
        _inputs = new GrimReaper_LossofMemories();
        _inputs.Enable();
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
       
    }

    private void Update()
    {
        _move = _joystick.Direction;


        // Jump
        if (PlayerController.Instance.isjumped == true && isGrounded && !isAttacking)
        {
            isJumped = true;
            anim.SetBool("isJumped", isJumped);
            isGrounded = false;
            PlayerController.Instance.isjumped = false;
        }
        else if (isGrounded)
        {
            isJumped = false;
            anim.SetBool("isJumped", isJumped);
        }
        
        // Attack
        if (PlayerController.Instance.isAttacking == true)
        {
            isAttacking = true;
            anim.SetBool("isAttacking", isAttacking);
            PlayerController.Instance.isAttacking = false;
        }
        else
        {
            isAttacking = false;
            anim.SetBool("isAttacking", isAttacking);
        }

        // Walk
        if (_move.x != 0)
        {
            isWalking = true;
            anim.SetBool("isWalking", isWalking);
            Flip();
            SoundController.instance.Play("Walk");
        }
        else
        {
            isWalking = false;
            anim.SetBool("isWalking", isWalking);

        }

        // Idle
        if (!isWalking && !isJumped && !isAttacking)
        {
            isIdle = true;
            anim.SetBool("isIdle", isIdle);
        }
        else
        {
            isIdle = false;
            anim.SetBool("isIdle", isIdle);
        }
    }

    private void Flip()
    {

        if (playerModel != null)
        {
            if (_move.x > 0)
            {
                playerModel.transform.rotation = Quaternion.Euler(0, 90, 0);
                if (playerMarker != null)
                {
                    playerMarker.transform.rotation = Quaternion.Euler(90, 90, 0);

                    playerSight.transform.position = new Vector3(playerMarker.transform.position.x, playerMarker.transform.position.y, playerMarker.transform.position.z);


                }


            }
            else if (_move.x < 0)
            {
                playerModel.transform.rotation = Quaternion.Euler(0, -90, 0);
                if (playerMarker != null)
                {
                    playerMarker.transform.rotation = Quaternion.Euler(90, -90, 0);
                    playerSight.transform.position = new Vector3(playerMarker.transform.position.x - 2.0f, playerMarker.transform.position.y, playerMarker.transform.position.z);

                }

            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("TerrainObj"))
        {
            isGrounded = true;
        }

        if (hit.gameObject.name == "RockPlatform")
        {
            transform.parent = hit.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RockPlatform")
        {
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "RockPlatform")
        {
            transform.parent = null;
        }
    }

    // Other methods like Flip() can be added here if needed
}
