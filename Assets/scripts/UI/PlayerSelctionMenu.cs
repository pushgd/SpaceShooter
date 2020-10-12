using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelctionMenu : MonoBehaviour, UIEventListener
{
    [SerializeField]
    PlaneInfo playerInfo;
    // Start is called before the first frame update
    string mainGun = "mainGun", altGun = "altGun", engine = "engine",levelSelect= "levelSelector";
    int selectedLevel = 1;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<UIElement>().setUIListner(this);
        }



    }

    // Update is called once per frame
    void Update()
    {

    }



    public void onUIEvent(int eventID, Transform transform, object[] arguments)
    {
        if (transform.name == mainGun)
        {
            //playerInfo.gun.bullet = (string)arguments[1];
            print("Main gun changed " + arguments[1]);
            playerInfo.gun = (GunInfo)arguments[1];

        }
        else if (transform.name == altGun)
        {
            //playerInfo.altGun.bullet = (string)arguments[1];
            print("Altgun changed");
            playerInfo.altGun = (GunInfo)arguments[1];
        }
        else if (transform.name == engine)
        {
            print("Engine Changed");
            playerInfo.engine = (EngineInfo)arguments[1];
        }
        else if (transform.name == levelSelect)
        {
            print("level Changed");
            selectedLevel = ((LevelInfo)arguments[1]).sceneIndex;
        }
        else if (transform.name == "start")
        {
            if (eventID == Constant.MOUSE_EVENT_UP)
            {
                SceneManager.LoadScene(selectedLevel);
            }
        }

    }
}
