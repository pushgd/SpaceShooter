using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    int damage = 5;
    [SerializeField]
    float speed = 10;
    [SerializeField]
    float lifespan = 5;
    [SerializeField]
    AudioClip collisionSound;

    [SerializeField]
    int HP=1;

    AudioSource audioSource;
    
    void Start()
    {
        Destroy(this.gameObject, lifespan);
        audioSource = GetComponent<AudioSource>();
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0) * speed * Time.deltaTime;
        if(HP <=0)
        {
            Destroy(this.gameObject,1);
        }
       
    }

    public int getDamage()
    {
        return damage;
    }
    public int getHP()
    {
        return HP;
    }

    public void reduceHPby(int x)
    {
        HP = HP - x;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Bullet: Collision");

       

        Destroy(GetComponent<BoxCollider2D>());
        Destroy(GetComponent<SpriteRenderer>());
    }
}
