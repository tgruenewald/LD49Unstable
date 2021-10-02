using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderChar : MonoBehaviour
{
    public float maxSpeed = 2f;
    public LayerMask whatIsGround;
    private CircleCollider2D groundCheck;
    public bool grounded = true;
    public float JumpForce = 400f;
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
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        grounded = groundCheck.IsTouchingLayers (whatIsGround);

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumping");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
        }

    }
}
