using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    PlaneInfo planeInfo;

    float HP;

    [SerializeField]
    float SP = 10;

    [SerializeField]
    ParticleSystem explosion;

    private ParticleSystem p;
    Shield s;

    [SerializeField]
    Image hpFill;

    void Start()
    {
        HP = planeInfo.HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpFill != null)
        {
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToLower().Contains("Playerbullet".ToLower()))
        {
            Bullet b = collision.gameObject.GetComponent<Bullet>();
            if (b.getHP() > 0)
            {
                b.reduceHPby(1);
                if (HP > 0)
                {
                    takeDamage(collision, b);
                }
            }

        }


    }

    private void takeDamage(Collider2D collision, Bullet b)
    {
        float damage = b.getDamage();

       
        HP -= damage;
        if (HP <= 0)
        {

            Destroy(gameObject.GetComponent<FaceObject>());
            Destroy(gameObject.GetComponent<BoxCollider2D>());

            Destroy(this.gameObject);
            ParticleSystem g = Instantiate(explosion, transform.position, transform.rotation);
            g.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            GameManager.gameManager.onEnemyKill();


        }
    }

    public float getHP()
    {
        return HP;
    }

    public float getMaxHP()
    {
        return planeInfo.HP;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, planeInfo.range);


    }

}
