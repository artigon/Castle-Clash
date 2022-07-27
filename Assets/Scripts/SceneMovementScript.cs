using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneMovementScript : MonoBehaviour
{
    public static bool firstMovment = true;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && firstMovment)
        {
            firstMovment = false;
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneMovement()
    {
        print("Button Is clicked");
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
       // StartCoroutine(SceneSwitch());//run in parallel
    }
    IEnumerator SceneSwitch()
    {
        //play fade in animation
        //delay
        yield return new WaitForSeconds(2);
        //SceneSwitch
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
