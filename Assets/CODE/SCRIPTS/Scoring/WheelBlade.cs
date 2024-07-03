using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBlade : MonoBehaviour
{
    public bool win;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slot")
        {
            ScoreManager.Score += 10;
            if(collision.GetComponent<SlotContainer>().hasChakra == true)
            {
                win = true;
            }
            else
            {
                win = false;
            }
        }
    }
}
