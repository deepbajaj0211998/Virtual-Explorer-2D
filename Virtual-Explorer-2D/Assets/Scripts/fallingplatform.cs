using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingplatform : MonoBehaviour
{
    float time;
    public float totaltime=1;//total time for how much second a player can stand on it
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        time+=Time.deltaTime;
        if(time>totaltime)
        {
            GetComponent<CapsuleCollider2D>().enabled=false;
            transform.GetChild(0).transform.gameObject.SetActive(false);
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        GetComponent<CapsuleCollider2D>().enabled=true;
        yield return new WaitForSeconds(2);
        transform.GetChild(0).transform.gameObject.SetActive(true);
        time=0f;
    }
}
