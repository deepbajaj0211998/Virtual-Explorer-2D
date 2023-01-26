using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InVincibility : MonoBehaviour
{

    public PrototypeHeroDemo prototypeHero;
    BoxCollider2D boxCollider2d;
    SpriteRenderer spriteRenderer;
    public float invincibiltyTime;


    private void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {

        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            boxCollider2d.enabled = false;
            spriteRenderer.enabled = false;
            StartCoroutine(nameof(Invinsible));
        }
    }

    IEnumerator Invinsible()
    {
        prototypeHero.godMode = true;
        yield return new WaitForSeconds(invincibiltyTime);
        prototypeHero.godMode = false;
        Destroy(gameObject);
    }
}
