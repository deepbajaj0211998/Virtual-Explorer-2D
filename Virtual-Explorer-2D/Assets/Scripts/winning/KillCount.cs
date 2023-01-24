using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCount : MonoBehaviour
{

    public TextMeshProUGUI killCount;

    // Update is called once per frame
    void Update()
    {
        killCount.text = PlayerPrefs.GetInt("KillCount").ToString();
    }
}
