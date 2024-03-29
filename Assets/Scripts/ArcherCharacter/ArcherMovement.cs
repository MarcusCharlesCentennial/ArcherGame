using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    //Gathered Unity Elements

    //Private variables for logic which don't need to be seen
    private float horizontal;
    private bool isFacing = true;
    private bool isJumping = false;
    private Animator animator;
    [SerializeField] private float shootCooldown = 0.5f; // Adjust this value as needed
    private float lastShootTime = 0f;
    [SerializeField] private Rigidbody2D rb;


    //Public variables  which should be modifiable at any time
    public float speed = 40;
    public float jumpForce = 200;
    public GameObject Arrow;
    public Transform arrowSpawn;
    public float arrowSpeed = 500;
    public AudioSource jumpSound;
    public AudioSource shootSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        
        Flip();

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && JumpCheck.onGround == true)
        {
            Debug.Log("Jumping");
            jumpSound.Play();
            animator.SetBool("jump", true);
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            
        }
        else
        {
            animator.SetBool("jump", false);
        }

        // Shooting with cooldown
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= lastShootTime + shootCooldown)
        {
            Debug.Log("Shooting");
            shootSound.Play();
            animator.SetBool("attack", true);
            lastShootTime = Time.time;
        }
        else
        {
            animator.SetBool("attack", false);
        }
        //Walking Animation
        if (horizontal>0||horizontal<0) {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime, rb.velocity.y);
    }


    //MOVEMENT METHODS:
    private void Flip()
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

    //SHOOTING METHODS:
    private void shootDelay()
    {
        ShootArrow();
    }
    private void ShootArrow()
    {
        GameObject arrow = Instantiate(Arrow, arrowSpawn.position, arrowSpawn.rotation);
        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        arrowRb.AddForce(arrowSpawn.right * arrowSpeed * (isFacing ? 1 : -1));
    }


    // ABILITY RELATED METHODS:
    public void ModifySpeed(float multiplier, float duration)
    {
        StartCoroutine(ChangeSpeed(speed * multiplier, duration));
    }

    public void ModifyJumpHeight(float multiplier, float duration)
    {
        StartCoroutine(ChangeJumpHeight(jumpForce * multiplier, duration));
    }

    public void ModifyFireRate(float newFireRate, float duration)
    {
        StartCoroutine(ChangeFireRate(newFireRate, duration));
    }

    // Coroutines for timed abilities
    IEnumerator ChangeSpeed(float newSpeed, float duration)
    {
        float originalSpeed = speed;
        speed = newSpeed;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }

    IEnumerator ChangeJumpHeight(float newJumpForce, float duration)
    {
        float originalJumpForce = jumpForce;
        jumpForce = newJumpForce;
        yield return new WaitForSeconds(duration);
        jumpForce = originalJumpForce;
    }

    IEnumerator ChangeFireRate(float newFireRate, float duration)
    {
        float originalFireRate = shootCooldown;
        shootCooldown = newFireRate;
        yield return new WaitForSeconds(duration);
        shootCooldown = originalFireRate;
    }
}

