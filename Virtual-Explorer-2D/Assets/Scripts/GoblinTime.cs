using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinTime : MonoBehaviour
{

    public Text texts;
    public float time;
    public enemy_level_2 enemy;

    // Update is called once per frame
    void Update()
    {
        //texts.text = Time.deltaTime * time.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(nameof(TimeForWake));
        }
    }

    IEnumerator TimeForWake()
    {
        for(float i = time; i >= 0; i--)
        {
            yield return new WaitForSeconds(1f);
        }
        enemy.enabled = true;
    }
}
