using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public enum PowerUpType { Speed, JumpHeight, FireRate }
    public PowerUpType type;
    public float duration = 5f; // Duration of power-up effect

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ArcherMovement player = collision.gameObject.GetComponent<ArcherMovement>();
            if (player != null)
            {
                ActivatePowerUp(player);
                Destroy(gameObject); // Destroy the power-up object
            }
        }
    }

    private void ActivatePowerUp(ArcherMovement player)
    {
        switch (type)
        {
            case PowerUpType.Speed:
                player.ModifySpeed(1.5f, duration); // Increase speed by 50%
                break;
            case PowerUpType.JumpHeight:
                player.ModifyJumpHeight(1.5f, duration); // Increase jump height by 50%
                break;
            case PowerUpType.FireRate:
                player.ModifyFireRate(0.25f, duration); // Decrease cooldown for faster fire rate
                break;
        }
    }
}
