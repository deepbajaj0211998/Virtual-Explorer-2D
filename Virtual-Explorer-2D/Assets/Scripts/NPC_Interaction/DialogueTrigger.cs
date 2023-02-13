using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public Dialogue dialogue;
	public DialogueManager manager;
	public float speed = 1.0f; // The speed of the NPC's movement
	public Transform triggerPosition; // The position at which the NPC should start moving towards the player

	private Transform playerTransform; // The player's transform
	private bool isTriggered = false; // Whether the trigger has been activated
	public bool isCollected = false;
	private Animator animator; // The NPC's animator component
	bool isActive = false;

	private void Start()
	{
		playerTransform = GameObject.FindWithTag("Player").transform;
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (!isTriggered && Vector2.Distance(playerTransform.position, triggerPosition.position) < 0.5f)
		{
			isTriggered = true;
		}

		// If the trigger has been activated
		if (isTriggered)
		{
			// Calculate the distance to the player
			float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);

			// If the distance is less than 1, the NPC has reached the player
			if (distanceToPlayer < 1)
			{
				speed = 0f;
				animator.SetBool("IsWalking", false);
			}
			else
			{
				// Set the walking animation
				animator.SetBool("IsWalking", true);

				// Move the NPC towards the player
				transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
			}
		}
		else
		{
			// Set the idle animation
			animator.SetBool("IsWalking", false);
		}
	}

	/*public void NPC()
	{
		StartCoroutine("WaitForSecond");
	}

	IEnumerator WaitForSecond()
	{
		Debug.Log("WaitForSeconds");
		yield return new WaitForSeconds(3f);
		gameObject.SetActive(false);
	}*/

	private void OnTriggerEnter2D(Collider2D collision)
	{
	    if (collision.CompareTag("Player"))
	    {
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);	
			isActive = true;
		}
	}

}
