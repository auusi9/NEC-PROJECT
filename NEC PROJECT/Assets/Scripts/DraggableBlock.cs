using UnityEngine;
using System.Collections;

public class DraggableBlock : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject slider;
    float mousex;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, gameObject.transform.position.y, gameObject.transform.position.z));
    }

    void OnMouseDrag()
    {
        float width2 = slider.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float width2block = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        if(width2block > width2 + slider.transform.position.x)
        {
            mousex = width2 + slider.transform.position.x;
        }
        else if (width2block < slider.transform.position.x - width2)
        {
            mousex = slider.transform.position.x - width2;
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
