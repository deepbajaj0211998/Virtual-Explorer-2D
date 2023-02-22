using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{

    public Rigidbody2D[] rigidbody2D;
    public bool canFall = false;
    public float timeForFalling;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Check), 1, 1f);
        for (int i = 0; i < rigidbody2D.Length; i++)
        {
            rigidbody2D[i].gravityScale = 0;
        }
    }

    private void Check()
    {
        if (canFall)
        {
            StartCoroutine(nameof(FallPlatform));
            canFall = false;
        }
    }

    IEnumerator FallPlatform()
    {
        for(int i = 0; i < rigidbody2D.Length; i++)
        {
            rigidbody2D[i].gravityScale = 1;
            yield return new WaitForSeconds(timeForFalling);
        }

        yield return new WaitForSeconds(4f);

        for (int i = 0; i < rigidbody2D.Length; i++)
        {
            Destroy(rigidbody2D[i].gameObject);
            yield return new WaitForSeconds(timeForFalling);
        }
    }

}
