using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStuff : MonoBehaviour
{
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Fish")
        {
            Play(1);
            Debug.Log(collision.gameObject.tag);
        }

        if (collision.gameObject.tag == "Pillow")
        {
            Play(4);
        }

        if (collision.gameObject.tag == "Bell")
        {
            Play(0);
        }

        if (collision.gameObject.tag == "CatTower")
        {
            Play(2);
            Debug.Log(collision.gameObject.tag);
        }
    }

    void Play(int category)
    {
        audioManager.PlaySound(category);
    }
}
