using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike2 : MonoBehaviour
{
    public float spikesMovementUp;
    public float up_time=1f;
    public float spikesPositionDown;
    private bool isSpikeUp;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(SpikesUp));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
    }
    IEnumerator SpikesUp()
    {
        yield return new WaitForSeconds(up_time);
        if (!isSpikeUp)
        {
            isSpikeUp=true;
            transform.GetChild(0).transform.localPosition = new Vector3(0, spikesMovementUp, 0);
            StartCoroutine(nameof(SpikesUp));
        }
        else
        {
            isSpikeUp=false;
            transform.GetChild(0).transform.localPosition = new Vector3(0, spikesPositionDown, 0);
            StartCoroutine(nameof(SpikesUp));
        }
    }
}
