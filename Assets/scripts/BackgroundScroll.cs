using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Material material;
    [SerializeField]
    float parallaxFactor = 2;
    void Start()
    {

        material = GetComponent<MeshRenderer>().material;






    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        Vector2 offset = new Vector2(transform.position.x / transform.localScale.x/parallaxFactor, transform.position.y / transform.localScale.y / parallaxFactor);
        

        material.mainTextureOffset= offset;



    }


}
