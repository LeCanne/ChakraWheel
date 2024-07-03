using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Rigidbody2D rb2d;
    public float speed;
    public GameObject[] gameobjects;
    public Collider2D Blade;
    public WheelBlade wheelBlade;
    public RoundManager roundManager;
    public bool draggable;
    public TMP_Text txt_Turn;
    public int turn;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        
            if (Mathf.Abs(rb2d.angularVelocity) > 300f)
            {
                foreach (GameObject gameobject in gameobjects)
                {
                    gameobject.GetComponent<SlotContainer>().usable = false;
                }
            }

            if(draggable == true)
            {
             if (Mathf.Abs(rb2d.angularVelocity) == 0)
             {
                foreach (GameObject gameobject in gameobjects)
                {
                    gameobject.GetComponent<SlotContainer>().usable = true;
                }
             }
            }
        
      
        if (rb2d.angularVelocity == 0)
        {
            if (draggable == false)
            {
                

                roundManager.LaunchNewRound();

            }

            
       }
       else
       {
            
        }
           
        
    }
    void FixedUpdate()
    {
       // rb2d.angularVelocity = -100f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(draggable == true)
        {
            Blade.enabled = false;

            if (Input.mousePosition.x < Screen.width / 2f)
            {
                if (eventData.dragging)
                {
                    rb2d.angularVelocity = Input.GetAxis("Mouse Y") * -100;

                }
            }
            else
            {

                if (eventData.dragging)
                {
                    rb2d.angularVelocity = Input.GetAxis("Mouse Y") * 100;

                }
            }
        }
      
      
       
       
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(draggable == true)
        {
            rb2d.angularVelocity = 0;
        }
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      if(draggable == true)
        {
            if (Mathf.Abs(rb2d.angularVelocity) > 300f)
            {
              
                Blade.enabled = true;
                draggable = false;
                turn += 1;
                txt_Turn.text = turn.ToString("Turn " + "0");
            }
        }
       
      
        
    }

    
}
