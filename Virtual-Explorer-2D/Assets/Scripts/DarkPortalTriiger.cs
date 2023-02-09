using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkPortalTriiger : MonoBehaviour
{

    public GameObject darkPortal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            darkPortal.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            darkPortal.SetActive(false);
        }
    }

}
