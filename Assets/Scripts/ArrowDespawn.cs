using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArrowDespawn : MonoBehaviour
{
    //Private Variables
    private float groundContactTime = 0f;
    private bool isOnGround = false;

    //Public Variables
    public float timeToDisappear = 3f; // Time after which arrow disappears after hitting ground

    void Update()
    {
        if (isOnGround)
        {
            groundContactTime += Time.deltaTime;
            if (groundContactTime >= timeToDisappear)
            {
                Destroy(gameObject); // Destroy the arrow after 3 seconds
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") //Detect collision with object tagged "Ground"
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
            groundContactTime = 0f; // Reset timer if arrow leaves the ground
        }
    }
}

