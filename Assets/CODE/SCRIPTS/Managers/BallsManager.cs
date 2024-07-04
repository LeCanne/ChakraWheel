using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public static List<GameObject> balls = new List<GameObject>();
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(balls.Count > 0)
        {
            balls.RemoveAll(s => s == null);
        }
        else
        {
            Debug.Log("Lose");
            GameOver.SetActive(true);
        }
        Debug.Log(balls.Count);

        
    }
}
