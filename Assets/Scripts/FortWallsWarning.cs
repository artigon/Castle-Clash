using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FortWallsWarning : MonoBehaviour
{
    public Text warningText;
    private bool frontWarning = false;
    private bool leftWarning = false;
    private bool backWarning = false;
    private bool rightWarning = false;
    // start is called before the first frame update
    void Start()
    {

    }

    // update is called once per frame
 
    public void setWarning(string walls)
    {
        switch (walls)
        {
            case "front":
                {
                    if (!frontWarning)
                    {
                        frontWarning = true;
                        warningText.gameObject.SetActive(true);
                        warningText.text = "warning an enemy has breach our front gates!";
                        StartCoroutine(closetext());
                    }
                }
                break;
            case "left":
                {
                    if (!leftWarning)
                    {
                        leftWarning = true;
                        warningText.gameObject.SetActive(true);
                        warningText.text = "to arms! an enemy has breach our left walls!";
                        StartCoroutine(closetext());
                    }
                }
                break;
            case "right":
                {
                    if(!rightWarning)
                    {
                        rightWarning = true;
                        warningText.gameObject.SetActive(true);
                        warningText.text = "to arms! an enemy has breach our right walls!";
                        StartCoroutine(closetext());
                    }
                }
                break;
            default: break;
        }
    }
    IEnumerator closetext()
    {
        yield return new WaitForSeconds(5);
        warningText.gameObject.SetActive(false);



    }
}
