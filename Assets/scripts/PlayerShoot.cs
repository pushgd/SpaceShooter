using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
   

    

    
    AudioSource audioSource;
    [SerializeField]
    PlaneInfo planeInfo;
    [SerializeField]
    AudioClip fireSound;

    [SerializeField]
    FireButton fireButton;
    [SerializeField]
    FireButton altFireButton;
    [SerializeField]
    private string[] gunName;


    private Transform[] gunList;
    private float firecoolDown;
    private float altFirecoolDown;

    GameObject bulletResource;
    GameObject altBulletResource;
  



    void Start()
    {
        print(planeInfo.text);
        bulletResource = Resources.Load<GameObject>("bullets\\playerBullet\\"+planeInfo.gun.bulletInfo.bullet);
        altBulletResource = Resources.Load<GameObject>("bullets\\playerBullet\\"+planeInfo.altGun.bulletInfo.bullet);

        firecoolDown = planeInfo.gun.fireRate+ 1;
        altFirecoolDown = planeInfo.altGun.fireRate + 1;
        initGuns();
        audioSource = GetComponent<AudioSource>();

    }

    private void initGuns()
    {
        gunList = new Transform[gunName.Length];
        int gi = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            foreach (string g in gunName)
            {
                if (g.Equals(transform.GetChild(i).name))
                {
                    gunList[gi] = transform.GetChild(i);
                    gi++;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        fire();
        altFire();
        //print("coolDown" + coolDown);

    }

    private void fire()
    {
        if (fireButton.isPressed() && firecoolDown > planeInfo.gun.fireRate)
        {

            foreach (Transform gun in gunList)
            {
                GameObject b = Instantiate(bulletResource, gun.position, gun.rotation);
            }
            firecoolDown = 0;
            audioSource.PlayOneShot(fireSound);
        }
        firecoolDown += Time.deltaTime;
    }


    private void altFire()
    {
        if (altFireButton.isPressed() && altFirecoolDown > planeInfo.altGun.fireRate)
        {
            
            foreach (Transform gun in gunList)
            {
                GameObject b = Instantiate(altBulletResource, gun.position, gun.rotation);
            }
            altFirecoolDown = 0;
            audioSource.PlayOneShot(fireSound);
        }
        altFirecoolDown += Time.deltaTime;
    }

}
