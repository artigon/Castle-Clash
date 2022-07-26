using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class spawnNPC : MonoBehaviour
{
    public GameObject gameMecanec;
    public Text warnings;

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
        gameMecanec = GameObject.FindGameObjectWithTag("gamemec");

        if (redSelect)
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
        if (gameMecanec.GetComponent<gameMecanecSystem>().playesCoins >= 15)
        {
            gameMecanec.GetComponent<gameMecanecSystem>().playesCoins -= 15;
            StartCoroutine(dealy(5));
            Instantiate(knightPrefabe, spawnPointHuman, Quaternion.identity);
        }
        else
            StartCoroutine(playerwarning());

    }

    public void spawnArcher()
    {
        if (gameMecanec.GetComponent<gameMecanecSystem>().playesCoins >= 25)
        {
            gameMecanec.GetComponent<gameMecanecSystem>().playesCoins -= 25;
            StartCoroutine(dealy(10));
            Instantiate(archerPrefabe, spawnPointHuman, Quaternion.identity);
        }
        else
            StartCoroutine(playerwarning());

    }

    public void spawnCanon()
    {
        if (gameMecanec.GetComponent<gameMecanecSystem>().playesCoins >= 40)
        {
            gameMecanec.GetComponent<gameMecanecSystem>().playesCoins -= 40;
            StartCoroutine(dealy(30));
            Instantiate(canonPrefabe, spawnPointCanon, Quaternion.identity);
        }
        else
            StartCoroutine(playerwarning());
    }

    public bool spawnRedKnight(Vector3 newWalkoint,bool walkPointCheck)
    {
        Vector3 walkPoint = spawnPointHuman;
        if (walkPointCheck)
            walkPoint = newWalkoint;
            if (gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins >= 15)
        {
            gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins -= 15;
            StartCoroutine(dealy(5));
            Instantiate(knightPrefabe, walkPoint, Quaternion.identity);
            return true;
        }
        return false;

    }

    public bool spawnRedArcher(Vector3 newWalkoint, bool walkPointCheck)
    {
        Vector3 walkPoint = spawnPointHuman;
        if (walkPointCheck)
            walkPoint = newWalkoint;
        if (gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins >= 25)
        {
            gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins -= 25;
            StartCoroutine(dealy(10));
            Instantiate(archerPrefabe, spawnPointHuman, Quaternion.identity);
            return true;
        }
        return false;

    }

    public bool spawnRedCanon(Vector3 newWalkoint, bool walkPointCheck)
    {
        Vector3 walkPoint = spawnPointHuman;
        if (walkPointCheck)
            walkPoint = newWalkoint;
        if (gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins >= 40)
        {
            gameMecanec.GetComponent<gameMecanecSystem>().enemyCoins -= 40;
            StartCoroutine(dealy(30));
            Instantiate(canonPrefabe, spawnPointCanon, Quaternion.identity);
            return true;
        }
        return false;
    }

    IEnumerator dealy(int time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator playerwarning()
    {
        warnings.text = "You dont have enough coins";
        yield return new WaitForSeconds(5);
        warnings.text = "";
    }
}
