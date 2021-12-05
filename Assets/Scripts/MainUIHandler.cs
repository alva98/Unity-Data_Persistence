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
       if(DataPersManager.instance != null)
        {
            // Put the player's name in gameObject PlayerText (in Editor)
            playerNameMainUI.text = "Player: " + DataPersManager.instance.playerStr;
            // Debug.Log("(MainUIHandler.Start) -Almacenado en DataPersManager.instance.playerStr: " + DataPersManager.instance.playerStr);

            // Put the best score in gameObject BestScoreText
            //Debug.Log("(MainUIHandler.Start) -Almacenado en DataPersManager.instance.bestScore: " + DataPersManager.instance.bestScore);
            bestScoreMainUIText.text = "Best score: " + DataPersManager.instance.bestScore.ToString();
            Debug.Log("(MainUIHandler.Start) -Recien guardado en bestScoreMainUIText.text: " + bestScoreMainUIText.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //scoreMainUIText.text = mainManager.scoreText.text;
    }

    public void BackToMenu()
    {
        Debug.Log("mainManager.m_GameOver: " + mainManager.m_GameOver);
        if (mainManager.m_GameOver)
        {
            //back to Menu.
            SceneManager.LoadScene(0);
        }
    }
}
