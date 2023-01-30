using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InVincibility : MonoBehaviour
{

    public PrototypeHeroDemo prototypeHero;
    BoxCollider2D boxCollider2d;
    SpriteRenderer spriteRenderer;
    public float invincibiltyTime;

    public Slider slider;


    private void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        slider.gameObject.SetActive(false);
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
        slider.gameObject.SetActive(true);
        prototypeHero.godMode = true;
        slider.maxValue = invincibiltyTime;
        slider.value = invincibiltyTime;
        for (int i = Mathf.FloorToInt(invincibiltyTime); i >= 0; i--)
        {
            yield return new WaitForSeconds(1f);
            slider.value = i;
        }
        slider.gameObject.SetActive(false);
        prototypeHero.godMode = false;
        Destroy(gameObject);
    }
}
