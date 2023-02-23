using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateKeys : MonoBehaviour
{

    public GameObject prefabRightKey;
    public GameObject prefabWrongKey;
    public bool isRight = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position1 = new Vector3(-41.32f, -0.02f, 0f);
        Instantiate(prefabRightKey, position1, Quaternion.identity);

        Vector3 position2 = new Vector3(-37.9f, -1.4f, 0f);
        Instantiate(prefabWrongKey, position2, Quaternion.identity);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject == prefabRightKey)
		{
            Destroy(collision.gameObject);
            isRight = true;
		}
        else if(collision.gameObject == prefabWrongKey)
		{
            Destroy(collision.gameObject);
            isRight = false;
        }
	}

}
