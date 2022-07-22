using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public string whichWall;
    // whichWall = front, left, right or back
    public bool isNextWreck;
    public int health;
    public int maxHealth;
    public int ruindCheck;
    public FortWallsWarning warningScript;
    public GameObject nextWall;
    public GameObject ruinds;
    public GameObject gameMecanec;
    public Text testText;


    // Start is called before the first frame update
    void Start()
    {
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec");
        StartCoroutine(test());

    }

    // Update is called once per frame
    void Update()
    {
        if (health < ruindCheck && health > 0)
            ruinds.SetActive(true);

        else if (health <= 0)
        {
            // set msg
            if (isNextWreck && whichWall != null)
                warningScript.setWarning(whichWall);

            nextWall.SetActive(true);
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
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        testText.text = health.ToString();
        yield return new WaitForSeconds(3);
        testText.text = "";
    }

}
