using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.TextCore;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    //public InputField playerInput;
    public Text playerNameText;
    //private bool isActive;
    public GameObject StartGame;

    public void Start()
    {
        //playerInput = GameObject.FindObjectOfType<InputField>();
        StartGame.SetActive(true);
    }

    public void SetPlayerName(string s)
    {
        playerNameText.text = s;
        DataPersManager.instance.playerStr = playerNameText.text;   // asigna el nombre del jugador a la instancia que maneja la persistencia de datos
    }

    // Load a scene
    public void StartScene()
    {
        if(DataPersManager.instance.playerStr == null || DataPersManager.instance.playerStr == "")
        {
            Debug.Log("No se coloco el nombre del jugador.");
            //isActive = false;
            SceneManager.LoadScene(0);
        }
        else
        {
            //isActive = true;
            SceneManager.LoadScene(1);
        }
    }

    // Exit of the app
    public void Exit()
    {
        Debug.Log("Terminado --- Usuario: " + DataPersManager.instance.playerStr);
        // save name of player on exit
        DataPersManager.instance.SavePlayer();

        // Compiler pre-directive to quit Unity player
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        EditorApplication.ExitPlaymode();
#else
    	Application.Quit();
#endif  
    }
}
