using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    int HP=1;
    [SerializeField]
    BulletInfo info;
    
    void Start()
    {
        HP = info.HP;
        Destroy(this.gameObject, info.lifespan);
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0) * info.speed * Time.deltaTime;
        if(HP <=0)
        {
            
            Destroy(this.gameObject);
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<SpriteRenderer>());
        }
       
    }

    public float getDamage()
    {
        return info.damage;
    }
    public int getHP()
    {
        return HP;
    }

    public void reduceHPby(int x)
    {
       
        HP = HP - x;
     
    }


     void OnTriggerEnter2D(Collider2D collision)
    {

        
    }


    public BulletInfo getBulletInfo()
    {
        return info;

    }
}
