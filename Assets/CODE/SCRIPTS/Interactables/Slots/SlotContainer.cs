using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotContainer : MonoBehaviour
{
    
    public GameObject DarkChakra;
    public bool isDarkened;
    public bool usable;
    public bool spinning;
    public bool hasChakra;
   
    public GameObject ContainedChakra;
    private Collider2D collid2D;
    
    // Start is called before the first frame update
    void Start()
    {
        collid2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDarkness();
        CheckChakra();
    }

    void CheckDarkness()
    {
        if(isDarkened == true)
        {
            DarkChakra.SetActive(true);
            gameObject.layer = 8;
        }
        else
        {
            DarkChakra.SetActive(false);
            gameObject.layer = 7;
        }
    }

    void CheckChakra()
    {
        if(ContainedChakra != null)
        {
            hasChakra = true;
        }
        else
        {
            hasChakra = false;
        }
    }

    public void Assign(GameObject objecttoAssign)
    {
        if (usable == true && isDarkened == false)
        {
            
            objecttoAssign.GetComponent<ChakraPhysics>().ChosenSlot = gameObject;
            objecttoAssign.GetComponent<ChakraPhysics>().onSlot = true;
            ContainedChakra = objecttoAssign;
        }
        
    }

    
}
