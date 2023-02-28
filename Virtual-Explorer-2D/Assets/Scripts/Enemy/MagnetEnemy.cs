using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEnemy : MonoBehaviour
{

    Rigidbody2D rb2d;
    public GameObject enemy;
    float timeStamp;
    private bool mangnet = false;
    public string enemyName;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (mangnet)
        {
            Vector2 enem = -(transform.position - enemy.transform.position).normalized;
            rb2d.velocity = new Vector2(enem.x, enem.y) * 5f * (Time.time / timeStamp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Magnet"))
        {
            //Debug.Log("test");
            //enemy.GetComponent<PlayerController2D>().enabled = false;
            mangnet = true;
            timeStamp = Time.time;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.name == enemyName)
    //    {
    //        enemy.GetComponent<PlayerController2D>().enabled = true;
    //        mangnet = false;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Magnet"))
    //    {
    //        mangnet = false;
    //    }
    //}

}
