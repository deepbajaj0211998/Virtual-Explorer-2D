using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavetrigger : MonoBehaviour
{
    [SerializeField]puzzle_manager puzzle_Manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            puzzle_Manager.strt=true;
            
        }
    }
}
