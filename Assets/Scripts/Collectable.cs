using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource audioSound;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            audioSound.Play();
            Destroy(this.gameObject);
        }
    }
}
