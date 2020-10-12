using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    float minutes;
    [SerializeField]
    float seconds;

    string s;
    string m;
    // Start is called before the first frame update
    Text text;
    bool countDown;
    void Start()
    {
        //if (seconds < 0)
        //{
        //    countDown = false;
        //    seconds = 0;
        //}
        
        
            //countDown = true;
            //seconds++;
        
        

        text = GetComponent<Text>();



    }

    // Update is called once per frame
    void Update()
    {
      

        if (countDown)
        {
            decreaseTime();
            if ((int)seconds <= 0 && (int)minutes <= 0)
            {
                seconds = 0.1f;
                minutes = 0;
                GameManager.gameManager.onTimerEnd();
                
            }
        }
        else
        {
            increaseTime();
        }
        updateText();
        
    }

    private void decreaseTime()
    {
        seconds -= Time.deltaTime;

        if (seconds <= 0)
        {
            minutes--;
            seconds = 60;
        }
    }

    private void updateText()
    {
        if (seconds < 10)
        {
            s = "0" + (int)seconds;
        }
        else
        {
            s = (int)seconds + "";
        }
        if (minutes < 10)
        {
            m = "0" + (int)minutes;
        }
        else
        {
            m = "" + (int)minutes;
        }
        text.text = m + ":" + s;
    }

    private void increaseTime()
    {
        seconds += Time.deltaTime;
        if (seconds > 60)
        {
            seconds = 0;
            minutes++;
        }


    }

    public void setTime(int min , int sec)
    {
        minutes = min;
        seconds = sec;

    }
    public void setCountDown(bool flag)
    {
        countDown = flag;
    }

    public void add(int min, int sec)
    {
        seconds += sec;
        float x = seconds ;
        seconds = seconds % 60;
        minutes += (int)(x / 60);

        minutes += min;
    }

  
}
