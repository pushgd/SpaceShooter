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
        c.a = 0;
        lastHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //print((fill.fillAmount - (e.getHP() / maxHP)));
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, e.getHP() / maxHP, 0.09f);
        if (lastHP != e.getHP()|| fill.fillAmount - (e.getHP() / maxHP) > 0.05f)
        {
            c.a = 0.7f;
            lastHP = e.getHP();
        }
        
        c.a -= 0.007f;
        fill.color = c;
    }
}
