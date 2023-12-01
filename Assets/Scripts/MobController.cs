using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public float speed = 2.0f;
    public float leftBoundary;
    public float rightBoundary;

    private bool movingLeft = true;

    private void Update()
    {
        if (movingLeft)
        {
            // Move left
            if (transform.position.x > leftBoundary)
            {
                Move(-speed);
            }
            else
            {
                movingLeft = false; // Change direction
            }
        }
        else
        {
            // Move right
            if (transform.position.x < rightBoundary)
            {
                Move(speed);
            }
            else
            {
                movingLeft = true; // Change direction
            }
        }
    }

    private void Move(float speed)
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destroy the player or call a method to handle the player's defeat
        }
    }
}
