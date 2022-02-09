using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class ScoreData
{
    public List<Score> m_Scores;

    public ScoreData()
    {
        m_Scores = new List<Score>();
    }
}
