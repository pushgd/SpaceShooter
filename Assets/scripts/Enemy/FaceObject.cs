using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceObject : MonoBehaviour
{
    // Start is called before the first frame update
    // The target marker.
    
    PlaneInfo planeInfo;
    [SerializeField]
    GameObject target;



    Shoot shoot;
    [SerializeField]
    float activationDelay;

    float activationCooldown;

    private void Start()
    {
        shoot = GetComponent<Shoot>();
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
        activationCooldown = 0;
        planeInfo = GetComponent<Enemy>().getPlaneInfo();
    }
    void Update()
    {

        if (activationCooldown > activationDelay)
            rotate();
        else
            activationCooldown += Time.deltaTime;

        //Quaternion.LerpUnclamped




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
                delta.z = +planeInfo.engine.turnRate * Time.deltaTime;
            }
            else
            {
                delta.z = -planeInfo.engine.turnRate * Time.deltaTime;
            }
        }
        if (currentZ < angle)
        {
            if (Mathf.Abs(angle - currentZ) > 180)
            {
                try
                {

                    delta.z = -planeInfo.engine.turnRate * Time.deltaTime;
                }
                catch
                {
                    print(transform.name);
                    print(planeInfo.engine);
                }
            }
            else
            {
                delta.z = +planeInfo.engine.turnRate * Time.deltaTime;
            }

        }
        if (Mathf.Abs(currentZ - angle) < planeInfo.engine.turnRate * Time.deltaTime) //if target is near than one step distance
        {
            delta.z = angle - currentZ;
        }
        transform.Rotate(new Vector3(0, 0, delta.z), Space.Self);



        float diff = angle - transform.eulerAngles.z;
        if (diff < 0)
        {
            diff = diff + 360;
        }
        if (diff < 15)
        {
            Vector3 sqDistance = target.transform.position - transform.position;
            if (Vector3.SqrMagnitude(sqDistance) < planeInfo.range * planeInfo.range)
            {
                shoot.targetInSight(target, directionVector);
            }
        }
    }

    public void setActivationDelay(float x)
    {
        activationDelay = x;
    }
}
