using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hazard : MonoBehaviour
{
    // Start is called before the first frame update
    bool dying = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator death(GameObject go)
    {
        go.GetComponent<Movement2>().die();
        yield return new WaitForSeconds(1f);
        GameState.gameOver();
        dying = false;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {   
            if (!dying)
            {
                dying = true;
                StartCoroutine(death(col.gameObject));
            }

        }
       
    }
}
