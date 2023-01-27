using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class parallaxbg : MonoBehaviour
{
    private float length,startpos;
    public GameObject cam;
    public float parallax_amount;
    // Start is called before the first frame update
    void Start()
    {
        startpos=transform.localPosition.x;
        length=GetComponent<Image>().rectTransform.sizeDelta.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp=(cam.transform.position.x*(1-parallax_amount));
        float dist=(cam.transform.position.x*parallax_amount);
        transform.localPosition=new Vector3(-(startpos+dist),transform.localPosition.y,transform.localPosition.z);
        if(temp>startpos+length)startpos+=length;
        else if(temp<startpos-length)startpos-=length;
    }
}
