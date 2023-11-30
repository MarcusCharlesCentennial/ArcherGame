using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    private CapsuleCollider2D jumpCollide;
    public static bool onGround = true;
    // Start is called before the first frame update

    void Start()
    {
        jumpCollide = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            Debug.Log("On Ground");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
            Debug.Log("Not On Ground");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
