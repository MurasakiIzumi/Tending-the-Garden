using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataMessager : MonoBehaviour
{
    private int PlayerIndex;
    private int WeatherIndex;

    private int Time_Min;
    private int Time_Sec;
    private int Score;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    void Update()
    {
        
    }

    public void SetPlayer(int index)
    {
        PlayerIndex = index;
    }

    public int ReturnPlayerIndex()
    {
        return PlayerIndex;
    }

    public void SetWeather(int index)
    {
        WeatherIndex = index;
    }

    public int ReturnWeatherIndex()
    {
        return WeatherIndex;
    }

    public void SetTime(int min,int sec)
    {
        Time_Min = min;
        Time_Sec = sec;
    }

    public int ReturnTimeMin()
    {
        return Time_Min;
    }

    public int ReturnTimeSec()
    {
        return Time_Sec;
    }

    public void SetScore(int score)
    {
        Score = score;
    }

    public int ReturnScore()
    {
        return Score;
    }
}
