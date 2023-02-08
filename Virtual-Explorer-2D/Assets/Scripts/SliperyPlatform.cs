using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliperyPlatform : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float slipForces;
    bool isSlipry = false;

    [Range(-1,1)]
    public float slipDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isSlipry)
        {
            rigidbody2D.velocity = new Vector2(slipDirection * slipForces, rigidbody2D.velocity.y);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SliperyPlatform"))
        {
            isSlipry = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SlipLeftToRight"))
        {
            slipDirection = 1;
        }
        if (collision.CompareTag("SlipRightToLeft"))
        {
            slipDirection = -1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SliperyPlatform"))
        {
            isSlipry = false;
        }
    }
}
