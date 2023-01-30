using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;
    float dirX = 0f;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForce = 14f;

    enum MovementState { idle, running, jumping, falling}

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

		if (Input.GetButtonDown("Jump"))
		{
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}

        UpdateAnimationState();
    }

    void UpdateAnimationState()
	{
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f)
		{
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("State", (int)state);
    }

}
