using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float health = 100f;
    public float detectionRange = 20f;
    public float attackRange = 10f;
    public float damage = 10f;
    public Transform player;
    public NavMeshAgent agent;
    public LayerMask whatIsPlayer;

    private bool playerInSight;

    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, detectionRange, whatIsPlayer);

        if (playerInSight)
        {
            agent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (!agent.hasPath)
        {
            Vector3 randomDirection = Random.insideUnitSphere * 10f;
            randomDirection += transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
    }

    void AttackPlayer()
    {
        Debug.Log("Enemy attacking player!");
        // You can add player health reduction logic here
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}