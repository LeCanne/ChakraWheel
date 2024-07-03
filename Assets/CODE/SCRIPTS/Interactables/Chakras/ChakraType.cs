
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChakraType : MonoBehaviour
{
    public Image _spriteChakra;
    private int typeChakra;
    public bool randomized;
    public List<Sprite> spriteList;
    private Image _image;
    public string nameColor;
   
    private enum CHAKRATYPE
    {
        Yellow,
        Purple,
        Blue,
        Red,
        Orange,
        Green,
        Pink,
        White
        
    }

    private CHAKRATYPE chakra;



    private void Awake()
    {
        typeChakra = 8;
        _image = GetComponent<Image>();
        DefineChakra();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void DefineChakra()
    {
        if(randomized == true)
        {
            typeChakra = Random.Range(0, spriteList.Count);
            _image.sprite = spriteList[typeChakra];
        }
       

        switch (typeChakra)
        {
            case 0:
                chakra = CHAKRATYPE.Yellow;
                break;
            case 1:
                chakra = CHAKRATYPE.Purple;
                break;
            case 3:
                chakra = CHAKRATYPE.Blue;
                break;
            case 4:
                chakra = CHAKRATYPE.Red;
                break;
            case 5:
                chakra = CHAKRATYPE.Orange;
                break;
            case 6:
                chakra = CHAKRATYPE.Green;
                break;
            case 7:
                chakra = CHAKRATYPE.Pink;
                break;
            case 8:
                chakra = CHAKRATYPE.White;
                break;


        }
       
    }
}
