using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            // Enemy is defeated, perform any additional logic (e.g., play animation, spawn particles)
            SoundController.instance.Play("EnemyHit");
            Destroy(gameObject);
        }
    }
}
