using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    Animator animator;
    private ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        explosion = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetInteger("State") == 2)
            explosion.transform.position = this.transform.position;
            explode();
    }
    void explode()
    {
        explosion.Play();
    }
}
