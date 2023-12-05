using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public AudioSource hitSound;
    public int health = 3; // Default health, can be modified in the Inspector

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            // Play hit sound
            hitSound.Play();

            // Reduce health
            health--;

            // Destroy the arrow (or the attacking object)
            Destroy(collision.gameObject);

            // Check if health is depleted
            if (health <= 0)
            {
                Destroy(this.gameObject);
                hitSound.Play();
            }
        }
    }
}
