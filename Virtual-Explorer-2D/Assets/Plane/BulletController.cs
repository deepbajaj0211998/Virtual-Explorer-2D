using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 30f; // Speed of the bullet
    public int damage = 100; // Damage dealt to enemies

    void Start()
    {
        // Move the bullet in the direction the gun is pointing
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Transform gunPoint = transform.parent;
        rb.velocity = gunPoint.right * speed;
        StartCoroutine(del());
    }

    void OnCollisionEnter2D(Collision2D other)
    {
            Debug.Log("monu");
        // If the bullet collides with an enemy, deal damage to the enemy and destroy the bullet
        if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("monu");
            enemy1 enemy = other.gameObject.GetComponent<enemy1>();
            StartCoroutine(other.gameObject.GetComponent<enemy1>().wait());

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator del()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
