using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
  
    public float health, maxHealth;
    public HealthManagement healthBar;
    public void TakeDamage()
    {
        // Use your own damage handling code, or this example one.
        health -= 100;//change to damage
        healthBar.UpdateHealthBar();
    }
    void Update()
    {
        // Example so we can test the Health Bar functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage();
        }
    }
}
