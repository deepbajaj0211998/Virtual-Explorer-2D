using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzle : MonoBehaviour
{
    public Sprite[] images; // Array of images to use in the puzzle
    public Button startButton; // Button to start the game
    public Button resetButton; // Button to reset the game
    public GameObject messageText; // Text to display game messages

    private int currentIndex; // Index of the current image being moved


    public Image[] slots;
    private List<Sprite> shuffledImages;

    // ... other code ...

    private void Start()
    {
        //slots = GetComponentsInChildren<SpriteRenderer>(); // Change this line

        // Set up the slots with the images
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].sprite = images[i];
        }

        // Shuffle the images
        shuffledImages = new List<Sprite>(images);
        Shuffle(shuffledImages);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has clicked on an image
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to find the image that was clicked on
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                // Get the index of the clicked image
                Image image = hit.collider.GetComponent<Image>();
                int index = System.Array.IndexOf(slots, image);
                if(index==-1)
                    index=0;
                Debug.Log(index);
                if (index >= 0 && index != currentIndex)
                {
                    // Swap the clicked image with the current image
                    Sprite temp = shuffledImages[index];
                    shuffledImages[index] = shuffledImages[currentIndex];
                    shuffledImages[currentIndex] = temp;

                    // Assign the shuffled images to the slots
                    for (int i = 0; i < slots.Length; i++)
                    {
                        slots[i].sprite = shuffledImages[i];
                    }

                    // Check if the puzzle is solved
                    if (CheckPuzzle())
                    {
                        messageText.gameObject.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }

                // Update the current index
                currentIndex = index;
            }
        }
    }

    // Shuffle the list of sprites
    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    // Check if the puzzle is solved
    bool CheckPuzzle()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].sprite != images[i])
            {
                return false;
            }
        }
        return true;
    }

    // Start the game
    public void StartGame()
    {
        // Shuffle the images
        shuffledImages = new List<Sprite>(images);
        Shuffle(shuffledImages);

        // Assign the shuffled images to the slots
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].sprite = shuffledImages[i];
        }

        // Enable the reset button and message text
        resetButton.interactable = true;
        
    }
    public void ResetGame()
{
    // Shuffle the images
    shuffledImages = new List<Sprite>(images);
    Shuffle(shuffledImages);

    // Assign the shuffled images to the slots
    for (int i = 0; i < slots.Length; i++)
    {
        slots[i].sprite = shuffledImages[i];
    }

    // Reset the game state
    currentIndex = 0;
    resetButton.interactable = false;
}
}