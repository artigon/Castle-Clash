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
    public Text warnings;
    private bool firstWarning = false, secondWarning = false;


    private void Start()
    {
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec").GetComponent<gameMecanecSystem>();

    }
   
    void Update()
    {
        if (health < ruindCheck && health > 0 && !firstWarning)
        {
            ruinds.SetActive(true);
        }
        else if (health < 0 && !secondWarning)
        {
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
        string tmp;
        if (check)
        {
            if (this.tag.Equals("red fort"))
                tmp = "My Lord!, We have breached \nthe enemys Tower";
            else
                tmp = "My Lord!, The enemy has \nbreached the Tower";
        }
        else
        {
            if (this.tag.Equals("red fort"))
                tmp = "My Lord!, We have cracked \nthe enemys Tower";
            else
                tmp = "My Lord!, The enemy has \ncracked the Tower";
        }
        warnings.text = tmp;
        yield return new WaitForSeconds(5);
        warnings.text = "";
    }
}
