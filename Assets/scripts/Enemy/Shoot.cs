using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    string bullet = "bullet";

    [SerializeField]
    float fireRate = 1;
    AudioSource audioSource;
    [SerializeField]
    AudioClip fire;

    public string[] gunName;

    private Transform[] gunList;
    private float coolDown;

    GameObject g1;
    void Start()
    {
        g1 = Resources.Load<GameObject>(bullet);
        coolDown = fireRate + 1;
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
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

       
        coolDown += Time.deltaTime;
        //print("coolDown" + coolDown);

    }


    public void targetInSight(GameObject target,Vector3 direction)
    {
       
        if (coolDown > fireRate)
        {

            foreach (Transform t in gunList)
            {
                GameObject b = Instantiate(g1, t.position, transform.rotation);
                
            }
            coolDown = 0;
            audioSource.PlayOneShot(fire);
        }
    }

}
