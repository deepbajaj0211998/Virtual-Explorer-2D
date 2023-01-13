using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class timetrail : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public float totaltime=60f;
    float time;
    public float timeleft;
    bool gameover=false;
    // Start is called before the first frame update
    void Start()
    {
        reStart();
    }
    public void reStart()
    {
        time=0;
        gameover=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameover==false)
        {
            time+=Time.deltaTime;
            timeleft=totaltime-time;
            int min =Mathf.FloorToInt(timeleft/60);
            int sec =Mathf.FloorToInt(timeleft-min*60);
            timeText.text=string.Format("{0:0}:{1:00}",min,sec);
            if(timeleft==0)
            {
                gameover=true;
                Debug.Log("you loose");
            }
        }
    }

    public void win()
    {
        gameover=true;

    }
    
}
