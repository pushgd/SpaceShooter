using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int HP = 10;

    [SerializeField]
    ParticleSystem explosion;

    [SerializeField]
    AudioClip explosionSound;

    AudioSource audioSource;
    private ParticleSystem p;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToLower().Contains("Playerbullet".ToLower()))
        {

            int damage = collision.gameObject.GetComponent<Bullet>().getDamage();
            print(" Enemy Collided " + collision.gameObject.tag + " " + damage);
            HP -= damage;
            if (HP <= 0)
            {
                print("Zero HP");
                p = Instantiate(explosion, transform.position, transform.rotation);

                Destroy(gameObject.GetComponent<FaceObject>());

                Destroy(this.gameObject, 1);

            }

        }


    }
    private void OnDestroy()
    {
        p = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(p.gameObject, 1);
        audioSource.PlayOneShot(explosionSound);
    }
}
