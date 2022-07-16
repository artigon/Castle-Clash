using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonDeathAnimeMEc : MonoBehaviour
{
    public bool startCHeck = false;
    public GameObject flame,explotion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startCHeck)
        {
            flame.SetActive(true);
            explotion.SetActive(true);

        }
    }

 
}
