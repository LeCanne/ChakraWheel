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
            if(collision.GetComponent<SlotContainer>().ContainedChakra == null && collision.GetComponent<SlotContainer>().spinning == false)
            {
                
                collision.GetComponent<SlotContainer>().Assign(gameObject);
                

                this.enabled = false;
            }
           

        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.enabled == true)
        {
            if (other.gameObject.tag == "Slot")
            {                 
                
                if (other.GetComponent<SlotContainer>().ContainedChakra == this.gameObject && other.GetComponent<SlotContainer>().spinning == false)
                {
                    
                    Debug.Log("Do");
                    chakraPhysics.onSlot = false;
                    chakraPhysics.ChosenSlot = null;
                    gameObject.layer = 5;
                    other.GetComponent<SlotContainer>().ContainedChakra = null;
                    

                }
            }
           
        }
       
    }
}
