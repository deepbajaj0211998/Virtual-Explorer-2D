using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class img : MonoBehaviour
{
    public bool drag =false;
    private GameObject player;
    public GameObject dragbutton;
    Vector2 pos;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.GetComponent<advance_character_controller>().img_dragged!=1)
            {
                player=collision.gameObject;
                dragbutton.SetActive(true);
                collision.GetComponent<advance_character_controller>().img=transform.gameObject;
                dragbutton.GetComponent<drag>().img=transform.gameObject;
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        dragbutton.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        
    }
    public void startdrag()
    {
        player.GetComponent<advance_character_controller>().img_dragged=1;
        drag=true;
    }
    void Start()
    {
        
        pos=transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(drag==true)
        {
            transform.position = player.transform.position+ new Vector3(-1f,1f,0f);
        }
    }
    
}
