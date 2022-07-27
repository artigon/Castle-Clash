using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compAI : MonoBehaviour
{
    public spawnNPC spawnScript;
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
        yield return new WaitForSeconds(5);
        bool walkPointCheck = randomBoolean();
        int menu = Random.Range(0, 4);
        print("compAi: " + walkPointCheck);

        switch (menu)
        {
            case 1:
                {
                    spawnScript.spawnRedKnight(walkPointCheck);
                    break;
                }
            case 2:
                {
                    spawnScript.spawnRedArcher(walkPointCheck);
                    break;
                }
            case 3:
                {
                    spawnScript.spawnRedCanon(walkPointCheck);
                    break;
                }
        }
        StartCoroutine(Ai());

    }
}
