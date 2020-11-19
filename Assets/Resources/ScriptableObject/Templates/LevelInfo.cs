using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Level", order = 1)]
public class LevelInfo : Info
{
    public  enum LevelType
    {
        defend,
        attack
    }
    public int sceneIndex;

    public LevelType type;

    public int minutes;
    public int seconds;

    public int killCount = int.MaxValue;

    public bool countDown;

    public string levelStartText;
}
