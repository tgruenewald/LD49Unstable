using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2 : MonoBehaviour
{
    public int tutorialStage = 0;
    // Start is called before the first frame update
    void Start()
    {
        tutorialMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            tutorialMovement();
            tutorialStage++;

        }

    }
    void tutorialMovement()
    {

        GameObject go = GameObject.FindGameObjectsWithTag("Tutorial")[0];
        go.GetComponent<Text>().text = "";
        switch (tutorialStage)
        {
            case 0:
                go.GetComponent<Text>().text = "Platforms will fall after you touch them Press E to continue";
                break;
            case 1:
                go.GetComponent<Text>().text = "CLick on a platform to freeze it Press E to continue";
                break;
            case 2:
                go.GetComponent<Text>().text = "You only have a limited number of freezes press e to continue";
                break;
            case 3:
                go.GetComponent<Text>().text = "Click on a frozen platform to unfreeze it and regain a freeze";
                break;
            default:
                go.GetComponent<Text>().text = " ";
                break;
        }


    }
}
