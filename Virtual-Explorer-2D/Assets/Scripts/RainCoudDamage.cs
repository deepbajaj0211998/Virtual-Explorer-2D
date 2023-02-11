using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCoudDamage : MonoBehaviour
{

    public GameObject rainDrops;
    public float minRange;
    public float maxRange;
    public float rainSpeed;

    void Start()
    {
        InvokeRepeating(nameof(AcidRainMinRange), 1f, rainSpeed);
        InvokeRepeating(nameof(AcidRainMaxRange), 1f, rainSpeed);
    }

    public void AcidRainMaxRange()
    {
        Instantiate(rainDrops, new Vector3(gameObject.transform.position.x + Random.Range(minRange, maxRange), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }
    
    public void AcidRainMinRange()
    {
        Instantiate(rainDrops, new Vector3(gameObject.transform.position.x - Random.Range(minRange, maxRange), gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
    }

}
