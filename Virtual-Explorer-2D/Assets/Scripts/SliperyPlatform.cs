using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliperyPlatform : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float slipForces;
    bool isSlipry = false;
    float playerInput;

    [Range(-1,1)]
    public float slipDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerInput = Input.GetAxis("Horizontal");
        slipDirection = playerInput;
    }

    private void FixedUpdate()
    {
        if (isSlipry)
        {
            rigidbody2D.velocity = new Vector2(slipDirection * slipForces, rigidbody2D.velocity.y);
        }
       /* else
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);
        }*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("SliperyPlatform"))
        {
            isSlipry = true;
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
