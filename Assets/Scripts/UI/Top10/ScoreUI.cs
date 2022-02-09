using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public RowUI m_RowUi;
    public ScoreManager m_ScoreManager;

    private string currentScore;

    void Start()
    {
        Debug.Log(currentScore);
        Debug.Log("LOG: ScoreUI.Start");

        if (PlayerPrefs.GetString("score") != "-1") //Don't add score while initilize scene
        {
            m_ScoreManager.AddScore(new Score(score: currentScore));
        }

        var scores = m_ScoreManager.GetHighScores().ToArray();

        for (int i = 0; i < Mathf.Min(scores.Length,10); i++)
        {
            var row = Instantiate(m_RowUi, transform).GetComponent<RowUI>();
            row.m_Rank.text = (i + 1).ToString();
            row.m_Score.text = scores[i].score.ToString();
        }
    }

    private void OnEnable()
    {
        Debug.Log("LOG: ScoreUI.OnEnable");
        currentScore = PlayerPrefs.GetString("score");
    }
}