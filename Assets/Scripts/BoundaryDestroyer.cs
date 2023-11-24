using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//may be replaced with raycaster
public class BoundaryDestroyer : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
        GameOver();
    }
    private void GameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}
