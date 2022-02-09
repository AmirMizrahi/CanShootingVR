using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Can[] m_Cans;
    public TMP_Text m_InfoText;
    public bool m_ResertTable; //not working - delete?

    private string m_Score; //moved from private
    private float m_GameTimer = 0f;
    private float m_ResetTimer = 3f;

    //private void Awake()
    //{
    //    if (m_ResertTable)
    //    {
    //        PlayerPrefs.DeleteAll(); //Delete note whenever u want to restart the topTen table
    //        m_ResertTable = false;
    //    }
    //}

    void Update()
    {
        bool won = true;
        string winningTime;

        foreach(Can can in m_Cans)
        {
            if (can.wasHit == false)
            {
                won = false;
                break;
            }
        }

        if (!won)
        {
            m_GameTimer += Time.deltaTime;
            displayTime(m_GameTimer, false);
        }
        else
        {
            winningTime = m_InfoText.text;
            //infoText.alignment = TextAlignmentOptions.Top;
            displayTime(m_GameTimer, true);
            m_ResetTimer -= Time.deltaTime;
            if (m_ResetTimer <= 0f)
            {
                Debug.Log("Saved score correctly");
                PlayerPrefs.SetString("score", m_Score);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

    private void displayTime(float i_TimeToDisplay, bool i_IsEnded)
    {
        float minutes, seconds, milliSeconds;

        i_TimeToDisplay += 1;

        minutes = Mathf.FloorToInt(i_TimeToDisplay / 60);
        seconds = Mathf.FloorToInt(i_TimeToDisplay % 60);
        milliSeconds = (i_TimeToDisplay % 1) * 100;

        if (i_IsEnded)
        {
            m_InfoText.text = string.Format("You won!" + Environment.NewLine + "Your time: {0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
            m_Score = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
        }
        else
            m_InfoText.text = string.Format("Time: {0:00}:{1:00}:{2:00}", minutes, seconds, milliSeconds);
    }

    //private void OnDestroy()
    //{
    //    //PlayerPrefs.DeleteAll(); //Delete note whenever u want to restart the topTen table
    //    if (m_ResetTimer == 0)   //If game ended correctly
    //    {
    //        Debug.Log("Saved score correctly");
    //        PlayerPrefs.SetString("score", m_Score);
    //    }
    //}
}
