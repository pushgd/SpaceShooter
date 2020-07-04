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
       
    }

    public int getDamage()
    {
        return damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Bullet: Collision");

        audioSource.PlayOneShot(collisionSound);
        //Destroy(collision.gameObject,1);
        Destroy(GetComponent<BoxCollider2D>());
    }
}
