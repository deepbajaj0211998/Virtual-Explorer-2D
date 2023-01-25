using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{

    public PowerUpEffect powerUpEffect;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(gameObject);
			powerUpEffect.Apply(collision.gameObject);
		}
	}

}
