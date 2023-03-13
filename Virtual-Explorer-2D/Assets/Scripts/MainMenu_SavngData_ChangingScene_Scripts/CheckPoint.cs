using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("CheckPoint"))
		{
			PlayerPrefs.SetFloat("PlayerPosX", collision.transform.position.x);
			PlayerPrefs.SetFloat("PlayerPosY", collision.transform.position.y);
			PlayerPrefs.SetFloat("PlayerPosZ", collision.transform.position.z);
		}
	}

}
