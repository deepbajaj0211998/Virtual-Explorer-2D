using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
			PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
			PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);
		}
	}

}
