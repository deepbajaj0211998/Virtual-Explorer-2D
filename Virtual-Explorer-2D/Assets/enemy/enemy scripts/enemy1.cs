using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float raydist = 2f;
    public Transform groundcheck;
    public GameObject kill_effect;
    public LayerMask platformLayer;
    private Rigidbody2D rigidbody2d;
    private bool movingRight = true;
    public int damage = 10;
    public int health = 100;
    public float timeBetweenAttacks = 0.5f;
    public float timeLastAttack = 0f;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(kill_effect,transform.position,Quaternion.identity);
            Destroy(gameObject);
            int killCount = PlayerPrefs.GetInt("KillCount");
            PlayerPrefs.SetInt("KillCount", killCount + 1);
        }
            rigidbody2d.velocity = new Vector2(patrolSpeed, rigidbody2d.velocity.y);
            RaycastHit2D hit = Physics2D.Raycast(groundcheck.position, Vector2.down, raydist, platformLayer);
            if (!hit)
            {
                if(movingRight==true)
                {
                    transform.eulerAngles=new Vector3(0,180,0);
                    patrolSpeed=-patrolSpeed;
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles=new Vector3(0,0,0);
                    patrolSpeed=-patrolSpeed;
                    movingRight = true;
                }
            }
            RaycastHit2D hitright = Physics2D.Raycast(groundcheck.position, Vector2.right, raydist, platformLayer);
            if (hitright)
            {

                if (hitright.transform.tag!="Player")
                if(movingRight==true)
                {
                    transform.eulerAngles=new Vector3(0,180,0);
                    patrolSpeed=-patrolSpeed;
                    movingRight = false;
                }
                else
                {
                    transform.eulerAngles=new Vector3(0,0,0);
                    patrolSpeed=-patrolSpeed;
                    movingRight = true;
                }
            }
            
       
       
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other is CapsuleCollider2D)
            {
                if (Time.time > timeLastAttack + timeBetweenAttacks)
                {
                    GetComponent<Animator>().SetTrigger("attack");
                    //other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
                    other.gameObject.GetComponent<PrototypeHeroDemo>().TakeDamage(damage);
                    timeLastAttack = Time.time;
                    
                }
            }  
        }
    }
    
    public void TakeDamage(int damage)
    {
        if(health>0)
        health -= damage;
        
    }
}
