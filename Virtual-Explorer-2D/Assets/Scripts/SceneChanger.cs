using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject win;
    public GameObject timer;
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "WinCanvas")
            {
                win.SetActive(true);
                other.gameObject.SetActive(false);
            }
            else
            {
                other.transform.GetComponent<PlayerController>().kill();
            }
        }

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}