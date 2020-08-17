using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject shield;
    SpriteRenderer s;

    [SerializeField]
    Color c;

    float displayCooldown;
    float displayDuration = 1;


    void Start()
    {
        shield.SetActive(false);
        s = shield.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (shield.activeSelf)
        {
            displayCooldown += Time.deltaTime;
            s.color = new Color(c.r, c.g, c.b,1-(displayCooldown / displayDuration));
            if (displayCooldown > displayDuration)
            {
                shield.SetActive(false);
            }
        }

    }

    public void onShieldDamage(GameObject g)
    {
        print("Shield Damaged");
        shield.SetActive(true);
        displayCooldown = 0;
        shield.transform.eulerAngles = new Vector3(0,0,g.transform.eulerAngles.z+90);

    }

}
