using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFreeze : MonoBehaviour
{
    public GameObject platform;
    public bool floating = true;
    public bool frozen = false;
    public GameObject listener;
    public int timeTillFall = 5;
    
    
    // Start is called before the first frame update
    void Start()
    {
        platform = gameObject;
        platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    
    void Update()
    {
       if(frozen)
        {
            platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("ZZZ");
        }
       else if(floating)
        {
            platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log(platform.name);
        }
       else
        {
            platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(falling());
        
       
    }
    IEnumerator falling()
    {
        yield return new WaitForSeconds(timeTillFall);
        floating = false;
        platform.GetComponent<Rigidbody2D>().WakeUp();
    }
    void OnMouseDown()
    {
        Debug.Log("hi");
        if(frozen)
        {
            frozen = false;
            listener.GetComponent<ClickListener>().AddCharge();
            platform.GetComponent<Rigidbody2D>().WakeUp();
        }
        else if(listener.GetComponent<ClickListener>().GetCharge() > 0)
        {
            frozen = true;
            listener.GetComponent<ClickListener>().UseCharge();
        }
        
       
        
    }
}
