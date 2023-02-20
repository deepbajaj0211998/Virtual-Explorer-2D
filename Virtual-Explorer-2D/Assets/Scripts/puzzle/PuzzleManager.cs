using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }

    public GameObject door; // assign door game object in inspector
    public int[] switchOrder; // set switch order in inspector

    private int currentIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckSwitch(int switchID)
    {
        if (switchID == switchOrder[currentIndex])
        {
            currentIndex++;
        }
        else
        {
            currentIndex = 0;
            Debug.Log("Wrong order!"); // display message to player
        }

        if (currentIndex == switchOrder.Length)
        {
            door.SetActive(true); // unlock door
            Debug.Log("Door unlocked!"); // display message to player
            currentIndex = 0;
        }
    }
}
