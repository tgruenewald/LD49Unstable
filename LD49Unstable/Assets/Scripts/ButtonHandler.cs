using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour {
	public void startGame()
    {
        Debug.Log("Starting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

	public void credits()
    {
        Debug.Log("credits");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    
	public void back()
    {
        Debug.Log("credits");
        SceneManager.LoadScene(0);
    }    

}
