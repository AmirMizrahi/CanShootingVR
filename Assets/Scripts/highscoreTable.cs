using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Delete it!!!

public class highscoreTable : MonoBehaviour
{
    private Transform entryContainer, entryTemplate;
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("highScoreEntryContainter");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Bubble sort
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = 0; j < highscores.highscoreEntryList.Count; j++)
            {
                //השוואה בין שני המחרוזות, לא בטוח עובד.
                if (string.Compare(highscores.highscoreEntryList[j].m_Score , highscores.highscoreEntryList[i].m_Score) == 1)
                {
                    //swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry item in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(item, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        int rank = 0;
        string score; //temp
        float templateHeight = 30f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        rank = transformList.Count + 1;
        entryTransform.Find("positionText").GetComponent<Text>().text = rank.ToString();

        score = highscoreEntry.m_Score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        transformList.Add(entryTransform);
    }

    public static void addHighscoreEntry(string i_Score)
    {
        //Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { m_Score = i_Score };

        //Load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Add new entry to highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //Save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
        
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public string m_Score;
    }
}
