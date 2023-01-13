using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("CheckPoint"))
		{
			PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
			PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
		}
	}

}
