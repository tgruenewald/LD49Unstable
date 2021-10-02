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
    // Start is called before the first frame update
    void Start()
    {
        groundCheck = GetComponent<CircleCollider2D>();
        Camera.main.GetComponent<SmoothCamera>().target = gameObject;
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);


        grounded = groundCheck.IsTouchingLayers (whatIsGround);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumping");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
        }

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
