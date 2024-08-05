using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    [Header("時間表示")] public TextMeshProUGUI Time;
    [Header("スコア表示")] public TextMeshProUGUI Score;

    private DataMessager dataMessager;

    private int min;
    private int sec;
    private int score;

    void Start()
    {
        dataMessager = FindAnyObjectByType<DataMessager>().GetComponent<DataMessager>();
        GetTime();
        GetScore();
    }

    private void GetTime()
    {
        min = dataMessager.ReturnTimeMin();
        sec = dataMessager.ReturnTimeSec();

        if (min >= 10)
        {
            if (sec >= 10)
            {
                Time.text = min + ":" + sec;
            }
            else
            {
                Time.text = min + ":0" + sec;
            }
        }
        else
        {
            if (sec >= 10)
            {
                Time.text = "0" + min + ":" + sec;
            }
            else
            {
                Time.text = "0" + min + ":0" + sec;
            }
        }
    }

    private void GetScore()
    {
        score = dataMessager.ReturnScore();
        Score.text = score.ToString();
    }
}
