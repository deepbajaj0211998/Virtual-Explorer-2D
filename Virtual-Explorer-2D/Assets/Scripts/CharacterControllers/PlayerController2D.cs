using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController2D : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    bool isGrounded;
    int life = 3;
    float m_disableMovementTimer = 0.0f;
    [SerializeField]Transform groundCheck;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] TextMeshProUGUI life_text;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject total_enemy;

    public bool godMode = false;
    public GameObject kill_effect;
    public GameObject damage_effect;
    public Image health_image;
    public bool alive = true;
    public bool can_win = false;
    public float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public IEnumerator kill()
    {
        if (!godMode)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Instantiate(kill_effect, transform.position, Quaternion.identity);
            alive = false;
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
                alive = true;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<CapsuleCollider2D>().enabled = true;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                godMode = true;
                for (int i = 0; i < 10; i++)
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

    private void Update()
    {
        if (total_enemy.transform.childCount == 0)
        {
            can_win = true;
        }
        if (alive == true)
        {
            if (health <= 0)
            {

                StartCoroutine(kill());

            }
            // Decrease timer that disables input movement. Used when attacking
            m_disableMovementTimer -= Time.deltaTime;
            health_image.GetComponent<Slider>().value = health / 100;
        }
    }

	private void FixedUpdate()
	{
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }

		else
		{
            isGrounded = false;
            animator.Play("Player_Jump");
        }

		if(Input.GetKey("d") || Input.GetKey("right"))
		{
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            if(isGrounded)
                animator.Play("Player_Run");

            spriteRenderer.flipX = false;
		}
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            if (isGrounded)
                animator.Play("Player_Run");

            spriteRenderer.flipX = true;
        }
		else
		{
            if (isGrounded)
                animator.Play("Player_Idle");

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
		if (Input.GetKey("space") && isGrounded)
		{
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("Player_Jump");
        }
    }

    public void TakeDamage(int damage)
    {
        if (!godMode)
        {
            Instantiate(damage_effect, transform.position, Quaternion.identity);
            health -= damage;
        }
    }

}
