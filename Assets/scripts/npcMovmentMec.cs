using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class npcMovmentMec : MonoBehaviour
{
    public GameObject walkPointFromUser;
    public GameObject enemy;
    public string enemyTag;
    private NavMeshAgent agent;
    private Animator animator;
    //public Transform enemy;
    public LayerMask whatIsGround, whatIsEnemy;

    //going to wayPoint
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;// mabye not need

    //Arracking
    private bool alreadyAttaked;
    public float timeBetweenAttacks;

    //States
    public float sightRange, attackRange;
    public float checkRangeForAttack;
    public bool enemyInSightRange, enemyInAttackRange;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("state", 0);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        walkPoint = walkPointFromUser.transform.position;
        walkPointSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectWithTag(enemyTag);

        //if (enemy == null)
        //    walkingTowalkPoint();

        enemyInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsEnemy);

        if (enemyInSightRange)
        {
            attackRange = Vector3.Distance(enemy.transform.position, this.transform.position);
            if (attackRange <= checkRangeForAttack)
                enemyInAttackRange = true;
            else
                enemyInAttackRange = false;
        }


        //check for sight and attack range
        if (!enemyInSightRange && !enemyInAttackRange)
            walkingTowalkPoint();
        if (enemyInSightRange && !enemyInAttackRange)
            chaseEnemy();
        if (enemyInSightRange && enemyInAttackRange)
            attackEnemy();
    }

    //DO NOT DELETE THIS COMMENT CODE, AFRAID WILL BREAK!
    //private void OnTriggerEnter(Collider other)
    //{

    //    //parent.agent.enabled = false;
    //    if (other.gameObject.tag == enemyTag)
    //    {

    //        StartCoroutine(goToEnemy(other.gameObject));

    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == enemyTag)
    //    {
    //        agent.SetDestination(walkPoint);
    //    }
    //}

    IEnumerator goToEnemy(GameObject bjc)
    {

        yield return new WaitForSeconds(0.01f);
        enemyInSightRange = true;
        enemy = bjc;
    }

    private void walkingTowalkPoint()
    {
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            animator.SetInteger("state", 1);
        }
        else
        {
            agent.SetDestination(this.transform.position);
            animator.SetInteger("state", 0);
        }
    }

    private void chaseEnemy()
    {
        agent.SetDestination(enemy.transform.position);
        animator.SetInteger("state", 1);
    }

    private void attackEnemy()
    {
        animator.SetInteger("state", 2);
        agent.SetDestination(this.transform.position);
        transform.LookAt(enemy.transform);
        print(this.gameObject.tag + " attacking\n");

        if (!alreadyAttaked)
        {
            alreadyAttaked = true;
            Invoke(nameof(resetAttack), timeBetweenAttacks);
        }

    }

    private void resetAttack()
    {
        alreadyAttaked = false;
    }
}
