using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class redSoldierNpcMec : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public GameObject enemyTarget = null;
    public GameObject targetFromUser;
    private Vector3 vTarget;
    private bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        setTargetByUser(targetFromUser);
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //setTargetByUser(targetFromUser);

        if (agent.enabled)
            agent.SetDestination(vTarget);

        if (enemyTarget != null)
        {
            if (this.transform.position.x - enemyTarget.transform.position.x <= 0.05f &&
                this.transform.position.z - enemyTarget.transform.position.z <= 0.05f)
            {
                StartCoroutine(npcAttacking());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!attacking)
        {
            if (other.tag == "Red")
            {
                enemyTarget = (GameObject)other.transform.gameObject;
                vTarget = enemyTarget.transform.position;
            }
        }
    }

    IEnumerator npcAttacking()
    {
        bool loop = false;
        if (enemyTarget.activeSelf)
        {
            agent.enabled = false;
            //change animation to attack
            //how health will work
            loop = true;
        }
        yield return new WaitForSecondsRealtime(1);
        if (loop)
        {
            StartCoroutine(npcAttacking());
        }
        else
        {
            enemyTarget = null;
            agent.enabled = true;
            vTarget = targetFromUser.transform.position;
            agent.SetDestination(vTarget);
        }
    }

    public void setTargetByUser(GameObject wayPoint)
    {
        targetFromUser = wayPoint;
        vTarget = targetFromUser.transform.position;
    }
}
