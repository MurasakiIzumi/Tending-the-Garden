using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSystem : MonoBehaviour
{
    [Header("Player1スギル")]　public GameObject Player1SkillIcon;
    [Header("矢印左")] public Image ArrowL;
    [Header("矢印右")] public Image ArrowR;
    [Header("矢印色")] public Color NotChoice;

    [Header("天気選択かご")] public GameObject WeatherSelect;
    [Header("各天気アイコン座標")] public Transform[] WeatherPos;
    [Header("Startボタン")] public GameObject start;

    [Header("SEプレイヤー")] public SEPlayer se;

    private DataMessager dataMessager;

    private int playerindex;
    private int weatherindex;

    void Start()
    {
        dataMessager=FindAnyObjectByType<DataMessager>().GetComponent<DataMessager>();
        playerindex = 0;
        weatherindex = 1;
    }

    void Update()
    {
        ChangeArrowColor();
        ChangeFlamePos();
        Player2CanNotUse();
    }

    private void ChangeArrowColor()
    {
        switch (playerindex)
        {
            case 0:
                Player1SkillIcon.SetActive(false);
                ArrowL.color = NotChoice;
                ArrowR.color = NotChoice;
                break;
            case 1:
                Player1SkillIcon.SetActive(true);
                ArrowL.color = Color.white;
                ArrowR.color = NotChoice;
                break;
            case 2:
                Player1SkillIcon.SetActive(false);
                ArrowL.color = NotChoice;
                ArrowR.color = Color.white;
                break;
        }
    }

    private void ChangeFlamePos()
    {
        WeatherSelect.transform.localPosition = WeatherPos[weatherindex - 1].localPosition;
    }

    private void Player2CanNotUse()
    {
        if (playerindex == 2)
        {
            se.PlayerBubu();
            start.SetActive(false);
        }
        else if (playerindex <= 0)
        {
            start.SetActive(false);
        }
        else
        {
            start.SetActive(true);
        }
    }

    public void SetPlayer(int index)
    {
        playerindex = index;
        dataMessager.SetPlayer(playerindex);
    }

    public void SetWeather(int index)
    {
        weatherindex = index;
        dataMessager.SetWeather(weatherindex);
    }
}
