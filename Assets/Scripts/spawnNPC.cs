using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnNPC : MonoBehaviour
{
    public bool redSelect;
    public GameObject redKnightPrefabe;
    public GameObject redArcherPrefabe;
    public GameObject redCanonPrefabe;
    public Vector3 spawnPointRedHuman;
    public Vector3 spawnPointRedCanon;



    public bool blueSelect;
    public GameObject blueKnightPrefabe;
    public GameObject blueArcherPrefabe;
    public GameObject blueCanonPrefabe;
    public Vector3 spawnPointBlueHuman;
    public Vector3 spawnPointBlueCanon;
 

    private GameObject knightPrefabe;
    private GameObject archerPrefabe;
    private GameObject canonPrefabe;
    private Vector3 spawnPointHuman;
    private Vector3 spawnPointCanon;


    // Start is called before the first frame update
    void Start()
    {
        if(redSelect)
        {
            knightPrefabe = redKnightPrefabe;
            archerPrefabe = redArcherPrefabe;
            canonPrefabe = redCanonPrefabe;
            spawnPointHuman = spawnPointRedHuman;
            spawnPointCanon = spawnPointRedCanon;
        }
        else if(blueSelect)
        {
            knightPrefabe = blueKnightPrefabe;
            archerPrefabe = blueArcherPrefabe;
            canonPrefabe = blueCanonPrefabe;
            spawnPointHuman = spawnPointBlueHuman;
            spawnPointCanon = spawnPointBlueCanon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnKnight()
    {
        StartCoroutine(dealy(5));
        Instantiate(knightPrefabe, spawnPointHuman, Quaternion.identity);
    }

    public void spawnArcher()
    {
        StartCoroutine(dealy(10));
        Instantiate(archerPrefabe, spawnPointHuman, Quaternion.identity);
    }

    public void spawnCanon()
    {
        StartCoroutine(dealy(30));
        Instantiate(canonPrefabe, spawnPointCanon, Quaternion.identity);
    }

    IEnumerator dealy(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
