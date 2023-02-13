using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingblock : MonoBehaviour
{
    float time;
    Vector3 pos;
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
        if(other.gameObject.CompareTag("Player"))
        {
            time+=Time.deltaTime;
            if(time>totaltime)
            {
                pos=transform.GetChild(0).transform.position;
                GetComponent<BoxCollider2D>().enabled=false;
                transform.GetChild(0).transform.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
                StartCoroutine(wait());
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        time=0f;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        transform.GetChild(0).transform.position=pos;
        GetComponent<BoxCollider2D>().enabled=true;
        transform.GetChild(0).transform.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Static;
        time=0f;
    }
}
