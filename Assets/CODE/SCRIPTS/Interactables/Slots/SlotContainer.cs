using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotContainer : MonoBehaviour
{
    public GameObject slotContainer;
    public GameObject DarkChakra;
    public bool isDarkened;
    public GameObject ContainedChakra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckDarkness();
       
    }

    void CheckDarkness()
    {
        if(isDarkened == true)
        {
            DarkChakra.SetActive(true);
        }
        else
        {
            DarkChakra.SetActive(false);
        }
    }

    void ContainChakra()
    {

    }
}
