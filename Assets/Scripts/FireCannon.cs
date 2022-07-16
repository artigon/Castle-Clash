using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEditor.Animations;
public class FireCannon : MonoBehaviour
{
    // This script launches a projectile prefab by instantiating it at the position
    // of the GameObject on which it is placed, then then setting the velocity
    // in the forward direction of the same GameObject.

    public Animator animator;
    public Rigidbody projectile;
    public float speed = 4;
    void Start()
    {
        canoneFire();
        
    }
    // Update is called once per frame
    void Update()
    { 
        
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
            p.velocity = transform.forward * speed;
        }
    }

    public void canoneFire()
    {
        if (animator.GetNextAnimatorStateInfo(0).IsName("AttackingCannon"))
        { 
            Rigidbody p = Instantiate(projectile, transform.position, transform.rotation);
            p.velocity = transform.forward * speed;
        }
    }
}
