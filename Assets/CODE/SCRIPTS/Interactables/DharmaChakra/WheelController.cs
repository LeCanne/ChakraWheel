using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private Rigidbody2D rb2d;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // rb2d.angularVelocity = -100f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.dragging)
        { 
                rb2d.angularVelocity = Input.GetAxis("Mouse Y") * 100;
            
        }
       
        Debug.Log("woo");
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        rb2d.angularVelocity = 0;
    }
}
