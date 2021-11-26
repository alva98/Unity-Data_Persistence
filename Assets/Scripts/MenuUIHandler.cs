//using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    public Text bestScoreText;
    //public InputField inputPlayerName;
    public Button start;
    public Text playerName;
    private bool isActive;
    //public GameObject inputPlayer;

    // set the name of the player
    public void SetPlayerName(Text playerMenu)
    {
        if (playerMenu != null)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        if (isActive)
        {
            Debug.Log("Button Start is ACTIVE");
            //start.enabled();
            DataPersManager.instance.playerStr = playerMenu.text;
        }
        else
        {
            Debug.Log("Button Start is NOT ACTIVE");
        }
    }

    // Load a scene
    public void StartScene()
    {
        SetPlayerName(playerName);

        if (isActive)
        {
            SceneManager.LoadScene(1);
        }        
    }

    // Exit of the app
    public void Exit()
    {
        // save name of player on exit
        DataPersManager.instance.SavePlayer(); 

        // Compiler pre-directive to quit Unity player
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
    	Application.Quit();
#endif  
    }
}
