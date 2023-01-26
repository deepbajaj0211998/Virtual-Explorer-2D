using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{

    public int damage;
    Animator animator;

    public float timeBetweenAttacks = 0.5f;
    public float timeLastAttack = 0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PrototypeHeroDemo>().TakeDamage(damage);
            if (Time.time > timeLastAttack + timeBetweenAttacks)
            {
                animator.SetBool("IsAttack", true);
                GetComponent<Animator>().SetTrigger("attack");
                //other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
                collision.gameObject.GetComponent<PrototypeHeroDemo>().TakeDamage(damage);
                timeLastAttack = Time.time;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetBool("IsAttack", false);
        }
    }

}
