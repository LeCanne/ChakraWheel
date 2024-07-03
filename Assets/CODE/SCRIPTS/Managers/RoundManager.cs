using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public List<SlotContainer> slots;
    public WheelController Wheelcontroller;
    public bool process;
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
        foreach (SlotContainer slot in slots)
        {
            slot.isDarkened = false;
            if (slot.ContainedChakra != null)
            {
                
                slot.ContainedChakra.GetComponent<ChakraPhysics>().onSlot = false;
                slot.ContainedChakra.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-900f, 900f), Random.Range(-900f, 900f)), ForceMode2D.Impulse);
                slot.ContainedChakra.layer = 5;
                slot.gameObject.layer = 8;
                slot.ContainedChakra = null;
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

            slot.usable = true;
        }
       yield return new WaitForSeconds(1f);
        Wheelcontroller.draggable = true;
        process = false;
        yield return null;
    }
}
