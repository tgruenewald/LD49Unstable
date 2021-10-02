using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderChar : MonoBehaviour
{
    public float maxSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
    }
}
