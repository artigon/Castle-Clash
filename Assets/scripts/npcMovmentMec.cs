using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class npcMovmentMec : MonoBehaviour
{
    private Vector3 redWalkToKinght = new Vector3(651f, 12.19f, 512.4f);
    private Vector3 redWalkToArcher = new Vector3(651f, 12.19f, 438.8f);
    private Vector3 redWalkToCanon = new Vector3(651f, 12.19f, 568.9f);

    private Vector3 blueWalkToKinght = new Vector3(1358.5f, 12.19f, 506.3f);
    private Vector3 blueWalkToArcher = new Vector3(1358.5f, 12.19f, 583f);
    private Vector3 blueWalkToCanon = new Vector3(1358.5f, 12.19f, 438.8f);

    public bool attackAi = false;
    private bool atttackAicheck = true;
    public FireCannon fireCannonScript;
    public bool isCanone;
    public bool canAttack = true;
    public int npcDamegePoints;
    public GameObject walkPointFromUser;
    public GameObject enemy;
    public GameObject enemyFort;
    public string enemyTag;
    public string enemyFortTag;
    private NavMeshAgent agent;
    private Animator animator;
    //public Transform enemy;
    public LayerMask whatIsGround, whatIsEnemy, whatIsEnemyFort;

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
    public bool enemyFortInSightRange, enemyFortInAttackRange;

    public bool walkToPointOrder = false;


    // Start is called before the first frame update
    void Start()
    {
        

        if (isCanone)
            animator = transform.GetChild(1).gameObject.GetComponent<Animator>();
        else
            animator = GetComponent<Animator>();
        //animator.SetInteger("state", 0);
        //animator.SetInteger("state", 2);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = true;
        //walkPoint = walkPointFromUser.transform.position;
        walkPointSet = false;


        if (this.name == "redKinghtNPC(Clone)")
            getWalkPoint(redWalkToKinght);
        if (this.name == "redArcherNPC(Clone)")
            getWalkPoint(redWalkToArcher);
        if (this.name == "RedCannonP(Clone)")
            getWalkPoint(redWalkToCanon);


        if (this.name == "blueknightNPC(Clone)")
            getWalkPoint(blueWalkToKinght);
        if (this.name == "blueArcherNPC(Clone)")
            getWalkPoint(blueWalkToArcher);
        if (this.name == "BlueCannonP(Clone)")
            getWalkPoint(blueWalkToCanon);
    }

    // Update is called once per frame
    void Update()
    {
        if(walkToPointOrder)
        {
            if (Vector3.Distance(walkPoint, this.transform.position) <= 10f)
                walkToPointOrder = false;
        }

        if (attackAi && atttackAicheck)
            attackAiFunc();

        if (Vector3.Distance(walkPoint, this.transform.position) <= 10f)
            walkPointSet = false;
        if (!canAttack)
            agent.SetDestination(this.transform.position);
        //if (Input.GetKeyDown(KeyCode.Space))
        //    walkPointSet = true;

        enemy = GameObject.FindGameObjectWithTag(enemyTag);
        enemyFort = GameObject.FindGameObjectWithTag(enemyFortTag);

        if (enemy == null)
            walkingTowalkPoint();

        enemyInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsEnemy);

        if (enemyInSightRange)
        {
            attackRange = Vector3.Distance(enemy.transform.position, this.transform.position);
            if (attackRange <= checkRangeForAttack)
                enemyInAttackRange = true;
            else
                enemyInAttackRange = false;
        }

        //enemyFortInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsEnemyFort);

        if (enemyFortInSightRange = Physics.CheckSphere(this.transform.position, sightRange, whatIsEnemyFort))
        {
            attackRange = Vector3.Distance(enemyFort.transform.position, this.transform.position);
            if (attackRange <= checkRangeForAttack)
                enemyFortInAttackRange = true;
            else
                enemyFortInAttackRange = false;
        }

        if (!walkToPointOrder)
        {
            //check for sight and attack range
            if (!enemyInSightRange && !enemyInAttackRange)
                walkingTowalkPoint();
            if (enemyInSightRange && !enemyInAttackRange)
                chaseEnemy();
            if (enemyInSightRange && enemyInAttackRange)
                attackEnemy();
            //if (enemyFortInSightRange && !enemyFortInAttackRange)
            //    goToFort();
            if (enemyFortInSightRange && enemyFortInAttackRange)
                attackFort();
        }


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

    public void walkToWalkPointOrder(Vector3 v)
    {
        walkPoint = v;
        walkToPointOrder = true;
        agent.SetDestination(walkPoint);
        StartCoroutine(changeState(1));
    }

    private void walkingTowalkPoint()
    {
        enemyInAttackRange = false;
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
            StartCoroutine(changeState(1));

        }
        else
        {
            agent.SetDestination(this.transform.position);
            StartCoroutine(changeState(0));

        }
    }

    private void chaseEnemy()
    {
        agent.SetDestination(enemy.transform.position);
        //animator.SetInteger("state", 1);
        //StartCoroutine(changeState(2));

    }

    private void attackEnemy()
    {
        if (canAttack)
        {
            if (isCanone)
                StartCoroutine(fireCannonScript.canoneFire());
            else
                StartCoroutine(changeState(2));

            agent.SetDestination(this.transform.position);
            transform.LookAt(enemy.transform);
            print(this.gameObject.name + " attacking\n");

            
            enemy.GetComponent<npcHealthMec>().takeDamege(npcDamegePoints);

            if (!alreadyAttaked)
            {
                alreadyAttaked = true;
                Invoke(nameof(resetAttack), timeBetweenAttacks);
            }

        }

    }

    private void resetAttack()
    {
        alreadyAttaked = false;
    }

    IEnumerator changeState(int menu)
    {
        yield return new WaitForSeconds(0.01f);
        switch (menu)
        {
            case 0:
                {
                    //idle
                    animator.SetInteger("state", 0);
                    break;
                }
            case 1:
                {
                    //running
                    animator.SetInteger("state", 1);
                    break;
                }
            case 2:
                {
                    //attacking
                    animator.SetInteger("state", 2);
                    break;
                }
            case 3:
                {
                    //death
                    animator.SetInteger("state", 3);
                    break;
                }
        }
    }

    public void getWalkPoint(Vector3 v)
    {
        walkPoint = v;
        walkPointSet = true;
    }

    public void attackAiFunc()
    {
        walkPoint = new Vector3(1398, 19.35f, 567.3f); 
        walkPointSet = true;
        atttackAicheck = false;
    }

    //public void goToFort()
    //{
    //    agent.SetDestination(enemyFort.transform.position);

    //}

    //public void attackFortFirst(GameObject fort)
    //{
    //    enemyFort = fort;
    //    attackFort();
    //}

    public void attackFort()
    {
        StartCoroutine(changeState(2));
        agent.SetDestination(this.transform.position);
        transform.LookAt(enemyFort.transform);
        if (isCanone)
            StartCoroutine(fireCannonScript.canoneFire());
        if (enemyFort.name.Equals("TowerParent"))
            enemyFort.GetComponent<Fort>().TakeDamage(npcDamegePoints);
        else
            enemyFort.GetComponent<WallHealth>().takeDamege(npcDamegePoints);

        Invoke(nameof(resetAttackFort), timeBetweenAttacks);

    }

    public void resetAttackFort()
    {
        if (enemyFort.name.Equals("TowerParent"))
        {
            if (enemyFort.GetComponent<Fort>().health > 0)
                attackFort();
        }
        else
        {
            if (enemyFort.GetComponent<WallHealth>().health > 0)
                attackFort();
        }
    }


}
