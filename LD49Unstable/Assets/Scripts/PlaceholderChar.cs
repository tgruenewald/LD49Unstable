using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlaceholderChar : MonoBehaviour
{
    public float maxSpeed = 8f;
    public LayerMask whatIsGround;
    private CircleCollider2D groundCheck;
    public bool grounded = true;
    public float JumpForce = 600F;
    private bool facingRight = true;
    private float dashStartTime = 0.1f;
    private float dashTime;
    private bool startDash = false;
    public float dashForce = 80f;
    private int dashDirection;
    private Rigidbody2D rb;
    bool dashUp = true;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        groundCheck = GetComponent<CircleCollider2D>();
        Camera.main.GetComponent<SmoothCamera>().target = gameObject;
        dashTime = dashStartTime;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }        
        
        if (!startDash) 
        {
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x != 0)
        {
            animator.SetBool("isWalking", true);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        // dash
        // Pressing up arrow will cause a dash in the current direction
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            startDash = true;
            dashTime = dashStartTime;
            dashDirection = (int) move;
            Debug.Log("dash: " + dashDirection);

        }
        if (startDash)
        {
            if (!grounded && dashUp) {
                rb.AddForce(new Vector2(0, 800f));    
                Debug.Log("Dashing up");
                dashUp = false;
            }
            if (move != 0) {
                rb.AddForce(new Vector2(150f*move,  0));
            }
            
            dashTime -= Time.deltaTime;
            // Debug.Log(dashTime);
            if (dashTime <= 0)
            {
                Debug.Log("Dash done");
                startDash = false;
            }
        }



        grounded = groundCheck.IsTouchingLayers (whatIsGround);
        if (grounded && !dashUp) {
            // then reset
            dashUp = true;
            Debug.Log("reset dashup");

        }
        if (!grounded) 
        {
            animator.SetBool("isJumping", true);
        }
        else 
        {
            animator.SetBool("isJumping", false);
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumping");
            rb.AddForce(new Vector2(0, JumpForce));
            
        }

        if (rb.transform.position.y < -100f)
        {
            // then characther fell
            Debug.Log("Character fell");
            GameState.gameOver();

        }

    }

    public void die()
    {
        Debug.Log("is dying");
        animator.SetBool("isDying", true);
    }

    void Flip()
    {
        //Debug.Log("switching...");
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }    
}
