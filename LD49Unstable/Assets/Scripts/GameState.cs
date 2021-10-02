using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState 
{
    public static bool hasKey = false;
    public static int charge = 3;

    public static int GetCharge()
    {
        return charge;
    }
    public static void SetCharge(int amount)
    {
        charge = amount;
    }
    public static void UseCharge()
    {
        SetCharge(charge - 1);
    }
    public static void AddCharge()
    {
        SetCharge(charge + 1);
    }
}
