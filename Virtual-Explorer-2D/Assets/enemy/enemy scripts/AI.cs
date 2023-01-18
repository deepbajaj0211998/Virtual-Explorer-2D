using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float attackRange = 1.5f;
    public int damage = 10;
    public int health = 100;

    private int currentPatrolPoint = 0;
    private Transform player;
    private bool isAttacking = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAttacking)
        {
            Patrol();
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange)
        {
            isAttacking = true;
            Attack();
        }
        else
        {
            isAttacking = false;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolPoint].position, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolPoints[currentPatrolPoint].position) < 0.1f)
        {
            currentPatrolPoint++;
            if (currentPatrolPoint >= patrolPoints.Length)
            {
                currentPatrolPoint = 0;
            }
        }
    }

    void Attack()
    {
        // Play attack animation
        //player.GetComponent<PrototypeHeroDemo>().TakeDamage(damage);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetType()==typeof(CapsuleCollider2D))
        {
            other.gameObject.GetComponent<PrototypeHeroDemo>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
