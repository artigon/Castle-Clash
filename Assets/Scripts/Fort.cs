using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
  
    public float health, maxHealth,ruindCheck;
    public HealthManagement healthBar;

    public void TakeDamage(int damege)
    {
        print("tower health: " + health);
        // Use your own damage handling code, or this example one.
        health -= damege;//change to damage
        healthBar.UpdateHealthBar();
    }
    void Update()
    {
        //// Example so we can test the Health Bar functionality
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage();
        //}
        if (health < 0)
            this.gameObject.SetActive(false);
    }
}
