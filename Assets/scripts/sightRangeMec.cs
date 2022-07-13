using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sightRangeMec : MonoBehaviour
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
        //parent.agent.enabled = false;
        if (other.CompareTag(enemyTag))
        {

            StartCoroutine(test(other.gameObject));

        }
    }

    IEnumerator test(GameObject bjc)
    {
        yield return new WaitForSeconds(5);
        print("sight test\n");
        parent.enemyInSightRange = true;
        parent.enemy = bjc;
    }
}
