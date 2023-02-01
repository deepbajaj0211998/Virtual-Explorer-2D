using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_enemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kill"))
            transform.parent.transform.GetComponent<enemy1>().TakeDamage(100);
        
    }
}
