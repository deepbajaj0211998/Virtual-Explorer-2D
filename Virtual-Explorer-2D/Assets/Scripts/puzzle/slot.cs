using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class slot : MonoBehaviour
{
    // Start is called before the first frame update
    public int status=0;
    GameObject imgs;
    public GameObject dropbutton;
    public GameObject replacebutton;
    public GameObject puzzlemanager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enetered");
            imgs=collision.gameObject;
            if(status==0 && imgs.GetComponent<advance_character_controller>().img_dragged==1)
            {
                dropbutton.gameObject.SetActive(true);
                dropbutton.GetComponent<drop>().slot=transform.gameObject;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if(status==1 && imgs.GetComponent<advance_character_controller>().img_dragged==1)
            {
                replacebutton.gameObject.SetActive(true);
                replacebutton.GetComponent<replace>().slot=transform.gameObject;
                transform.GetChild(0).gameObject.SetActive(true);
            }
            
        }
        
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {
            dropbutton.gameObject.SetActive(false);
            replacebutton.gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }
    
    public void fill()
    {
        if(imgs.CompareTag("Player"))
        {
            
            if(status==0 && imgs.GetComponent<advance_character_controller>().img_dragged==1)
            {
                status=1;
                imgs.GetComponent<advance_character_controller>().img_dragged=0;
                GetComponent<SpriteRenderer>().sprite=imgs.GetComponent<advance_character_controller>().img.transform.GetComponent<SpriteRenderer>().sprite;
                imgs.GetComponent<advance_character_controller>().img.gameObject.SetActive(false);
            }
            
        }
        puzzlemanager.GetComponent<puzzle_manager>().check();
        dropbutton.SetActive(false);
    }
    public void replace()
    {
        if(imgs.CompareTag("Player"))
        {
            
            if(status==1 && imgs.GetComponent<advance_character_controller>().img_dragged==1)
            {
                status=1;
                Sprite s=GetComponent<SpriteRenderer>().sprite;
                GetComponent<SpriteRenderer>().sprite=imgs.GetComponent<advance_character_controller>().img.transform.GetComponent<SpriteRenderer>().sprite;
                imgs.GetComponent<advance_character_controller>().img.transform.GetComponent<SpriteRenderer>().sprite=s;
            }
            
        }
        puzzlemanager.GetComponent<puzzle_manager>().check();
        replacebutton.SetActive(false);
    }
}
