using UnityEngine;
using System.Collections;

public class SpinScript : MonoBehaviour
{
    float baseAngle2;
    Quaternion iniRot;

    void Start()
    {
        iniRot = transform.rotation;

    }

    void LateUpdate()
    {
        if(Time.timeScale == 0 )
        {
            transform.rotation = iniRot;
            
        }

        iniRot = transform.rotation;
    }


    void onTouchDown(Vector3 position)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = position - pos;
        baseAngle2 = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle2 -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;

    }

    


    void onTouchStay(Vector3 position)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = position - pos;
        float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle2;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
    }

    void onTouchUp()
    {
        //Add Code 
    }
    void onTouchExit()
    {
        //Add Code 
    }
    

}