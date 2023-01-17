using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("positionX", transform.position.x);
            PlayerPrefs.SetFloat("positionY", transform.position.y);
        }
    }
}
