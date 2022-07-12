using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthbarUI;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.maxValue = 1.0f;
        slider.value = CalculateHealth();
        healthbarUI.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //healthbarUI.transform.position = this.transform.position + transform.up * 0.8f;
        slider.value = CalculateHealth();
        if (health < maxHealth)
            healthbarUI.SetActive(true);

        if (health <= 0)
            Destroy(gameObject);

        if (health > maxHealth)
            health = maxHealth;
        
    }
    float CalculateHealth()
    {
        return (health / maxHealth);
    }
}
