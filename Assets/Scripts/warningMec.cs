using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningMec : MonoBehaviour
{
    public Text warningText;
    public GameObject warningObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showWarning(string tmp)
    {
        StartCoroutine(show(tmp));
    }

    IEnumerator show(string tmp)
    {
        warningObj.SetActive(true);
        warningText.text = tmp;
        yield return new WaitForSeconds(5);
        warningText.text = "";
        warningObj.SetActive(false);
    }
}
