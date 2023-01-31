using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingEffect : MonoBehaviour
{

    public Color startColor = Color.gray;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float speed = 1;

    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
    }
}
