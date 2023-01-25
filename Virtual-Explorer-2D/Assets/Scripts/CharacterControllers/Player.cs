using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 10f;
    public Vector2 direction;
    public bool facingRight = true;
    public Rigidbody2D rb;
    public Animator animator;
    public float maxSpeed = 7f;

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

	private void FixedUpdate()
	{
        moveCharacter(direction.x);
	}

	void moveCharacter(float horizontal)
	{
        rb.AddForce(Vector2.right * horizontal * moveSpeed);
        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        if((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
		{
            Flip();
		}
	}

    void Flip()
	{
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
	}

}
