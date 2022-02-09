using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ScoreManager : MonoBehaviour
{
    private ScoreData m_ScoreData;

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        Debug.Log("LOG: ScoreManager.Awake");
        Debug.Log("LOG: scores:" + json);
        m_ScoreData = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return m_ScoreData.m_Scores.OrderBy(x => x.score);
    }

    public void AddScore(Score score)
    {
        Debug.Log("LOG: ScoreManager.AddScore");
        m_ScoreData.m_Scores.Add(score);
    }

    private void OnDestroy()
    {
        if (PlayerPrefs.GetString("score") != "-1")
        {
            SaveScore();
        }
    }

    public void SaveScore()
    {
        Debug.Log("LOG: ScoreManager.SaveScore");
        var json = JsonUtility.ToJson(m_ScoreData);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);

    }
}
