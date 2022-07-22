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

    private void Start()
    {
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec").GetComponent<gameMecanecSystem>();

    }
   
    void Update()
    {
        if (health < ruindCheck && health > 0)
        {
            ruinds.SetActive(true);
        }
        else if (health < 0)
        {
            Tower.SetActive(false);
            ruinds.SetActive(false);
            rubble.SetActive(true);
            this.gameObject.SetActive(false);
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

    IEnumerator showWarning(bool check)
    {
        string tmp;
        if (check)
        {
            if (redOrBlue)
                tmp = "My Lord!, We have breached the enemys Tower";
            else
                tmp = "My Lord!, The enemy has breached the Tower";
        }
        else
        {
            if (redOrBlue)
                tmp = "My Lord!, We have cracked the enemys Tower";
            else
                tmp = "My Lord!, The enemy has cracked the Tower";
        }
        warnings.text = tmp;
        yield return new WaitForSeconds(5);
        warnings.text = "";
    }
}
