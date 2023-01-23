using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public float spawnTime = 10f; // Time for the enemy to spawn
    //public int touchDamage = 100; // Damage dealt to player upon touch
    public float speed = 2f; // Speed at which the enemy will follow the player
    public bool chase;
    public GameObject kill_effect;
    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player object and store its transform
        player = GameObject.FindWithTag("Player").transform;
        
        
    }
    public void setchase()
    {
        chase=true;
        // Destroy the enemy after the spawn time has passed
        Destroy(gameObject, spawnTime);
    }
    void Update()
    {
        Vector3 pos=new Vector3(0f,2f,0f);
        // Move towards the player
        if(chase==true)
            transform.position = Vector2.MoveTowards(transform.position, player.position+pos, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player if the enemy touches the player
            other.transform.GetComponent<PrototypeHeroDemo>().kill();
            Instantiate(kill_effect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
