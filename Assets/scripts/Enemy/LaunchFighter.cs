using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchFighter : MonoBehaviour
{

    [SerializeField]
    private string[] launchpad;
    private Transform[] launchPads;
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] fighters;
    [SerializeField]
    int maxNumberOfFighter = 5;

    [SerializeField]
    int maxActiveNumberOfFighter = 1;

    [SerializeField]
    float cooldown = 2;
    float counter;
    int activeFighters = 0;

    bool cooldownFlag = true;


    GameObject[] dispatchedFighters;
    void Start()
    {
        initLaunchpad();
        dispatchedFighters = new GameObject[maxActiveNumberOfFighter];
    }
    private void initLaunchpad()
    {
        launchPads = new Transform[launchpad.Length];
        int gi = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            foreach (string g in launchpad)
            {
                if (g.Equals(transform.GetChild(i).name))
                {
                    launchPads[gi] = transform.GetChild(i);
                    gi++;
                }
            }

        }
    }
    
    // Update is called once per frame
    void Update()
    {

        if (maxNumberOfFighter > 0 && cooldownFlag)
        {
            launchFighter();
            cooldownFlag = false;
        }
        counter = counter + Time.deltaTime;
        if(counter>cooldown)
        {
            cooldownFlag = true;
            counter = 0;
        }


    }

    private void launchFighter()
    {


   
        if (activeFighters < maxActiveNumberOfFighter)
        {
            int i = 0;
            for (i = 0; i < dispatchedFighters.Length; i++)
            {
                if (dispatchedFighters[i] == null || dispatchedFighters[i].GetComponent<Enemy>().getHP() <= 0)
                {
                    GameObject f = Instantiate(fighters[Random.Range(0, fighters.Length)], launchPads[Random.Range(0, launchPads.Length)].position, transform.rotation);
                    dispatchedFighters[i] = f;
                    f.GetComponent<FaceObject>().setActivationDelay(2);
                    //activeFighters++;
                    maxNumberOfFighter--;
                    break;
                }
            }


        }
    }
}