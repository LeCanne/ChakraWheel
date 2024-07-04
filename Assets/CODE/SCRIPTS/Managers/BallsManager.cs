using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public static List<GameObject> balls = new List<GameObject>();
    public static List<GameObject> balls2 = new List<GameObject>();

    public GameObject GameOver;
    public TMP_Text texti;
    public bool started;

    public static GameObject UnderChakraLayer;
    public static GameObject ChakraLayer;

    public GameObject under;
    public GameObject over;

    bool white;
    bool red;
    bool green;
    bool purple;
    bool yellow;
    bool blue;
    bool orange;
    bool pink;

    private void Awake()
    {
        UnderChakraLayer = under;
        ChakraLayer = over;
    }
    // Start is called before the first frame update
    void Start()
    {
        balls.Clear();
        balls = new List<GameObject>();

        balls2.Clear();
        balls2 = new List<GameObject>();

        StartCoroutine(Stort());
    }

    // Update is called once per frame
    void Update()
    {
       if(started == true)
        {
            if (balls.Count > 0)
            {
                balls.RemoveAll(s => s == null);
            }
            else
            {
              
                texti.text = "GAME OVER";
                GameOver.SetActive(true);
            }
         
            Win();
        }
     


    }

    public void Win()
    {
        for(int i = 0; i < balls.Count; i++)
        {
            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.White)
            {
                white = true;
            }

            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.Red)
            {
                red = true;
            }

            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.Green)
            {
                green = true;
            }

            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.Purple)
            {
                purple = true;
            }

            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.Yellow)
            {
                yellow = true;
            }

            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.Blue)
            {
                blue = true;
            }

            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.Orange)
            {
                orange = true;
            }

            if (balls[i].GetComponent<ChakraType>().chakra == ChakraType.CHAKRATYPE.Pink)
            {
                pink = true;
            }


        }
        if (white == true && red == true && green == true && purple == true && yellow == true && blue == true && orange == true && green == true && pink == true)
        {
            texti.text = "YOU WIN!";
            GameOver.SetActive(true);
        }
        else
        {
            white = false;
            red = false;
            green = false;
            purple = false;
            yellow = false;
            blue = false;
            orange = false;
            green = false;
            pink = false;
        }

    }

    public IEnumerator Stort()
    {
        yield return new WaitForSeconds(0.5f);
        started = true;
    }
}
