//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class FortWallsWarning : MonoBehaviour
//{
//    public GameObject FrontGate;
//    public GameObject leftwall;
//    public GameObject RightWall;
//    public GameObject BackWall;
//    public Text WarningText;
//    private int FrontWarning = 0, LeftWarning = 0, BackWarning = 0, RightWarning = 0;
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if ((FrontGate.activeSelf == false && FrontWarning == 0) || Input.GetKeyDown(KeyCode.E))
//        {
//            FrontWarning += 1;
//            WarningText.gameObject.SetActive(true);
//            WarningText.text = "Warning an enemy has breach our front gates!";
//            StartCoroutine(CloseText());

//        }

//        if (BackWall.activeSelf == false && BackWarning == 0)
//        {
//            BackWarning = +1;
//            WarningText.gameObject.SetActive(true);
//            WarningText.text = "Warning!! the foul enemies have breach our back walls!";
//            StartCoroutine(CloseText());

//        }
//        if (leftwall.activeSelf == false && LeftWarning == 0)
//        {
//            LeftWarning += 1;
//            WarningText.gameObject.SetActive(true);
//            WarningText.text = "To arms! an enemy has breach our Left walls!";
//            StartCoroutine(CloseText());

//        }
//        if (RightWall.activeSelf == false && RightWarning == 0)
//        {
//            RightWarning += 1;
//            WarningText.gameObject.SetActive(true);
//            WarningText.text = "To arms! an enemy has breach our Right walls!";
//            StartCoroutine(CloseText());

//        }



//    }
//    IEnumerator CloseText()
//    {
//        yield return new WaitForSeconds(5);
//        WarningText.gameObject.SetActive(false);



//    }
//}
