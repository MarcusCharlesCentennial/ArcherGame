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
                Flip();
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
                Flip();
                movingLeft = true; // Change direction
            }
        }
    }

    private void Move(float speed)
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

        // Flip the sprite based on the direction of movement
        if ((speed < 0 && transform.localScale.x > 0) || (speed > 0 && transform.localScale.x < 0))
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Multiply the x component of localScale by -1
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
