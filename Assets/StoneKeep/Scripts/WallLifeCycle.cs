using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WallLifeCycle : HealthBar
{
    // public float currentHealth;
    // public float maxHealth;
    public GameObject rubble;
    public GameObject ruinedState;
    // Start is called before the first frame update
    private bool isRuined = false;
    private bool isDead = false;
    private Slider slider;
    void Start()
    {

        healthbarUI = Instantiate(healthbarUI, transform.position, transform.rotation);
        healthbarUI.transform.position = transform.position;
        slider = healthbarUI.transform.Find("Slider").gameObject.GetComponent<Slider>();
        slider.maxValue = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

        healthbarUI.transform.position = transform.position;
        slider.value = CalculateHealth();
        
        if (health < maxHealth)
            healthbarUI.SetActive(true);
      

        if (health <= 30 && health > 0 && !isRuined)
        {
            Invoke("semiRuined", 1f);
            isRuined = true;
        }

        if (health <= 0 && !isDead)
        {
            Invoke("ruined",0.5f);
            ruined();
            isDead = true;
        }

        if (health > maxHealth)
            health = maxHealth;

        //  IEnumerator Ruin()
        //  {
        //  yield return new WaitForSeconds(0);
        //  Debug.Log("dead");
        // healthbarUI.SetActive(false);
        //  gameObject.SetActive(false);
        //  Instantiate(rubble, transform.position, transform.rotation);
        // isDead = true;
        //Destroy(gameObject);
        // }


    }
    public void setRuined(bool choice)
    {
        isRuined = choice;
    }
    public void setDead(bool choice)
    {
        isDead = choice;
    }
    void ruined()
    {
        Debug.Log("dead");
        Destroy(healthbarUI);
        Instantiate(rubble, transform.position, Quaternion.identity);
        Destroy(gameObject);


        //Destroy(gameObject);
    }
    void semiRuined()
    {
        GameObject semi = Instantiate(ruinedState, transform.position, transform.rotation);
        semi.GetComponent<WallLifeCycle>().setHealth(health);
        semi.GetComponent<WallLifeCycle>().setRuined(true);
        Destroy(gameObject);
    }

}
