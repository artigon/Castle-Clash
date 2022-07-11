using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CannonMec : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Idle());
        agent.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
        {
            animator.SetInteger("State", 1);
            agent.SetDestination(target.transform.position);

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.enabled = false;
                StartCoroutine(Idle());
            }
        }
    }
    public IEnumerator Idle()
    {
        agent.enabled = false;
        if (animator.GetInteger("State") != 0)
            animator.SetInteger("State", 0);


        yield return new WaitForSecondsRealtime(2);

        
    }
}
