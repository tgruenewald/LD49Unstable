using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFreeze : MonoBehaviour
{
    public GameObject platform;
    public bool isAsleep = true;
    public bool forceSleep = false;
    public int charge = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
       if(forceSleep)
        {
            platform.GetComponent<Rigidbody2D>().Sleep();
            Debug.Log("ZZZ");
        }
    }
    void OnMouseDown()
    {
        Debug.Log("hi");
        if(charge > 0)
        {
            forceSleep = true;
            charge--;
        }
       
        
    }
}
