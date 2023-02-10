using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill2 : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("kill"))
            transform.parent.transform.GetComponent<enemy_level_2>().TakeDamage(100);
            

        
    }

}
