using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainDamage : MonoBehaviour
{
    public float minimumDamage;
    public float maximumDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PrototypeHeroDemo>().health = collision.GetComponent<PrototypeHeroDemo>().health - Random.Range(minimumDamage, maximumDamage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
