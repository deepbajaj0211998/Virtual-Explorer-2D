using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2detect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player if the enemy touches the player
            transform.parent.transform.GetComponent<enemy2>().setchase();
        }
    }
}
