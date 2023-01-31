using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Keep track of total picked coins (Since the value is static, it can be accessed at "SC_2DCoin.totalCoins" from any script)
    public int totalCoins = 0;
    public GameObject CoinBurstPrefab;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        int getCoins;
        
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add coin to counter
            totalCoins++;
            //Test: Print total number of coins
            Debug.Log("You currently have " + totalCoins + " Coins.");
            if (CoinBurstPrefab != null)
            {
                Instantiate(CoinBurstPrefab, transform.position, Quaternion.identity);
            }
            //Destroy coin
            Destroy(gameObject);
            getCoins = PlayerPrefs.GetInt("NumberOfCoins");
            PlayerPrefs.SetInt("NumberOfCoins", getCoins + 1);
        }
    }
}
