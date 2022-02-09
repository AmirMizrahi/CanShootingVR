using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class ScoreData
{
    public List<Score> scores;

    public ScoreData()
    {
        scores = new List<Score>();
    }
}
