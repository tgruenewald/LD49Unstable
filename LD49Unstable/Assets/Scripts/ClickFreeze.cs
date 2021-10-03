using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFreeze : MonoBehaviour
{
    public GameObject platform;
    public bool floating = true;
    public bool frozen = false;
    public int timeTillFall = 5;
    public Sprite sprite1;
    public Sprite sprite2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        platform = gameObject;
        platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
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
        }
       else
        {
            platform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
       if(platform.GetComponentInChildren<Clickable>().clickOn)
        {
            frozen = true;
            GameState.UseCharge();
            platform.GetComponentInParent<SpriteRenderer>().sprite = sprite2;
        }
       else
        {
            frozen = false;
            GameState.AddCharge();
            platform.GetComponentInParent<SpriteRenderer>().sprite = sprite1;
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
    /*
    void OnMouseDown()
    {
        Debug.Log("hi");
        if(frozen)
        {
            frozen = false;
            GameState.AddCharge();
            platform.GetComponentInParent<Rigidbody2D>().WakeUp();
            platform.GetComponentInParent<SpriteRenderer>().sprite = sprite1;
        }
        else if(GameState.GetCharge() > 0)
        {
            frozen = true;
            GameState.UseCharge();
            platform.GetComponentInParent<SpriteRenderer>().sprite = sprite2;
        }
        
       
        
    }
    */
  
}
