using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replace : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startreplace()
    {
        slot.GetComponent<slot>().replace();
    }
}
