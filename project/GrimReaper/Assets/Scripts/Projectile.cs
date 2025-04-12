using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 20f;
    public float speed = 10f;
    public float lifetime = 3f;

    void Start()
    {
        // Set initial velocity when the projectile is instantiated
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;

        // Automatically destroy the projectile after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            // Check if the other object has the EnemyHealth component
            Debug.Log("Player hit the enemy");
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Enemy is hit, apply damage and make it disappear
                enemyHealth.TakeDamage(damage);
            }

            Destroy(gameObject); // Destroy the projectile upon hitting an enemy
        }
    }
}
