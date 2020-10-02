using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelctionMenu : MonoBehaviour,UIEventListener
{
    [SerializeField]
    PlaneInfo playerInfo;
    // Start is called before the first frame update
    string mainGun = "mainGun", altGun = "altGun", engine="engine";
    
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
        if(transform.name == mainGun)
        {
            //playerInfo.gun.bullet = (string)arguments[1];
            print("Main gun changed "+arguments[1]);
        }
        if(transform.name == altGun)
        {
            //playerInfo.altGun.bullet = (string)arguments[1];
            print("Altgun changed");
        }
        if(transform.name == engine)
        {
            print("Engine Changed");
        }
        
    }
}
