using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    private MainManager mainManager;
    //public Text scoreMainUIText;
    public Text playerNameMainUI;
    public Text bestScoreMainUIText;
    public Button clearBestScoreBtn;
    public Button backToMenuBtn;
    private Button btn1, btn2;

    // Start is called before the first frame update
    void Start()
    {
       if(DataPersManager.instance != null)
        {
            // Put the player's name in gameObject PlayerText (in Editor)
            playerNameMainUI.text = "Player: " + DataPersManager.instance.playerStr;

            // Put the best score in gameObject BestScoreText
            bestScoreMainUIText.text = "Best score: " + DataPersManager.instance.bestScore.ToString();
        }
        btn1 = clearBestScoreBtn.GetComponent<Button>();
        btn2 = backToMenuBtn.GetComponent<Button>();
        btn1.onClick.AddListener(ClearBestScore);
    }

    // Update is called once per frame
    void Update()
    {
        btn2.onClick.AddListener(BackToMenu);
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("menu");
        if (Input.GetKeyDown(KeyCode.C))
            ClearBestScore();

        if (Input.GetButtonDown("BackToMenu"))
            BackToMenu();
        
    }

    public void ClearBestScore()
    {
        DataPersManager.instance.bestScore = 0;
        bestScoreMainUIText.text = "Best score: " + DataPersManager.instance.bestScore.ToString();
        Debug.Log("Best score cleaned");
    }

    public void BackToMenu()
    {
        //Debug.Log("mainManager.m_GameOver: " + mainManager.m_GameOver + " ...return to menu");
        //back to Menu.
        SceneManager.LoadScene(0);
    }
}
