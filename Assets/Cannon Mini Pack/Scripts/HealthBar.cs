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

        healthbarUI.transform.position = this.transform.position;
        slider.value = CalculateHealth();
        if (health < maxHealth)
            healthbarUI.SetActive(true);

        if (health <= 0)
        {
            StartCoroutine(Dead());           
        }

        if (health > maxHealth)
            health = maxHealth;

        IEnumerator Dead()
        {
            yield return new WaitForSeconds(0.5f);
            healthbarUI.SetActive(false);
            Destroy(gameObject);
        }


    }
    float CalculateHealth()
    {
        return (health / maxHealth);
    }
}
