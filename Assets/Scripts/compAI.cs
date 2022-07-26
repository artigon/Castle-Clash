using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compAI : MonoBehaviour
{
    public spawnNPC spawnScript;
    public Vector3 walkpoint;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(Ai());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool randomBoolean()
    {
        if (Random.value >= 0.5)
        {
            return true;
        }
        return false;
    }
    
    IEnumerator Ai()
    {
        yield return new WaitForSeconds(10);
        bool walkPointCheck = randomBoolean();
        int menu = Random.Range(1, 3);
        switch(menu)
        {
            case 1:
                {
                    spawnScript.spawnRedKnight(walkpoint, walkPointCheck);
                    break;
                }
            case 2:
                {
                    spawnScript.spawnRedArcher(walkpoint, walkPointCheck);
                    break;
                }
            case 3:
                {
                    spawnScript.spawnRedCanon(walkpoint, walkPointCheck);
                    break;
                }
        }
        StartCoroutine(Ai());

    }
}
