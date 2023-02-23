using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController_Goblin : MonoBehaviour
{

    public GameObject playerObject;
    public GameObject enemyObject;
    public Transform switchPosition;
    public float switchTime = 5f; // Time to switch back to player focus (in seconds)
    public float enemySpeed = 3f; // Enemy walking speed (in units per second)

    private CinemachineVirtualCamera virtualCamera;
    public bool switchedFocus = false;
    private float switchTimer = 0f;

    private void Start()
    {
        // Get the CinemachineVirtualCamera component from the camera object
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        // Set the initial focus of the virtual camera to the player object
        virtualCamera.Follow = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!switchedFocus)
        {
            // Check if the player object has reached the switch position
            if (playerObject.transform.position.x >= switchPosition.position.x)
            {
                // If it has, switch the focus of the virtual camera to the enemy object
                virtualCamera.Follow = enemyObject.transform;
                switchedFocus = true;
                switchTimer = switchTime; // Start the timer for switching back to player focus
            }
        }
        else
        {
            // Update the switch timer
            switchTimer -= Time.deltaTime;
            // Check if the switch timer has run out
            if (switchTimer <= 0f)
            {
                // If it has, switch the focus of the virtual camera back to the player object
                virtualCamera.Follow = playerObject.transform;
                switchedFocus = false;
            }
            else
            {
                // If the switch timer is still running, move the enemy object towards the player object
                Vector3 direction = (playerObject.transform.position - enemyObject.transform.position).normalized;
                enemyObject.transform.position += direction * enemySpeed * Time.deltaTime;
            }
        }
    }
}
