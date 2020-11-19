using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player : MonoBehaviour
{


    //UI Components
    [SerializeField]
    Image HPBar;
    [SerializeField]
    Image SPBar;
    [SerializeField]
    VirtualJoystick joystick;

    AudioSource audioSource;

    float HP = 15;

    float SP = 15;

    [SerializeField]
    PlaneInfo planeInfo;

    float maxHP;
    float maxSP;
    // Start is called before the first frame update
    float shieldCooldown = 1;

    Shield shield;
    float speed = 0.5f;

    float currentMagnitude;

    float acclerationCounter = 1.0f;

    Vector3 input;
    void Start()
    {
        HP = planeInfo.HP;
        SP = planeInfo.SP;

        maxHP = HP;
        maxSP = SP;
        shield = GetComponent<Shield>();
    }

    // Update is called once per frame
    void Update()
    {

        handleInput();
        rechargeShield();

       

    }

    private void rechargeShield()
    {

        shieldCooldown += Time.deltaTime;
        if (shieldCooldown > planeInfo.shieldRechargeDelay && SP < maxSP)
        {
            SP += planeInfo.shieldRechargeRate;

        }
        SPBar.fillAmount = (float)SP / (float)maxSP;


    }

    private void handleInput()
    {
        input = new Vector3(joystick.getHorizontalAxis(), joystick.getVerticalAxis());
        RotateInput();
        acclerationCounter += Time.deltaTime;
        float mag = input.magnitude;
      
        if(mag <= 0.5f)
        {
            mag = 0.5f;
        }

       


        if (acclerationCounter >= 1f)
        {
            acclerationCounter = 0;
            speed = speed + planeInfo.engine.accleration;
  
            speed = Mathf.Clamp(speed, 0.5f, planeInfo.engine.speed);
            
        }
        transform.position += new Vector3(-Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0) * Time.deltaTime * speed*mag;
        
    }

    private void RotateInput()
    {
         
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
                    delta.z = +planeInfo.engine.turnRate * Time.deltaTime;
                }
                else
                {
                    delta.z = -planeInfo.engine.turnRate * Time.deltaTime;
                }
            }
            if (currentZ < targetAngle)
            {
                if (Mathf.Abs(targetAngle - currentZ) > 180)
                {
                    delta.z = -planeInfo.engine.turnRate * Time.deltaTime;
                }
                else
                {
                    delta.z = +planeInfo.engine.turnRate * Time.deltaTime;
                }

            }
            if (Mathf.Abs(currentZ - targetAngle) < planeInfo.engine.turnRate * Time.deltaTime) //if target is near than one step distance
            {
                delta.z = targetAngle - currentZ;
            }
            transform.Rotate(new Vector3(0, 0, delta.z), Space.Self);

            //transform.eulerAngles = transform.eulerAngles + delta;
            //rigidBody.angularVelocity = 0;
        }
    }


    private void OnDestroy()
    {
        //
    }

    void onPlayerDie()
    {
        SceneManager.LoadScene(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Contains("EnemyBullet"))
        {
            //print("Player Collided " + collision.gameObject.tag);

            Bullet b = collision.gameObject.GetComponent<Bullet>();
            if (b.getHP() > 0)
            {
                b.reduceHPby(1);
                float damage = b.getDamage();

                takeDamage(damage, collision.gameObject);

                if (HP <= 0)
                {

                    Destroy(this.gameObject, 2);
                    Invoke("onPlayerDie", 1);
                }
            }


        }

    }

    private void takeDamage(float damage, GameObject g)
    {

        if (SP > 0)
        {
            SP -= damage;
            shield.onShieldDamage(g);
        }
        else
        {
            HP -= damage;
            HPBar.fillAmount = (float)HP / (float)maxHP;
        }
        shieldCooldown = 0;

    }
}
