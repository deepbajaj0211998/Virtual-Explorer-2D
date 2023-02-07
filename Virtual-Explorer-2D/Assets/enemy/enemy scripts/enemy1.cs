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
    bool is_alive=true;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(kill_effect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
    private void Update()
    {
        if(is_alive)
        {
            if (health <= 0)
            {
                
                GetComponent<Animator>().SetTrigger("death");
                GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
                GetComponent<BoxCollider2D>().enabled=false;
                //GetComponent<CapsuleCollider2D>().enabled=true;
                transform.GetChild(0).GetComponent<CapsuleCollider2D>().enabled=false;

                is_alive=false;
                StartCoroutine(wait());
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
                    // other.gameObject.GetComponent<PrototypeHeroDemo>().TakeDamage(damage);
                    other.gameObject.GetComponent<advance_character_controller>().TakeDamage(damage);
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
