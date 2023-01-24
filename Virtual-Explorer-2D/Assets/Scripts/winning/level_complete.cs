using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_complete : MonoBehaviour
{
    public GameObject win_canvas;
    public Dialogue dialogue;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(collision.transform.GetComponent<PrototypeHeroDemo>().can_win==true)
            {
                win_canvas.SetActive(true);
                collision.gameObject.SetActive(false);
            }
            else
            {
                
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                
            }
        }
    }
}
