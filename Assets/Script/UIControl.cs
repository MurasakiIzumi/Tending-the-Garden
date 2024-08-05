using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [Header("HPバー")] public GameObject Hp;
    [Header("タイマー")] public GameObject Timer;
    [Header("スコアバー")] public GameObject Score;
    [Header("Levelバー")] public GameObject Level;
    [Header("Expバー")] public GameObject Exp;
    public Image expbarimage1;
    public Image expbarimage2;

    private int hp;
    private float timer;
    private int min;
    private int sec;
    private int score;
    private int level;
    private int exp;
    private int maxexp;

    void Start()
    {
        hp = 0;
        timer = 0;
        min = 0;
        sec = 0;
        score = 0;
        level = 0;
        exp = 0;
    }

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        Hp.GetComponent<TextMeshProUGUI>().text = " HP:" + hp;
        Level.GetComponent<TextMeshProUGUI>().text = "Lv:" + level;
        Score.GetComponent<TextMeshProUGUI>().text = "Score:" + score;

        float Amout = (float)exp / maxexp;
        Exp.GetComponent<Image>().fillAmount = Amout;

        TimerCount();
        if (min >= 10)
        {
            if (sec >= 10)
            {
                Timer.GetComponent<TextMeshProUGUI>().text = min + ":" + sec;
            }
            else
            {
                Timer.GetComponent<TextMeshProUGUI>().text = min + ":0" + sec;
            }
        }
        else
        {
            if (sec >= 10)
            {
                Timer.GetComponent<TextMeshProUGUI>().text = "0" + min + ":" + sec;
            }
            else
            {
                Timer.GetComponent<TextMeshProUGUI>().text = "0" + min + ":0" + sec;
            }
        }
        
    }

    private void TimerCount()
    {
        if (timer >= 60f)
        {
            min++;
            timer = 0;
        }

        timer+=Time.deltaTime;
        sec = (int)timer;
    }

    public void SetHp(int newhp)
    {
        hp = newhp;
    }

    public void SetScore(int newscore)
    {
        score = newscore;
    }

    public void SetLevel(int newlevel)
    {
        level = newlevel;
    }

    public void SetExp(int newexp,int newmaxexp)
    {
        exp = newexp;
        maxexp = newmaxexp;
    }

    public void SetTextColorBlack()
    {
        Hp.GetComponent<TextMeshProUGUI>().color = Color.black;
        Level.GetComponent<TextMeshProUGUI>().color = Color.black;
        Score.GetComponent<TextMeshProUGUI>().color = Color.black;
        Exp.GetComponent<Image>().color = Color.black;
        expbarimage1.color = Color.black;
        expbarimage2.color = Color.black;
        Timer.GetComponent<TextMeshProUGUI>().color = Color.black;
    }

    public int ReturnTimeMin()
    {
        return min;
    }

    public int ReturnTimeSec()
    {
        return sec;
    }
}
