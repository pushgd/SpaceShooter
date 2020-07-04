using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    AudioSource audioSource;
    [SerializeField]
    [Tooltip("Turn Rate")]
    float turnRate = 5;
    [SerializeField]
    [Tooltip("Max Speed")]
    float speed = 5;

 
    [SerializeField]
    VirtualJoystick joystick;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();

        transform.position += new Vector3(-Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0) * Time.deltaTime*speed;
       
    }
  
    private void handleInput()
    {
        respondToMovementInput();
    }

    private void respondToMovementInput()
    {
        Vector3 input = new Vector3(joystick.getHorizontalAxis(), joystick.getVerticalAxis());

        if (input.magnitude != 0)
        {

            float targetAngle = Mathf.Rad2Deg * Mathf.Atan2(input.y, input.x) - 90;// calculate target angle according to input from joystick
            if (targetAngle < 0)
            {
                targetAngle = targetAngle + 360;
            }
            float currentZ = transform.eulerAngles.z;
            Vector3 delta = new Vector3(0, 0, 0);
            if (currentZ > targetAngle)
            {
                if (Mathf.Abs(targetAngle - currentZ) > 180)
                {
                    delta.z = +turnRate * Time.deltaTime;
                }
                else
                {
                    delta.z = -turnRate * Time.deltaTime;
                }
            }
            if (currentZ < targetAngle)
            {
                if (Mathf.Abs(targetAngle - currentZ) > 180)
                {
                    delta.z = -turnRate * Time.deltaTime;
                }
                else
                {
                    delta.z = +turnRate * Time.deltaTime;
                }

            }
            if (Mathf.Abs(currentZ - targetAngle) < turnRate * Time.deltaTime) //if target is near than one step distance
            {
                delta.z = targetAngle - currentZ;
            }
            transform.Rotate(new Vector3(0, 0, delta.z), Space.Self);

            //transform.eulerAngles = transform.eulerAngles + delta;
            //rigidBody.angularVelocity = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collided");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            print("Player Collided "+ other.gameObject.tag);
        }
        
    }
}
