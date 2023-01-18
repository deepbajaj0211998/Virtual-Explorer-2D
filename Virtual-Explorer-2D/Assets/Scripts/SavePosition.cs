using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{

    Vector3 CordsStored;
    float X;
    float Y;
    float Z;
    public Transform PlayerLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
            X = PlayerLocation.position.x;

            Z = PlayerLocation.position.z;

            Y = PlayerLocation.position.y;


            PlayerPrefs.GetFloat("Player_Z_Cord", (float)Z);

            PlayerPrefs.GetFloat("Player_X_Cord", (float)X);

            PlayerPrefs.GetFloat("Player_Y_Cord", (float)Y);

            CordsStored.z = PlayerPrefs.GetFloat("Player_Z_Cord");

            CordsStored.x = PlayerPrefs.GetFloat("Player_X_Cord");

            CordsStored.y = PlayerPrefs.GetFloat("Player_Y_Cord");
            PlayerPrefs.Save();
            Debug.Log(X + " " + Z + " " + Y);
        }
	}

}
