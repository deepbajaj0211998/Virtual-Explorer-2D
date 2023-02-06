using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    public float minimumJumpForces;
    public float maximumJumpForces;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BouncyPlatform"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, Random.Range(minimumJumpForces, maximumJumpForces));
        }
    }

}
