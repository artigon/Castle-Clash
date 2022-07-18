using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallHealth : MonoBehaviour
{
    public int health;
    public bool isFrontGate;
    private GameObject gate;
    private List<GameObject> walls;
    private List<GameObject> rubbles;
    private List<GameObject> ruinedWalls;
    public bool isSemiRuined;
    public bool isWrecked;
    public FortWallsWarning warningScript;
    // Start is called before the first frame update
    void Start()
    { 
        walls = new List<GameObject>();
        rubbles = new List<GameObject>();
        ruinedWalls = new List<GameObject>();
        setListGameObjects(walls, 0); // index of son
        setListGameObjects(ruinedWalls, 1); // index of son
        setListGameObjects(rubbles, 2); // index of son
        if (isFrontGate)
            gate = transform.Find("FrontGateHP").GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (isWrecked)
        //{
        //    if (isFrontGate)
        //        warningScript.setWarning("front");
        //    else if (gameObject.name == "LeftSideWalls")
        //        warningScript.setWarning("left");
        //    else if (gameObject.name == "RightSideWalls")
        //        warningScript.setWarning("right");
        //    else
        //        warningScript.setWarning("back"); 
        //}

        if (health < 40 && health > 0 && !isSemiRuined)
        {
            StartCoroutine(setWalls(getActiveObject(),1)); // 1 = ruinedWalls new state
            isSemiRuined = true;
            isWrecked = false;
        }
        else
        if (health <= 0)
        {
            StartCoroutine(setWalls(getActiveObject(),2)); // 2 = rubbles new state
            isWrecked = true;
            isSemiRuined = false;
        }
          
        IEnumerator setWalls(int activeIndex, int newIndex)
        {
            yield return new WaitForSeconds(0.5f);
            switch (activeIndex)
            {
                case 0: //  regular Wall
                    {
                        for (int i = 0; i < walls.Count; i++)
                            walls[i].SetActive(false);
                        if (isFrontGate)
                            gate.SetActive(false);
                    }
                    break;
                case 1: // ruined wall
                    {
                        for (int i = 0; i < ruinedWalls.Count; i++)
                            ruinedWalls[i].SetActive(false);
                    }
                    break;
                case 2: // rubble
                    {
                        for (int i = 0; i < rubbles.Count; i++)
                            rubbles[i].SetActive(false);
                    }
                    break;
            }
            switch (newIndex)
            {
                case 0:  //  regular Wall
                    {
                        for (int i = 0; i < walls.Count; i++)
                            walls[i].SetActive(true);
                        if (isFrontGate)
                            gate.SetActive(true);
                    }
                    break;
                case 1: // ruined wall
                    {
                        for (int i = 0; i < ruinedWalls.Count; i++)
                            ruinedWalls[i].SetActive(true);
                    }
                    break;
                case 2: // rubble
                    {
                        for (int i = 0; i < rubbles.Count; i++)
                            rubbles[i].SetActive(true);
                    }
                    break;
            }
        }      
    }
    public int getActiveObject()
    {
            for (int i = 0; i < transform.GetChild(0).childCount; i++)
            {
                if (transform.GetChild(0).GetChild(i).gameObject.activeSelf)
                    return i;
            }
        
        return -1;
    }
    public void setListGameObjects(List<GameObject> l, int childIndex)
    {
        for (int i = 0; i < transform.childCount; i++)
            l.Add(transform.GetChild(i).GetChild(childIndex).gameObject);
        
    }

    public void takeDamege(int damege)
    {
        health = health - damege;
    }
}
