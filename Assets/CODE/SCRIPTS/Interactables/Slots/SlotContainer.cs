using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotContainer : MonoBehaviour
{
    
    public GameObject DarkChakra;
    public bool isDarkened;
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

    public void ContainChakra()
    {
        if(ContainedChakra != null)
        {
            collid2D.enabled = false;

        }
        else
        {
            collid2D.enabled = true;
        }
    }
}
