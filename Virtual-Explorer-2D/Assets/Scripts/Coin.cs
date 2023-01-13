using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Keep track of total picked coins (Since the value is static, it can be accessed at "totalCoins" from any script)
    public static int totalCoins = 0;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (other.CompareTag("Player"))
        {
            //Add coin to counter
            totalCoins++;
            //Save the Number of Coins Collected By the player using PlayerPrefs
            PlayerPrefs.SetInt("NumberOfCoins", totalCoins);
            //Test: Print total number of coins
            Debug.Log("You currently have " + totalCoins + " Coins.");
            //Destroy coin
            Destroy(gameObject);
        }
    }
}
