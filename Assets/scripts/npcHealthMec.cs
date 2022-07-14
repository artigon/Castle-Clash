using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcHealthMec : MonoBehaviour
{
    public int health;
    private Animator animator;
    public npcMovmentMec movmentMec;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
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
        movmentMec.canAttack = false;
        animator.SetInteger("state", 3);
        yield return new WaitForSeconds(4);
        this.gameObject.SetActive(false);
    }
}
