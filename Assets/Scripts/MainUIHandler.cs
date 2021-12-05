using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    private MainManager mainManager;
    public Text playerNameMainUI;
    public Text scoreMainUIText;
    public Text bestScoreMainUIText;

    // Start is called before the first frame update
    void Start()
    {
        playerNameMainUI = gameObject.GetComponent<Text>();
        bestScoreMainUIText = gameObject.GetComponent<Text>();

       if(DataPersManager.instance != null)
        {
            // Put the player's name in gameObject PlayerText
            string s = "Player: " + DataPersManager.instance.playerStr;
            playerNameMainUI.text = s;
            Debug.Log("(MainUIHandler.Start) -Almacenado en DataPersManager.instance.playerStr: " + DataPersManager.instance.playerStr);
            Debug.Log("(MainUIHandler.Start) -Asignado a s: " + s);
            Debug.Log("(MainUIHandler.Start) -Guardado en playerNameMainUI.text: " + playerNameMainUI.text);

            // Put the best score in gameObject BestScoreText
            int bestScore = DataPersManager.instance.bestScore;
            //bestScoreMainUIText.text = "Best score: " + bestScore.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //scoreMainUIText.text = mainManager.scoreText.text;
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
