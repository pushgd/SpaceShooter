using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletChase : MonoBehaviour
{
    GameObject target;
    BulletInfo bulletInfo;
    Enemy e;
    // Start is called before the first frame update
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player");

        bulletInfo = GetComponent<Bullet>().getBulletInfo();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            rotate();
            if (e.getHP() <= 0)
            {
                target = null;
            }

        }
    }

    private void rotate()
    {
        Vector3 directionVector = target.transform.position - transform.position;

        float angle = Mathf.Atan2(directionVector.y, directionVector.x) * Mathf.Rad2Deg - 90;
        if (angle < 0)
        {
            angle = angle + 360;
        }
        //        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), speed * Time.deltaTime);

        //Debug.DrawRay(transform.position, directionVector, Color.red);


        float currentZ = transform.eulerAngles.z;
        Vector3 delta = new Vector3(0, 0, 0);
        if (currentZ > angle)
        {
            if (Mathf.Abs(angle - currentZ) > 180)
            {
                delta.z = +bulletInfo.turnRate * Time.deltaTime;
            }
            else
            {
                delta.z = -bulletInfo.turnRate * Time.deltaTime;
            }
        }
        if (currentZ < angle)
        {
            if (Mathf.Abs(angle - currentZ) > 180)
            {
                try
                {

                    delta.z = -bulletInfo.turnRate * Time.deltaTime;
                }
                catch
                {
                    print(transform.name);

                }
            }
            else
            {
                delta.z = +bulletInfo.turnRate * Time.deltaTime;
            }

        }
        if (Mathf.Abs(currentZ - angle) < bulletInfo.turnRate * Time.deltaTime) //if target is near than one step distance
        {
            delta.z = angle - currentZ;
        }
        transform.Rotate(new Vector3(0, 0, delta.z), Space.Self);



        //float diff = angle - transform.eulerAngles.z;
        //if (diff < 0)
        //{
        //    diff = diff + 360;
        //}
        //if (diff < 15)
        //{
        //    Vector3 sqDistance = target.transform.position - transform.position;
        //    if (Vector3.SqrMagnitude(sqDistance) < planeInfo.range * planeInfo.range)
        //    {

        //    }
        //}
    }

    public void newTargetLocated(GameObject target)
    {

        print("New Target Received " + target.transform.name + "**" + this.target);
        if (this.target == null)
        {
            print(target.name);
            this.target = target;
            e = this.target.GetComponent<Enemy>();
        }
    }

}
