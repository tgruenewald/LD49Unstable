using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 6f;
    public CircleCollider2D groundCheck;
    public bool grounded = true;
    public LayerMask whatIsGround;
    /*public float jumpHeight = 10f;
    public float jumpTime = 200f;*/
    public float jumpForce = 5f;
    int x = 0;
    Vector2 jumpUp;
    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false;
        x = 0;
        //rb.isKinematic = true;

        Camera.main.GetComponent<SmoothCamera>().target = gameObject;
        jumpUp = new Vector2(0f, 1f) * jumpForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(jumpUp);
        grounded = groundCheck.IsTouchingLayers(whatIsGround);
        float tempSpeed = speed;
        print(x);
        if (x > 0)
        {
            tempSpeed = .5f * speed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(tempSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))//
        {
            transform.position -= new Vector3(tempSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w")&&x<5)
        {
            if (grounded)
            {
                //print("....................................madeithere");
                rb.AddForce(jumpUp);
                print("....................................madeithere");

                //transform.position += new Vector3(0, tempSpeed * Time.deltaTime, 0);
                
                x = 1;
                //jump();
            }
        }
        if (x > 0)
        {
            jump();
        }

    }
    void jump()
    {
        //transform.position += new Vector3(0, (-8 * jumpHeight * x) / (jumpTime * jumpTime) + (4 * jumpHeight) / jumpTime, 0);

        if (grounded && x > 3)//-1.75 will become variable that updates to nearest ground directly down
        {
            x = 0;
        }
        else
        {
            x += 1;
        }
    }
}
