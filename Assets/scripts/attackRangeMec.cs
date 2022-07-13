using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackRangeMec : MonoBehaviour
{
    public npcMovmentMec parent;
    public string enemyTag;

    // Start is called before the first frame update
    void Start()
    {
        enemyTag = parent.enemyTag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag(enemyTag))
        //{
            print("attack test\n");

            parent.enemyInAttackRange = true;
            parent.enemy = other.gameObject;
        //}
    }
}
