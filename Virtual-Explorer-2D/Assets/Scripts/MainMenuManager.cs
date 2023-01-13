using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject DifficultyPanel;
    public GameObject OptionsPanel;

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
	}

}
