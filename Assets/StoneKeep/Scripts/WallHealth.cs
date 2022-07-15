using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : HealthBar
{
    public GameObject wall;
    public GameObject rubble;
    public GameObject ruinedWall;
    public bool isSemiRuined = false;
    public bool isWrecked = false;
    // Start is called before the first frame update
    public override void Start()
    {
        health = maxHealth;
        healthbarUI = Instantiate(healthbarUI, wall.transform.position, wall.transform.rotation);
        setSlider(healthbarUI.transform.Find("Slider").gameObject.GetComponent<Slider>());
        getSlider().maxValue = 1.0f;
        getSlider().value = CalculateHealth();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (wall != null)
            healthbarUI.transform.position = wall.transform.position;
        getSlider().value = CalculateHealth();
        if (health < maxHealth && health != 0)
        {
            healthbarUI.SetActive(true);
        }
        else
            healthbarUI.SetActive(false);


        if (health <= 0 && !isWrecked)
        {
            StartCoroutine(setWall(rubble));
            healthbarUI.SetActive(false);
        }

        if (health <= 30 && health > 0 && !isSemiRuined)
        {
            StartCoroutine(setWall(ruinedWall));
        }
        if (health > maxHealth)
            health = maxHealth;

    }
    IEnumerator setWall(GameObject newWall)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject temp = Instantiate(newWall, wall.transform.position, wall.transform.rotation);
        Destroy(wall);
        wall = temp;
    }
}
