using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedParticle : MonoBehaviour
{
    public GameObject particlesystem;
    private float horizontal;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal > 0.5)
        {
            particlesystem.SetActive(true);
        }
        else
        {
            particlesystem.SetActive(true);
        }
    }
}
