using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    string bullet = "bullet";

    [SerializeField]
    float fireRate = 1;
    AudioSource audioSource;
    [SerializeField]
    AudioClip fire;

    [SerializeField]
    FireButton fireButton;

    public string[] gunName;

    private Transform[] gunList;
    private float coolDown;

    GameObject g1;
    private ParticleSystem p;

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

        if (fireButton.isPressed() && coolDown > fireRate)
        {

            foreach (Transform gun in gunList)
            {
                GameObject b = Instantiate(g1, gun.position, gun.rotation);
               

            }
            coolDown = 0;
            audioSource.PlayOneShot(fire);
            
        }
        coolDown += Time.deltaTime;
        //print("coolDown" + coolDown);

    }


}
