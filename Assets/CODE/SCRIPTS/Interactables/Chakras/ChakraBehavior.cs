using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChakraBehavior : MonoBehaviour
{
    private ChakraPhysics chakraPhysics;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        chakraPhysics = GetComponent<ChakraPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slot" && chakraPhysics.inDrag == true)
        {
            chakraPhysics.ChosenSlot = collision.gameObject;
            chakraPhysics.onSlot = true;

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.enabled == true)
        {
            if (other.gameObject.tag == "Slot")
            {
                chakraPhysics.onSlot = false;
                chakraPhysics.ChosenSlot = null;
            }
        }
       
    }
}
