using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    void Awake()
    {
        var json = PlayerPrefs.GetString("scores", "{}");
        //sd = new ScoreData();
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderBy(x => x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
    }

    //private void OnLevelWasLoaded(int level)
    //{
    //    if (level == 0)
    //    {
    //        SaveScore();
    //    }
    //}

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        Debug.Log(json);
        PlayerPrefs.SetString("scores", json);
        //PlayerPrefs.SetInt("hasPlayed", 0);
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            destroy
        }
    }
}
