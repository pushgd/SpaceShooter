using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalAudio : MonoBehaviour
{
    [SerializeField]
    AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(explosionSound);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
