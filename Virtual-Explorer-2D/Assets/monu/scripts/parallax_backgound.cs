using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_backgound : MonoBehaviour
{
    public Transform[] backgrounds; // array of all the backgrounds to be scrolled
    public float smoothing = 1f; // the smoothing effect of the parallax

    private float[] parallaxScales; // proportion of the camera's movement to move the backgrounds
    private Transform cam; // reference to the main camera's transform
    private Vector3 previousCamPos; // store the position of the camera in the previous frame

    void Awake()
    {
        // set up the reference for the camera's transform
        cam = Camera.main.transform;
    }

    void Start()
    {
        // the previous frame had the current frame's camera position
        previousCamPos = cam.position;

        // asigning corresponding parallaxScales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    void Update()
    {
        // for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camera movement because the backgrounds move in the opposite direction of the camera movement
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // set a target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create a target position which is the background's current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            // fade between current position and the target position using lerp
            backgrounds[i].localPosition = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
