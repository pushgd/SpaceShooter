using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelctionMenu : MonoBehaviour, UIEventListener
{
    [SerializeField]
    PlaneInfo playerInfo;
    // Start is called before the first frame update
    string mainGun = "mainGun", altGun = "altGun", engine = "engine",levelSelect= "levelSelector";
    int selectedLevel = 1;
    TextMesh gunInfoText,planeInfoText, altGunInfoText;


    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            try
            {
                transform.GetChild(i).GetComponent<UIElement>().setUIListner(this);
            }
            catch (System.Exception)
            {
                print(transform.GetChild(i) + " not UI Element");
            }
        }
        PlayerPrefs.DeleteAll();
        


        playerInfo = Storage.setPlayerData();
        print(playerInfo.SP);
        //playerInfo = Storage.getPlaneInfo("PlayerPlane");



        print("**********"+ playerInfo.text);
        GunInfo g = Storage.getGunInfo("P_Gun2");
        print("**********" + g.text);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onUIEvent(int eventID, Transform transform, object[] arguments)
    {
        if (transform.name == mainGun && (eventID == Constant.INDEX_DECREASED|| eventID == Constant.INDEX_INCREASED))
        {
            print("Main gun changed " + arguments[1]+" "+eventID);
            print(playerInfo);
            playerInfo.gun = (GunInfo)arguments[1];
            PlayerPrefs.SetString(Storage.GUN_INFO, JsonUtility.ToJson(playerInfo.gun));
        }
        else if (transform.name == altGun)
        {
            
            print("Altgun changed");
            playerInfo.altGun = (GunInfo)arguments[1];
            PlayerPrefs.SetString(Storage.ALTGUN_INFO, JsonUtility.ToJson(playerInfo.altGun));

        }
        else if (transform.name == engine)
        {
            
            print("Engine Changed");
            playerInfo.engine = (EngineInfo)arguments[1];
            PlayerPrefs.SetString(Storage.ENGINE_INFO, JsonUtility.ToJson(playerInfo.engine));

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
                PlayerPrefs.Save();
                SceneManager.LoadScene(selectedLevel);
            }
        }

    }
}
