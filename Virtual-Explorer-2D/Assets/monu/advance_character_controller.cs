using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class advance_character_controller : MonoBehaviour
{
    Animator animator;
    public float speed = 10f;
    public float jumpForce = 10f;
    public float gravityScale = 9.8f;
    public float groundCheckRadius = 0.2f;
    public float health = 100f;
    public bool alive=true;
    private int life=3;
    public Image health_image;
    [SerializeField] TextMeshProUGUI life_text;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject total_enemy;
    private Vector3             pos;
    public bool can_win=false;
    public GameObject kill_effect;
    public GameObject damage_effect;

    public bool godMode = false;
    public bool isCollected = false;

    private SpriteRenderer spriteRenderer;

    public LayerMask groundLayer;
    public Transform groundCheckPoint;

    private Rigidbody2D rigidBody;
    public bool isGrounded;


    void Start()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
		PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
		PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        pos=transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public IEnumerator kill()
    {
        if (!godMode)
        {
            GetComponent<SpriteRenderer>().enabled=false;
            GetComponent<BoxCollider2D>().enabled=false;
            GetComponent<CircleCollider2D>().enabled=false;
            GetComponent<CapsuleCollider2D>().enabled=false;
            GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
            Instantiate(kill_effect,transform.position,Quaternion.identity);
            alive=false;
            yield return new WaitForSeconds(2f);
            if (life > 1)
            {
                float z = PlayerPrefs.GetFloat("PlayerPosZ");
                float x = PlayerPrefs.GetFloat("PlayerPosX");
                float y = PlayerPrefs.GetFloat("PlayerPosY");
                life--;
                life_text.text = "x" + life.ToString();
                transform.localPosition = new Vector3(x, y, z);
                health = 100;
                alive=true;
                GetComponent<SpriteRenderer>().enabled=true;
                GetComponent<BoxCollider2D>().enabled=true;
                GetComponent<CircleCollider2D>().enabled=true;
                GetComponent<CapsuleCollider2D>().enabled=true;
                GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
                godMode = true;
                for(int i = 0; i < 10; i++)
                {
                    yield return new WaitForSeconds(1);
                    spriteRenderer.color = new Color(255, 255, 255, 100);
                }
                spriteRenderer.color = new Color(255, 255, 255, 255);
                godMode = false;
            }
            else
            {
                gameObject.SetActive(false);
                gameover.gameObject.SetActive(true);
                timer.transform.GetComponent<timetrail>().win();
            }
        }
    }

    void Update()
    {
        if(total_enemy.transform.childCount==0)
        {
            can_win=true;
        }
        if(alive==true)
        {
            if (health <= 0)
            {
                
                StartCoroutine(kill());
                
            }
            health_image.GetComponent<Slider>().value=health/100;
            float horizontal = Input.GetAxis("Horizontal");
            rigidBody.velocity = new Vector2(horizontal * speed, rigidBody.velocity.y);
            if(rigidBody.velocity.x>0)
                GetComponent<SpriteRenderer>().flipX=false;
            if(rigidBody.velocity.x<0)
                GetComponent<SpriteRenderer>().flipX=true;
            //isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
            RaycastHit2D hitright = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckRadius, groundLayer);
                if (hitright)
                {
                    if (hitright.transform.tag!="Player")
                    {
                        isGrounded=true;
                    }
                }
                else
                    isGrounded=false;
            animator.SetBool("Grounded",isGrounded);
            

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("Jump");
                rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
            }
            if(isGrounded )
            {
                if(horizontal!=0)
                    animator.SetInteger("AnimState",1);
                else
                    animator.SetInteger("AnimState",0);

            }
            

            // Apply gravity if player is falling
            Vector2 gravity = new Vector2(0, -gravityScale * Time.deltaTime);
            rigidBody.AddForce(gravity, ForceMode2D.Force);
            animator.SetFloat("AirSpeedY",rigidBody.velocity.y);
        }
    }
    public void TakeDamage(int damage)
    {
        if (!godMode)
        {
            Instantiate(damage_effect,transform.position,Quaternion.identity);
            health -= damage;
        }
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Key")
		{
            Destroy(collision.gameObject);
            isCollected = true;
        }
	}

}
