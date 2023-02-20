using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class puzzle_manager : MonoBehaviour
{
    float time;
    float timeleft;
    [SerializeField]float totaltime;
    public TextMeshProUGUI timeText;
    public bool strt=false;
    [SerializeField] Sprite[]  original_pattern;
    [SerializeField]GameObject goblin;
    [SerializeField]GameObject dor;
    [SerializeField]GameObject key;
    public bool issolved=false;
    public GameObject puzzle_images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(strt==true)
        {
            time+=Time.deltaTime;
            timeleft=totaltime-time;
            int min =Mathf.FloorToInt(timeleft/60);
            int sec =Mathf.FloorToInt(timeleft-min*60);
            timeText.text=string.Format("{0:0}:{1:00}",min,sec);
            if(timeleft<1)
            {
                if(issolved==false)
                {
                    goblin.GetComponent<enemy2>().enabled=true;
                    dor.SetActive(true);
                }

                strt=false;
            }
        }
    }
    public void check()
    {
        int x=0;
        for(int i=0;i<5;i++)
        {
            if(original_pattern[i]==puzzle_images.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite)
                x+=1;

        }
        if(x==5)
        {
            issolved=true;
            key.GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
        }
    }
}
