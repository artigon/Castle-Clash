using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class optionCoins : MonoBehaviour
{
    public Scrollbar scrollbar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollbar.value == 0)
            gameMecanecSystem.numCoindAdd = 100;
        else if (scrollbar.value == 0.5)
            gameMecanecSystem.numCoindAdd = 50;
        else if (scrollbar.value == 1)
            gameMecanecSystem.numCoindAdd = 25;
    }

    public void chengeCoins()
    {
        if (scrollbar.value == 0)
            gameMecanecSystem.numCoindAdd = 100;
        else if (scrollbar.value == 0.5)
            gameMecanecSystem.numCoindAdd = 50;
        else if (scrollbar.value == 1)
            gameMecanecSystem.numCoindAdd = 25;
    }
}
