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
    public TextMeshProUGUI warningText;
    public GameObject[] newGameObjects;

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
            Coin.totalCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
            SceneManager.LoadScene("level1");
        }
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