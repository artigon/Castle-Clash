using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class npcMovmentMec : MonoBehaviour
{
    public float checkRangeForAttack;

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

        if (enemyInSightRange)
        {
            attackRange = Vector3.Distance(enemy.transform.position, this.transform.position);
            if (attackRange <= checkRangeForAttack)
                enemyInAttackRange = true;
            else
                enemyInAttackRange = false;
        }
        //if (enemyInSightRange && ((transform.position.x - enemy.transform.position.x <= 1f &&
        //    transform.position.z - enemy.transform.position.z <= 1f) || (transform.position.x + enemy.transform.position.x <= 1f &&
        //    transform.position.z + enemy.transform.position.z <= 1f)))
        //    enemyInAttackRange = true;

        //if (Physics.CheckSphere(this.gameObject.transform.position, 0.5f, whatIsEnemy))
        //    enemyInAttackRange = true;


        //check for sight and attack range
        if (!enemyInSightRange && !enemyInAttackRange)
            walkingTowalkPoint();
        if (enemyInSightRange && !enemyInAttackRange)
            chaseEnemy();
        if (enemyInSightRange && enemyInAttackRange)
            attackEnemy();
    }

    private void OnTriggerEnter(Collider other)
    {

        //parent.agent.enabled = false;
        if (other.gameObject.tag == enemyTag)
        {

            StartCoroutine(goToEnemy(other.gameObject));

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == enemyTag)
        {
            agent.SetDestination(walkPoint);
        }
    }

    IEnumerator goToEnemy(GameObject bjc)
    {

        yield return new WaitForSeconds(0.01f);
        enemyInSightRange = true;
        enemy = bjc;
    }

        private void walkingTowalkPoint()
    {
        agent.SetDestination(walkPoint);

    }

    private void chaseEnemy()
    {
        agent.SetDestination(enemy.transform.position);

    }

    private void attackEnemy()
    {
        agent.SetDestination(this.transform.position);
        transform.LookAt(enemy.transform);
        print(this.gameObject.tag + " attacking\n");

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
