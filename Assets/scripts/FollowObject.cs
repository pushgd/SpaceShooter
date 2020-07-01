using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    GameObject followObject;

    [SerializeField]
    [Range(0, 1)]
    float speed =0.5f;
   


    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followObject.transform.position + new Vector3(0, 0, -10), speed);



    }
}
