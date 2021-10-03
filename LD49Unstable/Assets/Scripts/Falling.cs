using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public bool fall = false;
    public int timeTillFall = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(falling());


    }
    IEnumerator falling()
    {
        yield return new WaitForSeconds(timeTillFall);
        fall = true;
        gameObject.GetComponent<Rigidbody2D>().WakeUp();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
