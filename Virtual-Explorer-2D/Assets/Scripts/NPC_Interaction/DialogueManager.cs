using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Queue<string> sentences;
    public Animator animator;
    public GameObject npc;
    public GameObject itemPrefab;
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
	{
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
		}

        DisplayNextSentence();
	}

    public void DisplayNextSentence()
	{
        if(sentences.Count == 0)
		{
            EndDialogue();
            return;
		}
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}

    IEnumerator TypeSentence(string sentence)
	{
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
		{
            dialogueText.text += letter;
            yield return null;
		}
	}

    void EndDialogue()
	{
        animator.SetBool("IsOpen", false);
        npc.gameObject.SetActive(false);
        
		if (!npc.activeInHierarchy)
		{
            player.GetComponent<advance_character_controller>().enabled = true;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            itemPrefab.SetActive(true);
        }
    }

}
