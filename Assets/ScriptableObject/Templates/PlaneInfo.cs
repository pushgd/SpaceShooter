using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Plane", order = 1)]
public class PlaneInfo : ScriptableObject
{
    public float HP = 25;
    public float SP = 25;

    public float shieldRechargeDelay = 1;

    public float shieldRechargeRate = 0.5f;

    public EngineInfo engine;

    public GunInfo gun;

    public GunInfo altGun;

    public float range = 100;


}
