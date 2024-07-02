using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChakraPhysics : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Rigidbody2D rb2d;
    private bool inDrag;
    private Vector2 drag;
    [SerializeField] private PhysicsMaterial2D bouncemat;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.sharedMaterial = bouncemat;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (inDrag)
        {
            rb2d.sharedMaterial = null;
            rb2d.MovePosition(drag);
        }
       
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (eventData.dragging == true)
        {
            rb2d.velocity = Vector2.zero;
           
            drag = eventData.position;
            inDrag = true;
          
        }
       
        
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inDrag = false;
        Debug.Log("Done");
        rb2d.sharedMaterial = bouncemat;
    }
}
