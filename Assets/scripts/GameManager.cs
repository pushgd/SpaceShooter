using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text killCount;

    [SerializeField]
    Text timer;

    [SerializeField]
    Text questText;


    public static GameManager gameManager;
    [SerializeField]
    LevelInfo levelInfo;

    private int currentKillCount=0;
    [SerializeField]
    Color textColor;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this;
        timer.GetComponent<TimeCounter>().setTime(levelInfo.minutes, levelInfo.seconds);
        timer.GetComponent<TimeCounter>().setCountDown(levelInfo.countDown);
        questText.text = levelInfo.levelStartText;
        
        questText.color = textColor;
    }

    // Update is called once per frame
    void Update()
    {
        
        textColor.a -= 1/(60*5f);
        questText.color = textColor;
    }

    public void onEnemyKill()
    {
        currentKillCount++;
        killCount.text = ""+currentKillCount;

        if(currentKillCount>levelInfo.killCount)
        {
            print("Level Done Kill count Achived");
        }
               
    }

    public void onTimerEnd()
    {
        print("Level Done Time Over");
    }


}
