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
    public FortWallsWarning warningScript;
    public GameObject nextWall;


    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {   
        if (health <= 0)
        {
            // set msg
            if (isNextWreck && whichWall != null)
                warningScript.setWarning(whichWall);
            
            nextWall.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    public void takeDamege(int damege)
    {
        this.health = this.health - damege;
        print("health: " + this.health);
    }
}
