using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class warningMec : MonoBehaviour
{
    public Text warningText;
    public GameObject warningObj;
    private AudioSource warningSound;
    // Start is called before the first frame update
    void Start()
    {
        warningSound = GetComponent<AudioSource>();
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
        warningSound.Play();
        warningObj.SetActive(true);
        warningText.text = tmp;
        yield return new WaitForSeconds(5);
        warningText.text = "";
        warningObj.SetActive(false);
    }
}
