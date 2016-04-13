using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelMenuRotation : MonoBehaviour {

    float baseAngle2;
    bool GoTo = false;
    float angleToGo;
    float currentAngle;

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
    void Update()
    {
        if (GoTo == true)
        {
            GoToAngle();

        }
    }
    void onTouchUp()
    {
        float angle = transform.rotation.eulerAngles.z;

        if (angle > 72f && angle < 144f)
        {
            GoTo = true;
            angleToGo = 108;
            //transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        else if (angle >= 144f && angle < 216f)
        {
            GoTo = true;
            angleToGo = 180;
            //transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        else if (angle >= 216f && angle < 288f)
        {
            GoTo = true;
            angleToGo =252;

            //transform.rotation = Quaternion.AngleAxis(270, Vector3.forward);
        }
        else if (angle > 288f && angle < 360f)
        {
            GoTo = true;
            angleToGo = 324;
            //transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        else if (angle >360f || angle < 72f)
        {
            GoTo = true;
            angleToGo = 36;
            //transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        currentAngle = angle;
        if (currentAngle == 72 || currentAngle == 144 || currentAngle == 360 || currentAngle == 288 || currentAngle == 216) currentAngle++;
    }

    void onTouchExit()
    {
        //Add Code 
    }

    void GoToAngle()
    {
        currentAngle = Mathf.Round(currentAngle);
        if (currentAngle == angleToGo)
        {
            currentAngle = angleToGo;
            GoTo = false;
        }
        if (currentAngle > angleToGo && currentAngle < 360)
            currentAngle--;
        else if (currentAngle < angleToGo || currentAngle > 360)
            currentAngle++;
        if (currentAngle == 360) currentAngle = 0;

        transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);

    }
}
