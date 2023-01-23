using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticle : MonoBehaviour
{
    public GameObject particleSystem;
    private float horizontal;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal > 0.5)
        {
            particleSystem.SetActive(true);
        }
        else
        {
            particleSystem.SetActive(true);
        }
    }
}
