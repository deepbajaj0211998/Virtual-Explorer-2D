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
    private float playerHealth;
    public float damege;

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
            rb2D.velocity = new Vector2(-enemySpeed, rb2D.velocity.y);
        }

        if(enemyHealth <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision is CircleCollider2D)
        //{
            if (collision.CompareTag("Player"))
            {
                trigger = true;
                animator.SetBool("Walk", true);
                playerHealth = collision.GetComponent<PlayerController2D>().health;
            }
        //}
        if (collision is BoxCollider2D)
        {
            if (collision.CompareTag("Player"))
            {
                trigger = false;
                animator.SetBool("Attack", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is BoxCollider2D)
        {
            if (collision.CompareTag("Player"))
            {
                trigger = true;
                animator.SetBool("Attack", false);
            }
        }
    }

    public void Attack()
    {
        playerHealth -= damege;
    }

}
