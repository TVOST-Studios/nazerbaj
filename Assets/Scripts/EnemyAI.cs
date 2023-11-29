using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    Enemy _enemy;
    
    public NavMeshAgent agent;
    public Transform player;

    public LayerMask isGround, isPlayer;

    //Patroling

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public AIGun gun;

    //States

    public float sightRange, attackRange;
    public bool playerInSight, playerInAttackRange;

    private bool isDead = false;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        // Ignore collisions between the AI and its projectiles
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("AI"), LayerMask.NameToLayer("AIProjectile"));
    }


    public void Update()
    {
        isDead = _enemy.isDead;
        playerInSight = Physics.CheckSphere(transform.position, sightRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if(isDead) { return; }

        if(!playerInSight && !playerInAttackRange) { Patroling(); }
        if(playerInSight && !playerInAttackRange) { ChasePlayer(); }
        if(playerInAttackRange && playerInSight) { AttackPlayer(); }

    }



    private void Patroling()
    {
        if (!walkPointSet) { SearchWalkPoint(); }

        if (walkPointSet) { agent.SetDestination(walkPoint); }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f) { walkPointSet = false; }

        _enemy.EnemyWalkAnimation();
        
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint,-transform.up,2f,isGround))
        {
            NavMeshHit hit;
            if(NavMesh.SamplePosition(walkPoint,out hit, 1.0f,NavMesh.AllAreas)) { walkPointSet = true; }
            else { walkPointSet = false; }
            
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        _enemy.EnemyWalkAnimation();
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked && !OtherAIIsInTheWay() && isDead == false)
        {
            agent.SetDestination(transform.position);   //makes sure the enemy doesnt move

            transform.LookAt(player);
            //Shooting here
            gun.GunFireProjectileAI();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            print("enemy attacked you!");
            _enemy.EnemyShootAnimation();
        }
    }

    bool OtherAIIsInTheWay() {
        // Use raycasting to check if other AI is in the way
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            if (hit.collider.gameObject.tag == "Enemy") {
                return true;
            }
        }
        return false;
    }

    private void ResetAttack() { alreadyAttacked = false; }
}
