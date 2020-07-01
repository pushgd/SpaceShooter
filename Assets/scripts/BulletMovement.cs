using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    // Start is called before the first frame update
    float lifespan = 5;
    float age = 0;
    void Start()
    {
        Destroy(this.gameObject, lifespan);
    }
    public void shoot(float speed)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0) * speed * Time.deltaTime;
       
    }
}
