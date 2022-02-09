using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUi;
    public ScoreManager scoreManager;
    private string currentScore;

    void Start()
    {
        Debug.Log(currentScore);

        int hasPlayed = PlayerPrefs.GetInt("hasPlayed");
        
        // test
        if (hasPlayed == 0)
        {
            scoreManager.AddScore(new Score(score: currentScore));

            PlayerPrefs.SetInt("hasPlayed", 1);
        }
        //

        //scoreManager.AddScore(new Score(score: currentScore));

        var scores = scoreManager.GetHighScores().ToArray();

        for (int i = 0; i < Mathf.Min(scores.Length,10); i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.score.text = scores[i].score.ToString();
        }
    }

    private void OnEnable()
    {
        currentScore = PlayerPrefs.GetString("score");
    }
}
