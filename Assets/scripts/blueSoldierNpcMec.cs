using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class blueSoldierNpcMec : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public GameObject enemyTarget;
    public GameObject targetFromUser;
    private Vector3 vTarget;
    private bool attacking = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyTarget = GameObject.FindGameObjectWithTag("Red");

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
            if (this.transform.position.x - enemyTarget.transform.position.x <= 0.05f && this.transform.position.z - enemyTarget.transform.position.z <= 0.05f)
            {

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
                StartCoroutine(npcAttacking());
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
        }
    }

    public void setTargetByUser(GameObject wayPoint)
    {
        targetFromUser = wayPoint;
        vTarget = targetFromUser.transform.position;
    }
}
