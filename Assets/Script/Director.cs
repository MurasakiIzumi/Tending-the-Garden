using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Director : MonoBehaviour
{
    [Header("Player")] public GameObject Player;
    [Header("天気")] public WeatherControl Weather;
    [Header("UI")] public GameObject UI;
    [Header("Enemy生成位置")] public Transform[] EnemySetPos;
    [Header("EnemyGroup")] public GameObject EnemyGroup;
    [Header("LevelUpシステム")] public LevelUpSystem levelUpSystem;

    private DataMessager dataMessager;
    //private int playerindex;
    private int weatherindex;

    private PlayerControl player;
    private UIControl ui;

    private float timer_SetEnemy;
    private float time_SetEnemy;

    private int NowEnemyGroupAlive;
    private int MaxEnemyGroupAlive;
    private int NowEnemyNum;
    private int Score;

    private int SetEnemyLv;
    private int nowPlayerLv;

    private bool CanSetEnemy;

    void Start()
    {
        player=Player.GetComponent<PlayerControl>();
        ui=UI.GetComponent<UIControl>();

        dataMessager = FindAnyObjectByType<DataMessager>().GetComponent<DataMessager>();
        GetInfoFromDataMessager();

        time_SetEnemy = 7f;
        timer_SetEnemy = time_SetEnemy;
        NowEnemyGroupAlive = 0;
        MaxEnemyGroupAlive = 8;
        NowEnemyNum = 0;
        Score = 0;
        SetEnemyLv = 1;
        nowPlayerLv = 1;
        CanSetEnemy = false;
    }

    void Update()
    {
        MoveWithPlayer();
        UIUpdate();
        CheckSetEnemyLevl();
        SetEnemyMain();
        PlayerLevelUp();
        CheckPlayerDead();
    }

    private void MoveWithPlayer()
    {
        transform.position = Player.transform.position;
    }

    private void UIUpdate()
    {
        ui.SetHp(player.ReturnHp());
        ui.SetLevel(player.ReturnLevel());
        ui.SetExp(player.ReturnExp(),player.ReturnMaxExp());
    }

    private void SetEnemyMain()
    {
        Timer();

        if (NowEnemyGroupAlive >= MaxEnemyGroupAlive)
        {
            return;
        }

        if (!CanSetEnemy)
        {
            return;
        }

        int index = Random.Range(0, EnemySetPos.Length);

        SetEnemyGroup(index);
    }

    private void SetEnemyGroup(int index)
    {
        Vector3 SetPos = EnemySetPos[index].position;

        SetPos.x += Random.Range(-0.5f, 0.5f);
        SetPos.y += Random.Range(-0.5f, 0.5f);

        GameObject enemygroup = Instantiate(EnemyGroup, SetPos, Quaternion.identity);

        enemygroup.GetComponent<EnemyGroupControl>().level = Random.Range(SetEnemyLv, 4);

        NowEnemyGroupAlive++;

        if (Random.Range(0, 100) <= 66)
        {
            CanSetEnemy = false;
        }
        
    }

    private void CheckSetEnemyLevl()
    {
        int Playerlv=player.ReturnLevel();

        if (Playerlv <= 4)
        {
            MaxEnemyGroupAlive = 8;
            time_SetEnemy = 4f;
            SetEnemyLv = 1;
        }
        else if (Playerlv <= 8)
        {
            MaxEnemyGroupAlive = 16;
            time_SetEnemy = 2f;
            SetEnemyLv = 2;
        }
        else
        {
            MaxEnemyGroupAlive = 32;
            time_SetEnemy = 1f;
            SetEnemyLv = 3;
        }

    }

    private void Timer()
    {
        timer_SetEnemy += Time.deltaTime;

        if (timer_SetEnemy >= time_SetEnemy)
        {
            CanSetEnemy = true;
            timer_SetEnemy = 0;
        }
    }

    public void EnemyGroupDestory()
    {
        NowEnemyGroupAlive--;
        ScoreUp(50);
    }

    private void PlayerLevelUp()
    {
        if (nowPlayerLv != player.ReturnLevel())
        {
            nowPlayerLv = player.ReturnLevel();

            Time.timeScale = 0;
            levelUpSystem.gameObject.SetActive(true);
            levelUpSystem.ResetSystem();
            levelUpSystem.RandomSkill(player.ReturnLevel(), player.ReturnSkillLv(1), player.ReturnSkillLv(2), player.ReturnSkillLv(3), player.ReturnSkillLv(4));
        }
    }

    private void CheckPlayerDead()
    {
        if (player.ReturnHp() <= 0)
        {
            dataMessager.SetTime(ui.ReturnTimeMin(), ui.ReturnTimeSec());
            dataMessager.SetScore(Score);
            SceneManager.LoadScene(4);
        }
    }

    public void PlayerExit()
    {
        dataMessager.SetTime(ui.ReturnTimeMin(), ui.ReturnTimeSec());
        dataMessager.SetScore(Score);
        SceneManager.LoadScene(4);
    }

    public void SetSkillLv(int index)
    {
        player.SetSkillLv(index);
    }

    public int ReturnEnemyNum()
    {
        NowEnemyNum++;
        return NowEnemyNum;
    }

    public void ScoreUp(int num)
    {
        Score += num;
        ui.SetScore(Score);
    }

    private void GetInfoFromDataMessager()
    {
        //playerindex = dataMessager.ReturnPlayerIndex();
        weatherindex = dataMessager.ReturnWeatherIndex();

        Weather.SetWeather(weatherindex);

        if (weatherindex == 4)
        {
            ui.SetTextColorBlack();
        }

    }

}
