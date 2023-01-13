using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex_Effect : MonoBehaviour
{

    [SerializeField] Vector2 ParallaxEffectMultiplier;
    Transform cameraTransform;
    Vector3 lastCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * ParallaxEffectMultiplier.x, deltaMovement.y * ParallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
    }
}
