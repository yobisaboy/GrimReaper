using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

//To make sure the object contains the required components
[RequireComponent(typeof(CharacterController))]

public class PlayerController : Subject
{
    public static PlayerController _instance;
    public static PlayerController Instance
    {
        get
        {
            return _instance;
        }
    }

    //GrimReaper_LossofMemories _inputs;
    Vector2 _move;
    //bool isFacingRight = true;
    //bool isOgKey;
    public bool isjumped;
    public bool isAttacking;


    [Header("Character Controller")]
    [SerializeField] CharacterController _controller;
    [SerializeField] Vector3 initialPosition;

    [Header("Joystick")]
    [SerializeField] private Joystick _joystick;

    [Header("Movements")]
    [SerializeField] float _speed;
    [SerializeField] float _gravity = -30.0f;
    [SerializeField] float _jumpHeight = 3.0f;
    [SerializeField] Vector3 _velocity;
    [SerializeField] float bounceForce = 5.0f;    

    [Header("Ground Detection")]
    [SerializeField] Transform _groundCheck;
    [SerializeField] float _groundRadius = 0.5f;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] bool _isGrounded;

    [Header("Bounce Detection")]
    public string bounceTag = "BounceObject"; 

    [Header("Shooting")]
    [SerializeField] GameObject playerSight;
    [SerializeField] GameObject playerMarker;

    [SerializeField] private float _projectileForce = 0f;
    [SerializeField] public Quest quest1, quest2, quest3;

    //[SerializeField] private float _lastHorizontalInput = 1.0f;


    void Awake()
    {
        _instance = this;
        _controller = GetComponent<CharacterController>();

    }

    void Start()
    {
        quest1 = new Quest(1, "Tutorial", QuestState.Active);
        quest2 = new Quest(2, "CollectItem", QuestState.Null);
        quest3 = new Quest(3, "KillEnemy", QuestState.Null);
        NotifyObservers(QuestState.Pending, quest2);
        NotifyObservers(QuestState.Pending, quest3);
        //player initial position
        if (DataKeeper.Instance.save1 != new Vector3 (0f, 0f, 0f))
        {
            _controller.enabled = false;
            transform.position = DataKeeper.Instance.save1;
            _controller.enabled = true;
        }
        else
        {
            InitiatePlayerPosition();
        }
        
        isjumped = false;
        isAttacking = false;


    }

    void FixedUpdate()
    {
        _move = _joystick.Direction;

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        if (_isGrounded && _velocity.y < 0.0f)
        {
            _velocity.y = -2.0f;
        }

        // Create movement vector, keeping Z component as 0
        //Vector3 movement = new Vector3(_move.x, 0.0f, 0.0f) * _speed * Time.fixedDeltaTime;
        Vector3 movement = new Vector3(_move.x * _speed * Time.fixedDeltaTime, 0.0f, 0.0f);
        _controller.Move(movement);
        _velocity.y += _gravity * Time.fixedDeltaTime;

        // Move the player vertically (jumping/falling), without affecting the Z-axis
        _controller.Move(new Vector3(0, _velocity.y, 0) * Time.fixedDeltaTime);

        //Fixed Z position
        Vector3 position = transform.position;
        position.z = initialPosition.z;
        transform.position = position;

        // Update _lastHorizontalInput if there's any horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            //_lastHorizontalInput = horizontalInput;
        }

        countEnemy();
        if (DataKeeper.Instance.isTutorialDone == true)
        {
            NotifyObservers(QuestState.Completed, quest1);
            NotifyObservers(QuestState.Active, quest2);
            NotifyObservers(QuestState.Active, quest3);
        }


    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
    }

    public void InitiatePlayerPosition()
    {
        _controller.enabled = false;
        transform.position = initialPosition;
        _controller.enabled = true;
    }

    public void Jump() // method will be called from clicking jump button
    {
        if (_isGrounded)
        {
            isjumped = true;
            SoundController.instance.Play("Jump");
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2.0f * _gravity);
        }
    }

    public void Shoot() // method will be called from clicking shoot button
    {
        SoundController.instance.Play("Attack");
        isAttacking = true;

        

        //projectile pool       
        var projectile = ProjectilePoolManager.Instance.Get();
        if(projectile != null)
        {
            projectile.transform.SetPositionAndRotation(playerSight.transform.position, Quaternion.Euler(playerSight.transform.rotation.x, playerSight.transform.rotation.y + 90, playerSight.transform.rotation.z));
            projectile.gameObject.SetActive(true);
            //projectile.gameObject.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _projectileForce, ForceMode.Impulse);

            //if the sight is facing right, the projectile will move to the right

            //projectile.gameObject.GetComponent<Rigidbody>().AddForce(-projectile.transform.forward * _projectileForce, ForceMode.Impulse);

            if (_move.x >= 0)
            {
                //Debug.Log("Player Sight: " + playerSight.transform.position.x);
                projectile.gameObject.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * _projectileForce, ForceMode.Impulse);
            }
            else if (_move.x < 0)
            {
                //Debug.Log("Player Sight: " + playerSight.transform.position.x);
                projectile.gameObject.GetComponent<Rigidbody>().AddForce(-projectile.transform.forward * _projectileForce, ForceMode.Impulse);
            }
        }
        
        






    }

    //private void SendMessage(InputAction.CallbackContext context)
    //{
    //    Debug.Log($"Move Performed x = {context.ReadValue<Vector2>().x}, y = {context.ReadValue<Vector2>().y}");
    //}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player touch " + other.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            //when player touch enemy, player's health will decrease
            Debug.Log("Player hit by enemy");
            SoundController.instance.Play("EnemyAttack");
            GamePlayUIController.Instance.UpdateHealth(-1.0f);
            //connect to datakeeper (stage 3)
        }

        
        if (quest2.state == QuestState.Active && other.gameObject.CompareTag("Item") && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
                NotifyObservers(QuestState.Completed, quest2);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(bounceTag) && _isGrounded)
        {          
            Debug.Log("Player hit bounce object");
            _velocity.y = Mathf.Sqrt(bounceForce * -2f * _gravity);
            SoundController.instance.Play("Jump");
        }
    }

    public void countEnemy()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (quest3.state == QuestState.Active && enemies.Length == 1 && UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
        {
            NotifyObservers(QuestState.Completed, quest3);
        }

    }


}