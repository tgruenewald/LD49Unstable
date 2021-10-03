using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial1 : MonoBehaviour
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
        if(Input.GetKeyDown(KeyCode.E))
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
                go.GetComponent<Text>().text = "Use A and D to move left and right press e to continue";
                break;
            case 1:
                go.GetComponent<Text>().text = "Use W to Jump press e to continue";
                break;
            case 2:
                go.GetComponent<Text>().text = "Jump and press space to dash in the air press e to continue";
                break;
            case 3:
                go.GetComponent<Text>().text = "Use left Shift to run press e to continue";
                break;
            default:
                go.GetComponent<Text>().text = " ";
                break;
        }


    }
}
