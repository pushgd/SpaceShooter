using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGizmo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.green;
        float angle = transform.eulerAngles.z + 90;
        Vector3 direction = new Vector3(Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad),1);
        
        Gizmos.DrawRay(transform.position, direction*0.5f);

    }



}
