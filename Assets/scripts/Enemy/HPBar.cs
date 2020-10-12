using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // Start is called before the first frame update
    Enemy e;
    Image fill;
    float maxHP;
    Color c;
    float da;
    float lastHP;
    void Start()
    {
        e = transform.parent.GetComponent<Enemy>();
        fill = transform.GetChild(0).GetComponent<Image>();
        maxHP = e.getMaxHP();
        c = new Color(fill.color.r, fill.color.g, fill.color.b, fill.color.a);

    }

    // Update is called once per frame
    void Update()
    {

        fill.fillAmount = Mathf.Lerp(fill.fillAmount, e.getHP() / maxHP, 0.05f);
        if (lastHP != e.getHP())
        {
            c.a = 1;
            lastHP = e.getHP();
        }
        
        c.a -= 0.01f;
        fill.color = c;
    }
}
