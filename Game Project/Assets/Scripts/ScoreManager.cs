using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text ScoreTxt;
    public Text ScoreTxt2;

    public int score=0;
    public int winScore = 15;

    public Button PlayAgainBtn;
    public GameObject WonPanel;
    private void Awake()
    {
        instance = this;
    }
  
    void Update()
    {
        ScoreTxt.text = score.ToString();
        if (score==winScore)
        {
            ScoreTxt2.text = score.ToString();

            WonPanel.SetActive(true);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
