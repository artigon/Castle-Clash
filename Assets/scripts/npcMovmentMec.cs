using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class npcMovmentMec : MonoBehaviour
{
    public GameObject walkPointFromUser;
    public GameObject enemy;
    public string enemyTag;
    public NavMeshAgent agent;
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
    public bool enemyInSightRange, enemyInAttackRange;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        walkPoint = walkPointFromUser.transform.position;
        walkPointSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        //check for sight and attack range
        if (!enemyInSightRange && !enemyInAttackRange)
            walkingTowalkPoint();
        if (enemyInSightRange && !enemyInAttackRange)
            chaseEnemy();
        if (enemyInSightRange && enemyInAttackRange)
            attackEnemy();
    }

    private void walkingTowalkPoint()
    {
        agent.SetDestination(walkPoint);


        //if (!walkPointSet)
        //{
        //    //make idel
        //    agent.enabled = false;
        //}
        //else
        //{
        //    agent.SetDestination(walkPoint);
        //}


        //if (transform.position.x - walkPoint.x <= 1f &&
        //    transform.position.z - walkPoint.z <= 1f)
        //    walkPointSet = false;

    }

    private void chaseEnemy()
    {
        agent.SetDestination(enemy.transform.position);
        //walkPointSet = false;

    }

    private void attackEnemy()
    {

        //agent.SetDestination(transform.position);

        //transform.LookAt(enemy);

        //if (!alreadyAttaked)
        //{
        //    alreadyAttaked = true;
        //    Invoke(nameof(resetAttack), timeBetweenAttacks);
        //}

    }

    private void resetAttack()
    {
        alreadyAttaked = false;
    }
}
