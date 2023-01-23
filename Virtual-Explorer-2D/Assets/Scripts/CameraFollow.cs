using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector2 posOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime); 
    }
}
