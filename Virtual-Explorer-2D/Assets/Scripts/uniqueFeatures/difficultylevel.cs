using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class difficultylevel : MonoBehaviour
{
    public int difficultyLevel = 1;
    
    public int health = 100;
    public int damage = 10;
    public float attackRate = 1f;
    public float attackRange = 5f;

    public bool canTeleport = false;
    public float teleportCooldown = 5f;

    private float lastAttackTime;
    private float lastTeleportTime;

    void Start()
    {
        change_difficulty_level();
    }
    void change_difficulty_level()
    {
        // adjust enemy stats based on difficulty level
        if (difficultyLevel == 1)
        {
        health = 100;
        damage = 10;
        attackRate = 1f;
        attackRange = 5f;
        canTeleport = false;
        teleportCooldown = 5f;
        }
        else if (difficultyLevel == 2)
        {
        health = 150;
        damage = 15;
        attackRate = 0.75f;
        attackRange = 6f;
        canTeleport = false;
        teleportCooldown = 5f;
        }
        else if (difficultyLevel == 3)
        {
        health = 200;
        damage = 20;
        attackRate = 0.5f;
        attackRange = 7f;
        canTeleport = true;
        teleportCooldown = 3f;
        }
        // ...add additional difficulty levels as needed
    }
    void update()
    {
        // handle enemy attacks and movement
        if (Time.time - lastAttackTime >= attackRate)
        {
        //Attack();
        lastAttackTime = Time.time;
        }
        if (canTeleport && Time.time - lastTeleportTime >= teleportCooldown)
        {
        Teleport();
        lastTeleportTime = Time.time;
        }
  }

    /*void Attack()
    {
        // find player and deal damage if within attack range
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null && Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
        player.TakeDamage(damage);
        }
    }*/

    void Teleport()
    {
        // choose a random location within a certain radius and teleport there
        float radius = 10f;
        Vector3 newPosition = transform.position + new Vector3(Random.Range(-radius, radius), 0f, 0f);
        transform.position = newPosition;
    }
}
