using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject DifficultyPanel;
    public GameObject OptionsPanel;
    public GameObject QuitPanel;
    public TextMeshProUGUI warningText;
    public GameObject[] newGameObjects;
    public GameObject player;
    public Vector3 SavedPos;
    public PlayerController playerController;

    public void OnClick_NewGame()
	{
        DifficultyPanel.SetActive(true);
	}
    public void OnClick_Options()
	{
        OptionsPanel.SetActive(true);

    }
    public void OnClick_Back()
	{
        OptionsPanel.SetActive(false);
        Debug.Log("The game has been closed by the user.");
    }
    
    public void OnClick_Ouit()
	{
        Application.Quit();
        Debug.Log("The game has been closed by the user.");
	}

    public void LoadScene()
	{
        SceneManager.LoadScene("level1");
        PlayerPrefs.DeleteAll();
    }

    public void OnClick_Continue()
    {
        if (PlayerPrefs.GetInt("NumberOfCoins") == 0)
        {
            warningText.text = "There is not any save data at the time. Please start playing by pressing the New Game button!!!";
            StartCoroutine(WaitForSeonds2());
        }
        else
        {
            //int totalCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
            playerController.isLoadedFromSaved = true;
            SavedPos = new Vector3(PlayerPrefs.GetFloat("PlayerPosX"), PlayerPrefs.GetFloat("PlayerPosY"), player.transform.position.z);
            SceneManager.LoadScene("level1");
        }
    }

    public void QuitGame()
    {
        QuitPanel.SetActive(true);
    }
    
    public void noExitGame()
    {
        QuitPanel.SetActive(false);
    }

    IEnumerator WaitForSeonds2()
    {
        newGameObjects[0].gameObject.GetComponent<Button>().enabled = false;
        newGameObjects[1].gameObject.GetComponent<Button>().enabled = false;
        newGameObjects[2].gameObject.GetComponent<Button>().enabled = false;
        newGameObjects[3].gameObject.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(4);
        warningText.gameObject.SetActive(false);
        StopAllCoroutines();
        newGameObjects[0].gameObject.GetComponent<Button>().enabled = true;
        newGameObjects[1].gameObject.GetComponent<Button>().enabled = true;
        newGameObjects[2].gameObject.GetComponent<Button>().enabled = true;
        newGameObjects[3].gameObject.GetComponent<Button>().enabled = true;
    }

}
