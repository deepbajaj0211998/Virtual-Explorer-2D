using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSea : MonoBehaviour
{

    public int damageAmount = 10;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			collision.GetComponent<advance_character_controller>().TakeDamage(damageAmount);
			if(collision.GetComponent<advance_character_controller>().health == 0)
			{
				Destroy(collision.gameObject);
			}
		}
	}

}
