using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        GameObject go = GameObject.FindGameObjectsWithTag("freeze")[0];
        go.GetComponent<Text>().text = "" + amount;
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

    public static void gameOver() 
    {
        charge = 3;
        hasKey = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
