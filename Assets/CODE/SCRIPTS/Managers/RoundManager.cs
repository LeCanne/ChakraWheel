using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public List<SlotContainer> slots;
    public WheelController Wheelcontroller;
    public bool process;
    public GameObject parentGame;
    public GameObject Chakra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void LaunchNewRound()
   {
     

     
      if(process == false)
        {
            if (Wheelcontroller.wheelBlade.win == true)
            {
                ScoreManager.Score += 100;
            }
            
            
                
            
            StartCoroutine(DoNewRound());
            process = true;
        }
       

   }

    public IEnumerator DoNewRound()
    {
        if (Wheelcontroller.wheelBlade.win == true)
        {
            foreach (SlotContainer slot in slots)
            {
                slot.isDarkened = false;
                if (slot.ContainedChakra != null)
                {

                    slot.ContainedChakra.GetComponent<ChakraPhysics>().onSlot = false;
                    slot.ContainedChakra.GetComponent<ChakraPhysics>().locked = false;
                    slot.ContainedChakra.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-900f, 900f), Random.Range(-900f, 900f)), ForceMode2D.Impulse);
                    slot.ContainedChakra.layer = 5;
                    slot.gameObject.layer = 8;
                    slot.ContainedChakra = null;
                }

            }
        }
        else
        {
            foreach (SlotContainer slot in slots)
            {
                slot.isDarkened = false;
                Destroy(slot.ContainedChakra);
                slot.ContainedChakra = null;
                
                  
                  
                    
                    slot.gameObject.layer = 8;
                    
                

            }
        }
      
        yield return new WaitForSeconds(1f);
        int max = 2;
        int current = 0;
        foreach (SlotContainer slot in slots)
        {
            int r = Random.Range(0, 2);
            if(current < max)
            {
                if (r == 1)
                {
                    current += 1;
                    slot.isDarkened = true;
                    slot.gameObject.layer = 8;
                }
                else
                {
                    slot.gameObject.layer = 7;
                }
            }
            else
            {
                slot.gameObject.layer = 7;
            }

            
        }
        current = 0;
        foreach (SlotContainer slot in slots)
        {
           if(slot.isDarkened == false && current == 0)
           {
              int r =  Random.Range(0, 2);
                if(r == 1)
                {
                    
                    GameObject obj = Instantiate(Chakra, slot.transform);
                    obj.transform.parent = parentGame.transform;
                    obj.GetComponent<ChakraPhysics>().locked = true;
                    obj.GetComponent<ChakraPhysics>().ChosenSlot = slot.gameObject;
                   
                    obj.GetComponent<ChakraPhysics>().onSlot = true;
                    obj.layer = 7;
                    slot.ContainedChakra = obj;
                    current += 1;
                }
           }
            slot.usable = true;
        }
        yield return new WaitForSeconds(1f);
        Wheelcontroller.draggable = true;
        process = false;
        yield return null;
    }
}
