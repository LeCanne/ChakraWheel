using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChakraPhysics : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Rigidbody2D rb2d;
    public GameObject Chains;
    public bool inDrag;
    public bool onSlot;
    public bool locked;
    public bool checkOnce;
    private Vector2 drag;
    [SerializeField] private PhysicsMaterial2D bouncemat;
    public GameObject ChosenSlot;
    public AudioClip audioHit;
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.sharedMaterial = bouncemat;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (locked == false && checkOnce == false)
        {

            BallsManager.balls.Add(gameObject);
            checkOnce = true;


        }
        transform.eulerAngles = Vector3.zero;
        InSlotCheck();
        if(gameObject.layer == 5)
        {
            
        }
        
            Chains.SetActive(locked);

       

    }

    void InSlotCheck()
    {
        if(ChosenSlot != null)
        {
          if(inDrag == false)
          {
            if (onSlot == true)
            {
                    
                transform.position = ChosenSlot.transform.position;
                 gameObject.layer = 6;

                   
                    
            }
          }
        }
       
       
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
        if(locked == false)
        {
            if (eventData.dragging == true)
            {
                rb2d.velocity = Vector2.zero;
                gameObject.layer = 5;
                drag = eventData.position;
                inDrag = true;

            }
        }
       
       
        
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        inDrag = false;
        
        rb2d.sharedMaterial = bouncemat;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Chakra")
        {
            AudioManager.instance.PlaySoundFXClip(audioHit, transform, 0.05f, Random.Range(0.8f, 1));
        }
    }
}
