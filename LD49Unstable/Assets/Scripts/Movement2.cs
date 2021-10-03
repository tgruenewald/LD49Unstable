using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement2 : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 6f;
    public CircleCollider2D groundCheck;
    public bool grounded = true;
    public LayerMask whatIsGround;
    /*public float jumpHeight = 10f;
    public float jumpTime = 200f;*/
    public float jumpForce = 1000f;
    public float dashForce = 1.5f;
    public float dashTime = 10f;
    int x = 0;//Jumpcounter;
    int x2 = 0;//Dashcounter;
    int dashMode = 0;//-1 means dashed expended, 0 means dash ready, 1-8 means dashing in one of eight directions
    // Start is called before the first frame update
    void Start()
    {
        //rb.useGravity = false;
        //x = 0;
        //rb.isKinematic = true;

        Camera.main.GetComponent<SmoothCamera>().target = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = groundCheck.IsTouchingLayers(whatIsGround);
        /*Code to maybe make the 'grounded' thing work better:
        LayerMask mask = LayerMask.GetMask("platform");
        if (Physics.Raycast(transform.position, new Vector3(0,-1,0), 20.0f, mask))
        {
            Debug.Log("Fired and hit a wall");
        }*/

        //rb.AddForce(jumpUp);
        
        float tempSpeed = speed;
        //print(x);
        if (!grounded)//(x > 0)
        {
            tempSpeed = 1.5f * speed;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {//ground sprint
            tempSpeed = 2f * speed;
        }

        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(tempSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.position -= new Vector3(tempSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("w") && x == 0)
        {
            if (grounded && !Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0f, jumpForce));

                //transform.position += new Vector3(0, tempSpeed * Time.deltaTime, 0);

                x = 1;
            }
        }

        /*Dash Initialize:*/
        if (Input.GetKey(KeyCode.Space) && (dashMode == 0) && (!grounded))
        {//Which way is it facing:
            if (Input.GetKey("w"))
            {
                dashMode = 1;
                if (Input.GetKey("a"))
                {
                    dashMode = 8;
                }
                if (Input.GetKey("d"))
                {
                    dashMode += 1;
                }
            }
            else if (Input.GetKey("s"))
            {
                dashMode = 5;
                if (Input.GetKey("d"))
                {
                    dashMode -= 1;
                }
                if (Input.GetKey("a"))
                {
                    dashMode += 1;
                }
            }
            else if (Input.GetKey("a"))
            {
                dashMode = 7;
                if (Input.GetKey("s"))
                {
                    dashMode -= 1;
                }
                if (Input.GetKey("w"))
                {
                    dashMode += 1;
                }
            }
            else if (Input.GetKey("d"))
            {
                dashMode = 3;//I'm pretty sure I don't need these next couple ifs because everything's been covered already but whatever
                if (Input.GetKey("w"))
                {
                    dashMode -= 1;
                }
                if (Input.GetKey("s"))
                {
                    dashMode += 1;
                }
            }
            //Possibly add an else{set to 3 or 7, depending on which way the hero is facing}
        }

        if (x > 0) //x>0 if it's jumping and not grounded
        {
            jump();
        }
        if (grounded)
        {
            dashMode = 0;
        }
        if (dashMode > 0)
        {
            dash();
        }
    }
    void jump()//Called when jump is active, doesn't make jump happen
    {
        if (x < 3)//Can't be regrounded for 3 frames, in case it's not perfectly on top of the platform
        {
            grounded = false;
        }
        if (grounded && x > 3)//-1.75 will become variable that updates to nearest ground directly down
        {
            x = 0;
            //dashMode = 0;
        }
        else
        {
            x += 1;//I don't actually remember if this does anything anymore, but anything above 0 means it's jumping and not grounded
        }

    }
    void dash()
    {//Dashmode is clockwise, U is 1, UL is 8
        if (grounded)
        {//End dash if grounded
            x2 = 0;
            dashMode = 0;
        }
        else
        {
            x2 += 1;//x2>0 means dash is active, also reduces dash speed throughout dash 
            if (x2 >= dashTime)
            {
                x2 = 0;
                dashMode = -1;//Expended dash (until grounded)
            }
            else
            {//Dash!
                if (dashMode % 2 == 1)//Non-diagonals
                {//1=U,3=R,5=D,7=L
                    if (dashMode%4==1)
                    {//Up and Down
                        transform.position += (new Vector3(0, dashForce*(1-x2/dashTime),0)) * ((dashMode / 4) * (-2) + 1);
                    }
                    else
                    {//Right and Left
                        transform.position += (new Vector3(dashForce*(1-x2/dashTime), 0, 0)) * ((dashMode / 4) * (-2) + 1);
                    }
                }
                else//Are-diagonals
                {//2=UR,4=DR,6=DL,8=UL
                    transform.position += (new Vector3(.707f * dashForce * (1 - x2 / dashTime), 0, 0)) * ((dashMode / 5) * (-2) + 1);//L/R
                    if (dashMode==8 || dashMode==2)
                    {
                        transform.position += (new Vector3(0, .707f * dashForce * (1 - x2 / dashTime), 0));//U
                    }
                    else
                    {
                        transform.position -= (new Vector3(0, .707f * dashForce * (1 - x2 / dashTime), 0));//D
                    }
                }
            }
        }
    }
}
