using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float damageAmount = 10f;
    public float attackRange = 5f;
    public float moveSpeed = 3f;
    public LayerMask playerLayer;

    private Transform player;
    private bool isPlayerInRange;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        CheckForPlayerInRange();

        if (isPlayerInRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveAwayFromPlayer();
        }
    }

    private void CheckForPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        isPlayerInRange = distanceToPlayer <= attackRange;
    }

    private void MoveTowardsPlayer()
    {
        transform.LookAt(player.position);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void MoveAwayFromPlayer()
    {
        // Find the target GameObject 
        GameObject targetObject = GameObject.Find(name + "Target"); // Change the tag as needed

        if (targetObject != null)
        {
            // Calculate the direction away from the player and towards the target
            Vector3 directionToTarget = targetObject.transform.position - transform.position;

            // Ensure that the enemy looks in the direction of the target
            transform.rotation = Quaternion.LookRotation(directionToTarget, Vector3.up);

            // Move away from the player and towards the target
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Target GameObject not found!" + name);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Player is in range, apply damage
            //collision.collider.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        }
    }
}
