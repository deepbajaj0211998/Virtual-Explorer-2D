using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesActivation : MonoBehaviour
{

    //public GameObject spikes;
    //public float spikesMovementUp;
    //public float spikesPositionDown;
    //private bool isSpikeUp;
    //public PrototypeHeroDemo prototypeHero;
   
    public Rigidbody2D rb;
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale =0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.gravityScale = 1;
        }

     
    }

   /* private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isSpikeUp = true;
            StartCoroutine(nameof(SpikesUp));
        }
    }

    IEnumerator SpikesUp()
    {
        yield return new WaitForSeconds(2f);
        if (!isSpikeUp)
        {
            spikes.transform.localPosition = new Vector3(0, spikesMovementUp, 0);
            player.kill();
        }
        else
        {
            spikes.transform.localPosition = new Vector3(0, spikesPositionDown, 0);
        }
    }
    */

}
