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
    public warningMec warningMec;
    public bool redOrBlue = false; //red = false/ blue = true
    private bool firstWarning = false, secondWarning = false;


    // Start is called before the first frame update
    void Start()
    {
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec");
        warningMec = GameObject.FindGameObjectWithTag("warningMec").GetComponent<warningMec>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if ((health < ruindCheck && health > 0) && !firstWarning)
        {
            ruinds.SetActive(true);
            StartCoroutine(showWarning(false,0));
        }
        else if (health <= 0 && !secondWarning)
        {
            StartCoroutine(showWarning(true,1));
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
        print(this.name + " health: " + this.health);
    }

    IEnumerator showWarning(bool check, int numWarning)
    {
        if (numWarning == 0)
            firstWarning = true;
        else
            secondWarning = true;

        if (check)
        {
            if (this.tag.Equals("red fort"))
                warningMec.showWarning("My Lord!, We have breached the enemys " + whichWall);
            else
                warningMec.showWarning("My Lord!, The enemy has breached the " + whichWall);
        }
        else
        {
            if (this.tag.Equals("red fort"))
                warningMec.showWarning("My Lord!, We have cracked the enemys " + whichWall);
            else
                warningMec.showWarning("My Lord!, The enemy has cracked the " + whichWall);
        }

        yield return new WaitForSeconds(5);
    }

}
