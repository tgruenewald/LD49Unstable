using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public bool clickOn = false;
    public bool clickOff = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        Debug.Log("Click");
        if(clickOff)
        {
            clickOn = true;
            clickOff = false;
            GameState.UseCharge();

        }
        else if(clickOn)
        {
            clickOff = true;
            clickOn = false;
            GameState.AddCharge();
        }
    }


}
