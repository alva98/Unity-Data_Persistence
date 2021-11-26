using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    private MainManager mainManager;
    public Text playerNameMainUI;

    // Start is called before the first frame update
    void Start()
    {
        /*
       if(DataPersManager.Instance!=null)
        {
            playerNameMainUI = DataPersManager.Instance.player;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        if (mainManager.m_GameOver)
        {
            //back to Menu.
            SceneManager.LoadScene(0);
        }
    }
}
