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
       
        if (target != null)
            agent.SetDestination(target.transform.position);
        agent.isStopped = true;
        StartCoroutine(Idle());
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.enabled = false;
                StartCoroutine(Idle());
            }
        }
    }
    public IEnumerator Idle()
    {
        if (animator.GetInteger("State") != 0)
            animator.SetInteger("State", 0);


        yield return new WaitForSecondsRealtime(2);
        if (agent.hasPath)
        {
            animator.SetInteger("State", 1);
            agent.isStopped = false;
            agent.ResetPath();
            agent.destination = target.transform.position;
        }
    }
}
