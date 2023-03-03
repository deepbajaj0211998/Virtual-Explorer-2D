using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of the plane
    public float jumpForce = 5.0f; // Jump force of the plane
    public GameObject laserBeam; // Prefab of the laser beam
    public GameObject bullet; // Prefab of the bullet
    public Transform gunPoint; // Point where the bullet is spawned
    public float fireRate = 0.5f; // Delay between bullet shots
    private float nextFireTime = 0.0f; // Time of the next allowed bullet shot

    private Rigidbody2D rb; // Rigidbody2D component of the plane
    bool fir=false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        // Move the plane horizontally
        //float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float move = speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Jump the plane when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Shoot the laser beam when the left mouse button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            fir=true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            laserBeam.SetActive(false);
            fir=false;
        }
        if(fir==true)
        {
            laserBeam.SetActive(true);
            laserBeam.GetComponent<LineRenderer>().SetPosition(0,(Vector2)gunPoint.position);
            Camera mainCamera = Camera.main;
            // Get the mouse position in screen coordinates
            Vector3 mousePositionScreen = Input.mousePosition;

            // Set the distance from the camera to the game world plane
            float distanceToPlane = 10.0f;

            // Convert the mouse position to a point on the game world plane
            Vector3 mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(mousePositionScreen.x, mousePositionScreen.y, distanceToPlane));

            // laserBeam.GetComponent<LineRenderer>().SetPosition(1,(Vector2)gunPoint.position+ new Vector2(30f,0f));
            laserBeam.GetComponent<LineRenderer>().SetPosition(1,(Vector2)mousePositionWorld);
        }

        // Shoot bullets when the right mouse button is pressed
        if (Input.GetButtonDown("Fire2") && Time.time > nextFireTime)
        {
            GameObject x=Instantiate(bullet, gunPoint.position, gunPoint.rotation);
            nextFireTime = Time.time + fireRate;
            x.transform.SetParent(gunPoint);
        }
    }
}
