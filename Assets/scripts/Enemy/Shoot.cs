using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    PlaneInfo planeInfo;

    AudioSource audioSource;
    [SerializeField]
    AudioClip fireSound;

    [SerializeField]
    private string[] gunName;

    private Transform[] gunList;
    private float coolDown;

    GameObject g1;
    void Start()
    {
        planeInfo = GetComponent<Enemy>().getPlaneInfo();
        g1 = Resources.Load<GameObject>("bullets\\enemyBullet\\" + planeInfo.gun.bulletInfo.bullet);
        coolDown = planeInfo.gun.fireRate + 1;
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


        coolDown += Time.deltaTime;
        //print("coolDown" + coolDown);

    }


    public void targetInSight(GameObject target, Vector3 direction)
    {

        if (coolDown > planeInfo.gun.fireRate)
        {

            foreach (Transform t in gunList)
            {
                GameObject b = Instantiate(g1, t.position, transform.rotation);

            }
            coolDown = 0;

            audioSource.PlayOneShot(fireSound);
        }
    }

}
