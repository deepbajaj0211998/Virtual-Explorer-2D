using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player if the enemy touches the player
            //StartCoroutine(other.transform.GetComponent<PrototypeHeroDemo>().kill());
            StartCoroutine(other.transform.GetComponent<advance_character_controller>().kill());
        }
    }
}
