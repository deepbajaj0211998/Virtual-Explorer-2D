using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FireBall : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject fireballPrefab;
    float throwRate;
    float nextThrowTime;

    // Start is called before the first frame update
    void Start()
    {
        throwRate = 2f;
        nextThrowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
	{
        if (Time.time > nextThrowTime && player != null && Vector2.Distance(transform.position, player.transform.position) < 10f)
        {
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            nextThrowTime = Time.time + throwRate;
        }
    }

}
