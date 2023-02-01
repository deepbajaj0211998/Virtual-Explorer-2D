using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class shake : MonoBehaviour
{
   public float shakeDuration = 0.5f; // How long the camera shake should last
    public float shakeAmount = 0.7f; // How intense the shake should be
    float shakeAmt; // How intense the shake should be
    public float decreaseFactor = 1.0f; // How quickly the shake should decrease

    private Vector3 originalPos; // The original position of the camera

    void Start()
    {
        originalPos = transform.position;
    }

    public void Shake()
    {
        // Set the camera's position to the original position
        GetComponent<CameraFollow>().enabled=false;
        shakeAmt=shakeAmount;
        // Start a coroutine that shakes the camera
        StartCoroutine(DoShake());
    }

    IEnumerator DoShake()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            // Get a random position within the shake amount
            float x = Random.Range(-1f, 1f) * shakeAmt;
            float y = Random.Range(-1f, 1f) * shakeAmt;

            // Set the camera's position to the new random position
            transform.position = new Vector3(transform.position.x+x, transform.position.y+y, transform.position.z);

            elapsed += Time.deltaTime;

            // Reduce the shake amount over time
            shakeAmt = Mathf.Lerp(shakeAmt, 0f, elapsed * decreaseFactor);

            yield return null;
        }
        GetComponent<CameraFollow>().enabled=true;
        
    }
}
