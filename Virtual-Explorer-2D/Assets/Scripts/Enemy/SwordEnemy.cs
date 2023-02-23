using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : MonoBehaviour
{

    public bool trigger = false;
    private Rigidbody2D rb2D;
    public float enemySpeed;
    private Animator animator;
    public float enemyHealth;
    public float damege;
    private bool canTakeDamage = false;
    public PlayerController2D playerController2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (trigger)
        {
            animator.SetBool("Walk", true);
            rb2D.velocity = new Vector2(-enemySpeed, rb2D.velocity.y);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (enemyHealth <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision is EdgeCollider2D)
            {
                trigger = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision is CapsuleCollider2D)
            {
                trigger = false;
                animator.SetBool("Attack", true);
                canTakeDamage = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is CapsuleCollider2D)
        {
            if (collision.CompareTag("Player"))
            {
                trigger = true;
                animator.SetBool("Attack", false);
                canTakeDamage = false;
            }
        }
    }

    public void Attack()
    {
        if (canTakeDamage)
        {
            playerController2d.health -= damege;
        }
    }

}
