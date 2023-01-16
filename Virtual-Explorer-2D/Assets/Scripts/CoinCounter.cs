using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    TextMeshProUGUI counterText;

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //Set the current number of coins to display
        if (counterText.text != Coin.totalCoins.ToString())
        {
            counterText.text = "x" + Coin.totalCoins.ToString();
        }
    }
}
