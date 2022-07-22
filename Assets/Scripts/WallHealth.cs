using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public string whichWall;
    public int health;
    public int maxHealth;
    public int ruindCheck;
    public GameObject rubble;
    public GameObject ruinds;
    public GameObject gameMecanec;
    public Text warnings;
    public bool redOrBlue = false; //red = false/ blue = true


    // Start is called before the first frame update
    void Start()
    {
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec");

    }

    // Update is called once per frame
    void Update()
    {
        
        if (health < ruindCheck && health > 0)
        {
            ruinds.SetActive(true);
            StartCoroutine(showWarning(false));
        }
        else if (health <= 0)
        {
            StartCoroutine(showWarning(true));
            rubble.SetActive(true);
            this.gameObject.SetActive(false);
            if (this.tag.Equals("red fort"))
            {
                gameMecanec.GetComponent<gameMecanecSystem>().playesCoins += 50;

            }
            else
            {
                gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins += 50;
            }
        }
    }

    public void takeDamege(int damege)
    {
        this.health = this.health - damege;
        print("health: " + this.health);
    }

    IEnumerator showWarning(bool check)
    {
        
        if (check)
        {
            if (redOrBlue)
                warnings.text = "My Lord!, We have breached the enemys " + whichWall;
            else
                warnings.text = "My Lord!, The enemy has breached the " + whichWall;
        }
        else
        {
            if (redOrBlue)
                warnings.text = "My Lord!, We have cracked the enemys " + whichWall;
            else
                warnings.text = "My Lord!, The enemy has cracked the " + whichWall;
        }

        yield return new WaitForSeconds(5);
        warnings.text = "";
    }

}
