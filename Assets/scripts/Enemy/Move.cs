using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Max Speed")]
    float speed = 5;

    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0) * Time.deltaTime * speed;
    }

}
