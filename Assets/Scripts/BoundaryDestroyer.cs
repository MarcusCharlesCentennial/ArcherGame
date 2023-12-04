using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//may be replaced with raycaster
public class BoundaryDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject); // Destroy the player
            GameOver();
        }
    }
    private void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
