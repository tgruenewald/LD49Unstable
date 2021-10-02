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
    public int GetCharge()
    {
        return charge;
    }
    void SetCharge(int amount)
    {
        charge = amount;
    }
    public void UseCharge()
    {
        SetCharge(charge - 1);
    }
    public void AddCharge()
    {
        SetCharge(charge + 1);
    }
}
