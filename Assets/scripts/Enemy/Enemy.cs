using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int HP = 10;

    [SerializeField]
    ParticleSystem explosion;

    private ParticleSystem p;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToLower().Contains("Playerbullet".ToLower()))
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            if (b.getHP() > 0)
            {
                b.reduceHPby(1);
                int damage = b.getDamage();
                print(" Enemy Collided " + collision.gameObject.tag + " " + damage);
                HP -= damage;
                if (HP <= 0)
                {
                   
                    Destroy(gameObject.GetComponent<FaceObject>());
                    Destroy(gameObject.GetComponent<BoxCollider2D>());

                    Destroy(this.gameObject);
                    Instantiate(explosion, transform.position, transform.rotation);

                }
            }
            else
            {
                print("Bullet HP is zero");
            }
        }


    }
    
}
