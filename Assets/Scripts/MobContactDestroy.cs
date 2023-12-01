using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobContactDestroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name); // This will log the name of any object the skeleton collides with.

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has been hit!"); // confirm the collision with the player is detected.
            Destroy(collision.gameObject); // Destroy the player
        }
    }
}
