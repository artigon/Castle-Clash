using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public int health;
    public bool isFrontGate;
    private GameObject gate;
    private GameObject wall;
    private GameObject rubble;
    private GameObject ruinedWall;
    public bool isSemiRuined;
    public bool isWrecked;
    public FortWallsWarning warningScript;
    // Start is called before the first frame update
    void Start()
    {

        wall = transform.GetChild(0).gameObject;
        ruinedWall = transform.GetChild(1).gameObject;
        rubble = transform.GetChild(2).gameObject;
        if (isFrontGate)
            gate = transform.GetChild(3).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isWrecked)
        {
            if (transform.parent.name == "FrontWalls")
                warningScript.setWarning("front");
            else if (transform.parent.name == "RightSideWalls")
                warningScript.setWarning("right");
            else
                warningScript.setWarning("left");
        }
            
        if (health < 40 && health > 0 && !isSemiRuined)
        {
            StartCoroutine(setWalls(ruinedWall));
            isSemiRuined = true;
            isWrecked = false;
        }
        else
        if (health <= 0)
        {
            StartCoroutine(setWalls(rubble));
            isWrecked = true;
            isSemiRuined = false;
        }
          
        IEnumerator setWalls(GameObject changedWall)
        {
            yield return new WaitForSeconds(0.5f);
            if (isFrontGate)
            {
                if (getActiveChild() == wall)
                {
                    wall.SetActive(false);
                    gate.SetActive(false);
                }
                else
                {
                    getActiveChild().SetActive(false);
                }
                changedWall.SetActive(true);
            }
            else
            {
                getActiveChild().SetActive(false);
                changedWall.SetActive(true);
            }
        }
    }
    public GameObject getActiveChild()
    {
        for(int i = 0; i < gameObject.transform.childCount;i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
            {
                return gameObject.transform.GetChild(i).gameObject;
            }
        }
        return null;
    }
}
