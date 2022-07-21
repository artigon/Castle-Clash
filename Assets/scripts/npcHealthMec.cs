using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHealthMec : MonoBehaviour
{
    public bool isCanon;
    public canonDeathAnimeMEc canonDeath;
    public int health;
    private Animator animator;
    public npcMovmentMec movmentMec;
    private GameObject gameMecanec;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec");

        UnitSelections.Instance.unitList.Add(this.gameObject);
        if (isCanon)
            animator = transform.GetChild(0).gameObject.GetComponent<Animator>();
        else
            animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !isDead)
        {
            isDead = true;
            print(this.name + " has died");
            StartCoroutine(died());
        }
    }

    public void takeDamege(int damege)
    {
        health = health - damege;
    }

    IEnumerator died()
    {
        if(this.tag.Equals("Red"))
        {
            if (movmentMec.isCanone)
                gameMecanec.GetComponent<gameMecanecSystem>().playesCoins += 10;
            else
                gameMecanec.GetComponent<gameMecanecSystem>().playesCoins += 5;

        }
        else
        {
            if (movmentMec.isCanone)
                gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins += 10;
            else
                gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins += 5;
        }
        UnitSelections.Instance.unitList.Remove(this.gameObject);
        movmentMec.canAttack = false;
        if (isCanon)
            canonDeath.startCHeck = true;
        else
            animator.SetInteger("state", 3);
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);
    }
}
