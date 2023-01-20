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
    public GameObject kill_effect;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAttacking)
        {
        }
            Patrol();

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

        if (health == 0)
        {
            Instantiate(kill_effect,transform.position,Quaternion.identity);
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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && other is CapsuleCollider2D)
        {
            GetComponent<Animator>().SetTrigger("attack");
            //other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            other.gameObject.GetComponent<PrototypeHeroDemo>().TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        if(health>0)
        health -= damage;
        
    }
}
