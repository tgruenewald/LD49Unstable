using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour
{
    public int charge = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getCharge()
    {
        return charge;
    }
    void setCharge(int amount)
    {
        charge = amount;
    }
    public void useCharge()
    {
        setCharge(charge - 1);
    }
}
