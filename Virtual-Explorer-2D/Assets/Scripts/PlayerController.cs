using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{

    float movementInputDirection;
    float m_disableMovementTimer = 0.0f;
    int life = 3;
    Vector3 pos;
    Vector3 currentPos;
    Rigidbody2D rb;
    Animator animator;
    bool isFacingRight = true;
    bool isWalking;
    bool isGrounded;
    bool canJump;
    [SerializeField] int health = 100;
    [SerializeField] Image health_image;
    [SerializeField] TextMeshProUGUI life_text;
    [SerializeField] GameObject timer;
    [SerializeField] GameObject gameover;
    public float movementSpeed = 10f;
    public float jumpForce = 16f;
    public float groundCheckRadius;
    public Transform groundCheck;
    public LayerMask WhatIsGround;
    MainMenuManager manager;
    public bool isLoadedFromSaved = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (isLoadedFromSaved)
		{
            Vector3 savePos = Vector3.zero;

            // Fetch save position.
            savePos.z = PlayerPrefs.GetInt("PlayerPosZ");
            savePos.x = PlayerPrefs.GetInt("PlayerPosX");
            savePos.y = PlayerPrefs.GetInt("PlayerPosY");

            // Set save position
            transform.position = savePos;
        }
		else
		{
            currentPos.x = transform.position.x;
            currentPos.y = transform.position.y;
            currentPos.z = transform.position.z;
            transform.position = currentPos;
        }
    }

    public void kill()
    {
        if (life > 1)
        {
            float z = PlayerPrefs.GetFloat("PlayerPosZ");
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            life--;
            life_text.text = "x" + life.ToString();
            transform.localPosition = new Vector3(x, y, z);
            health = 100;
        }
        else
        {
            gameObject.SetActive(false);
            gameover.gameObject.SetActive(true);
            timer.transform.GetComponent<timetrail>().win();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            kill();
        }

        m_disableMovementTimer -= Time.deltaTime;
        health_image.fillAmount = health / 100;

        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
    }

	private void FixedUpdate()
	{
        ApplyMovement();
        CheckSurroundings();
    }

    void CheckSurroundings()
	{
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
	}

    void CheckIfCanJump()
	{
        if(isGrounded && rb.velocity.y <= 0)
		{
            canJump = true;
		}
		else
		{
            canJump = false;
		}
	}

    void CheckMovementDirection()
	{
        if(isFacingRight && movementInputDirection < 0)
		{
            Flip();
		}
        else if(!isFacingRight && movementInputDirection > 0)
		{
            Flip();
        }

        if(rb.velocity.x != 0)
		{
            isWalking = true;
		}
		else
		{
            isWalking = false;
		}
	}

    void UpdateAnimations()
	{
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
	}

	void CheckInput()
	{
        movementInputDirection = Input.GetAxisRaw("Horizontal");
		if (Input.GetButtonDown("Jump"))
		{
            Jump();
		}
    }

    void Jump()
	{
		if (canJump)
		{
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
	}

    void ApplyMovement()
	{
        rb.velocity = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
	}

    void Flip()
	{
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
	}

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.GetComponent<AI>().TakeDamage(100);
        }
    }

}
