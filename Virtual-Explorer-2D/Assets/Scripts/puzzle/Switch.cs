using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool up=false;
    public Vector3 pos;
    void Start()
    {
        pos=transform.position;
    }
    public void Update()
    {
        if(up==true)
        {
            transform.position=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        
    }
    public void down()
    {
        up=false;
        transform.position=pos;
    }
    public void upp()
    {
        up=true;
    }
}