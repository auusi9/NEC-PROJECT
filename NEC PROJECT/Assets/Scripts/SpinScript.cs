using UnityEngine;
using System.Collections;

public class SpinScript : MonoBehaviour
{
    float baseAngle2;
    /*
    private float[] baseAngle = new float[5];
    Vector2[] posBegan = new Vector2[5];
    Vector2[] posMoved = new Vector2[5];
    int[] touched = new int[5];*/
    Quaternion iniRot;

    /*void OnMouseDown()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
    }

    void OnMouseDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        float ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
    }*/

    void Start()
    {
        iniRot = transform.rotation;

    }


   /* void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                 Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                if (GetComponent<Collider2D>().OverlapPoint(touchPos))
                {
                    posBegan[i] = Camera.main.WorldToScreenPoint(transform.position);
                    posBegan[i] = Input.GetTouch(i).position - posBegan[i];
                    baseAngle[i] = Mathf.Atan2(posBegan[i].y, posBegan[i].x) * Mathf.Rad2Deg;
                    baseAngle[i] -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
                    touched[i] = 1;
                }
                else { touched[i] = 0; }

            }
            else if(Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                if(touched[i] == 1) { 
                    posMoved[i] = Camera.main.WorldToScreenPoint(transform.position);
                    posMoved[i] = Input.GetTouch(i).position - posMoved[i];
                    float ang = Mathf.Atan2(posMoved[i].y, posMoved[i].x) * Mathf.Rad2Deg - baseAngle[i];
                    transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
                }

            }
        }
    }*/

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

    }
    void onTouchExit()
    {

    }
    

}