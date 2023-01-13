using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public GameObject loose;
    public GameObject timer;
    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            loose.gameObject.SetActive(true);
            other.transform.gameObject.SetActive(false);
            timer.transform.GetComponent<timetrail>().win();
        }
    }

public void restart()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

}
}