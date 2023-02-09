using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDustFromSpace : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PrototypeHeroDemo>().health = other.GetComponent<PrototypeHeroDemo>().health - damage;
        }
    }

}
