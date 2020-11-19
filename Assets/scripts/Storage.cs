using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Storage
{
    public static string PLANE_INFO = "planeInfo";
    public static string PLAYER_PLANE = "PlayerPlane";
    public static string GUN_INFO = "gunInfo";
    public static string ALTGUN_INFO = "altgunInfo";
    public static string ENGINE_INFO = "engineInfo";
    public static string ITEM_DATA = "shopstring";
    public static string HP = "HP";
    public static string SP = "SP";



    public static int getItemValue(String name)
    {
        int level = PlayerPrefs.GetInt(name + "_LEVEL", 0);
        return getShopInfo(name).values[level];
    }

    public static PlaneInfo setPlayerData()
    {
        PlaneInfo p = getPlaneInfo(PLAYER_PLANE);
        p.gun = getGunInfo(PlayerPrefs.GetString(GUN_INFO, "P_Gun"));
        
        
        p.altGun = getGunInfo(PlayerPrefs.GetString(ALTGUN_INFO, "P_Gun"));
        p.engine = getEngineInfo(PlayerPrefs.GetString(ENGINE_INFO, "Engine"));
        p.HP = getItemValue(HP);
        p.SP = getItemValue(SP);
        return p;
    }

    public static PlaneInfo getPlaneInfo(String plane)
    {
        return Resources.Load<PlaneInfo>("ScriptableObject\\Plane\\" + plane);
    }

    public static EngineInfo getEngineInfo(String engine)
    {
        return Resources.Load<EngineInfo>("ScriptableObject\\Engine\\" + engine);
    }

    public static GunInfo getGunInfo(String gun)
    {
        return Resources.Load<GunInfo>("ScriptableObject\\Gun\\" + gun);
    }


    public static GunInfo getBulletInfo(String bullet)
    {
        return Resources.Load<GunInfo>("ScriptableObject\\Bullet\\" + bullet);
    }

    public static ShopItem getShopInfo(String name)
    {
        return Resources.Load<ShopItem>("ScriptableObject\\ShopItem\\" + name);
    }



}
