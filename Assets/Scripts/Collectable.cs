using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public AudioSource audioSound;
    public abstract void score(int item);
    public static int scoreSender = 0;
    public static bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            audioSound.Play();
            Destroy(this.gameObject);
            hasCollided = true;
            scoreSender = scoreSender + 1;
            Debug.Log("Item Touched");
        }
        else
        {
            hasCollided = false;
        }
    }
}
