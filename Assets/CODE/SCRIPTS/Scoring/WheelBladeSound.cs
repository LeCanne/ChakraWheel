using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBladeSound : MonoBehaviour
{
    public AudioClip audioClip;
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
        if (collision.gameObject.tag == "Slot")
        {
            AudioManager.instance.PlaySoundFXClip(audioClip, transform, 0.05f, Random.Range(0.7f, 1f));
        }
    }
}
