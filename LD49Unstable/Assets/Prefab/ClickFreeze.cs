using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFreeze : MonoBehaviour
{
    public GameObject platform;
    public bool floating = true;
    public bool frozen = false;
    public GameObject listener;
    
    
    // Start is called before the first frame update
    void Start()
    {
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
        floating = false;
    }
    void OnMouseDown()
    {
        Debug.Log("hi");
        if(frozen)
        {
            frozen = false;
        }
        else if(listener.GetComponent<ClickListener>().getCharge() > 0)
        {
            frozen = true;
            listener.GetComponent<ClickListener>().useCharge();
        }
        
       
        
    }
}
