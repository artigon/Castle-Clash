using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHealthMec : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            print(this.name + " has died");
            this.gameObject.SetActive(false);
        }
    }

    public void takeDamege(int damege)
    {
        health = health - damege;
    }
}
