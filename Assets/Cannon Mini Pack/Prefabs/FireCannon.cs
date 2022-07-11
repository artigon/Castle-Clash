using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public GameObject Cannon;
    private Rigidbody rb;
    public GameObject shot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.G))
        {
            Vector3 direction = Cannon.transform.forward; // by the Cannon direction
            direction.y = 0.5f; // upper direction
            rb.AddForce(5f * direction, ForceMode.Impulse); // 2.6* is the power pushing
            rb.useGravity = true;
            StartCoroutine(Airshot());
        }
        IEnumerator Airshot()
        {
            yield return new WaitForSeconds(2);
            shot.SetActive(false);
        }
    }
}
