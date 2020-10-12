using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Bullet", order = 1)]
public class BulletInfo : Info
{
 
    public string bullet = "bullet";
    public float speed;
    public float damage;
    public float lifespan = 5;
    public int HP = 1;
   

}
