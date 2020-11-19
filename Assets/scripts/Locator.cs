using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    // Start is called before the first frame update
    BulletChase bulletChase;
    void Start()
    {
        bulletChase =  transform.parent.GetComponent<BulletChase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToLower().Equals("Enemy".ToLower()))
        {
            print(collision.gameObject.transform.name);
            bulletChase.newTargetLocated(collision.gameObject);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print("Exit "+collision.gameObject.transform.name);
    }
}
