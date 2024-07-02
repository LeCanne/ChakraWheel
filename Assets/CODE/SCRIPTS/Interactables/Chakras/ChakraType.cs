
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChakraType : MonoBehaviour
{
    public Image _spriteChakra;
    private enum CHAKRATYPE
    {
        Yellow,
        Purple,
        Blue,
        Pink,
        Orange,
        Red,
        Green,
        White
        
    }

    private void Awake()
    {
        DefineChakra();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void DefineChakra()
    {

    }
}
