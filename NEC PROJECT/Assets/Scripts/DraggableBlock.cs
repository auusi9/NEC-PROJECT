using UnityEngine;
using System.Collections;

public class DraggableBlock : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject slider;
    float mousex;
    public float width2;
    public float width2block;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, gameObject.transform.position.y, gameObject.transform.position.z));
    }

    void OnMouseDrag()
    {
       width2 = slider.GetComponent<Collider2D>().offset.x ;

        width2block = GetComponent<Collider2D>().offset.x;

        if((width2block * 2) + transform.position.x < width2 + slider.transform.position.x)
        {
            transform.position.Set(slider.transform.position.x, transform.position.y, transform.position.z);
        }
        else if ((width2block*2) - transform.position.x < slider.transform.position.x - width2)
        {
            transform.position.Set(slider.transform.position.x - (width2*2), transform.position.y, transform.position.z);
        }
        else
        {
            mousex = Input.mousePosition.x;
        }
        
        Vector3 curScreenPoint = new Vector3(mousex, gameObject.transform.position.y, gameObject.transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition; 
    }

 
}
