using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArcherMovement : MonoBehaviour
{
    // Start is called before the first frame update

    //Gathered Unity Elements

    //Private variables for logic which don't need to be seen
    private float horizontal;
    private bool isFacing = true;
    private bool isJumping = false;

    //Public variables  which should be modifiable at any time
    public float speed = 40;
    public float jumpForce = 200;

    //Animation setup
    public Animator animator;

    //Ground check
    [SerializeField] private LayerMask m_WhatIsGround;
    [SerializeField] private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded;

    [SerializeField] private Rigidbody2D rb;


    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    // Update is called once per frame

    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        Flip();

        //Jump
        if (m_Grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping");
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isJumping = true;
            animator.SetBool("jump", true);
        }
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        void Flip()
        {
            //Method for switching directino of Player (Needs to be edited to not flip the background)
            if (isFacing && horizontal < 0f || !isFacing && horizontal > 0f)
            {
                isFacing = !isFacing;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
        animator.SetFloat("speed", Mathf.Abs(horizontal));
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime, rb.velocity.y);
        isJumping = false;
    }

    public void onLanding()
    {
        animator.SetBool("jump", false);

    }
}
