using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    [SerializeField]
    float HP = 15;

    [SerializeField]
    float SP = 15;

    [SerializeField]
    float shieldRechargeDelay = 1;

    [SerializeField]
    float shieldRechargeRate = 0.5f;

    float shieldCooldown;


    [SerializeField]
    Image HPBar;
    [SerializeField]
    Image SPBar;

    float maxHP;
    float maxSP;
    // Start is called before the first frame update


    void Start()
    {
        maxHP = HP;
        maxSP = SP;
    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
        rechargeShield();
        transform.position += new Vector3(-Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 0) * Time.deltaTime * speed;

    }

    private void rechargeShield()
    {

        shieldCooldown += Time.deltaTime;
        if (shieldCooldown > shieldRechargeDelay && SP < maxSP)
        {
            print("recharing Shield");
            SP += shieldRechargeRate;

        }
        SPBar.fillAmount = (float)SP / (float)maxSP;


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


    private void OnDestroy()
    {
        //
    }

    void onPlayerDie()
    {
        SceneManager.LoadScene(0);
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
                int damage = b.getDamage();

                takeDamage(damage,collision.gameObject);

                if (HP <= 0)
                {

                    Destroy(this.gameObject, 2);
                    Invoke("onPlayerDie", 1);
                }
            }


        }

    }

    private void takeDamage(int damage,GameObject g)
    {

        if (SP > 0)
        {
            SP -= damage;
            GetComponent<Shield>().onShieldDamage(g);
        }
        else
        {
            HP -= damage;
            HPBar.fillAmount = (float)HP / (float)maxHP;
        }
        shieldCooldown = 0;
       
    }
}
