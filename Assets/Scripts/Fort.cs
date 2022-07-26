using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fort : MonoBehaviour
{
  
    public float health, maxHealth,ruindCheck;
    public HealthManagement healthBar;
    public gameMecanecSystem gameMecanec;
    public GameObject Tower,rubble, ruinds;
    public bool redOrBlue;//red = false/ blue = true
    public warningMec warningMec;
    private bool firstWarning = false, secondWarning = false;


    private void Start()
    {
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec").GetComponent<gameMecanecSystem>();
        warningMec = GameObject.FindGameObjectWithTag("warningMec").GetComponent<warningMec>();

    }

    void Update()
    {
        if (health < ruindCheck && health > 0 && !firstWarning)
        {
            StartCoroutine(showWarning(false, 0));
            ruinds.SetActive(true);
        }
        else if (health < 0 && !secondWarning)
        {
            StartCoroutine(showWarning(true, 1));
            Tower.SetActive(false);
            ruinds.SetActive(false);
            rubble.SetActive(true);
            if (this.tag.Equals("red fort"))
                gameMecanec.playerWins = true;
            else
                gameMecanec.enemyWins = true;
        }
    }

    public void TakeDamage(int damege)
    {
        print("tower health: " + health);
        // Use your own damage handling code, or this example one.
        health -= damege;//change to damage
        healthBar.UpdateHealthBar();
    }

    IEnumerator showWarning(bool check,int numWarning)
    {
        if (numWarning == 0)
            firstWarning = true;
        else
            secondWarning = true;
        if (check)
        {
            if (this.tag.Equals("red fort"))
                warningMec.showWarning("My Lord!, We have destroyed the enemys Tower");
            else
                warningMec.showWarning("My Lord!, The enemy has destroyed the Tower");
        }
        else
        {
            if (this.tag.Equals("red fort"))
                warningMec.showWarning("My Lord!, We have cracked the enemys Tower");
            else
                warningMec.showWarning("My Lord!, The enemy has cracked the Tower");
        }
        yield return new WaitForSeconds(5);
       
    }
}
