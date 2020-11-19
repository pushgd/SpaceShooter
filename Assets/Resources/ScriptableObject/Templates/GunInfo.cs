using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Gun", order = 1)]
public class GunInfo : Info
{
    public float fireRate = 1;

    public BulletInfo bulletInfo;
}
