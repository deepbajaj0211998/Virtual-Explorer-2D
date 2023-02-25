using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamController : MonoBehaviour
{
    public float speed = 20f; // Speed of the laser beam
    public int damage = 100; // Damage dealt to enemies

    public Transform gunPoint; // Point where the laser beam is spawned
    //private LineRenderer lineRenderer; // Line Renderer component of the laser beam

    void Start()
    {
        // Get the gun point and line renderer components
        //gunPoint = transform.parent;
        //lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {

        // Update the length of the laser beam based on the distance to the nearest object in its path
        RaycastHit2D hit = Physics2D.Raycast(gunPoint.transform.position, transform.right);
        if (hit.collider != null)
        {
            //lineRenderer.SetPosition(1, new Vector3(hit.distance, 0, 0));
            // If the laser beam collides with an enemy, deal damage to the enemy
            if (hit.collider.CompareTag("enemy"))
            {
                Debug.Log("monu");
                enemy1 enemy = hit.collider.GetComponent<enemy1>();
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            //lineRenderer.SetPosition(1, new Vector3(100, 0, 0)); // Set the length of the laser beam to a very large number if no object is detected
        }
    }
}
