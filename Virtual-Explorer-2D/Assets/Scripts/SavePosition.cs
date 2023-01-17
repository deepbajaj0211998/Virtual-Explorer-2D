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


            PlayerPrefs.SetInt("Player_Z_Cord", (int)Z);

            PlayerPrefs.SetInt("Player_X_Cord", (int)X);

            PlayerPrefs.SetInt("Player_Y_Cord", (int)Y);

            CordsStored.z = PlayerPrefs.GetInt("Player_Z_Cord");

            CordsStored.x = PlayerPrefs.GetInt("Player_X_Cord");

            CordsStored.y = PlayerPrefs.GetInt("Player_Y_Cord");
            PlayerPrefs.Save();
            Debug.Log(X + " " + Z + " " + Y);
        }
	}

}
