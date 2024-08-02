using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGroupControl : MonoBehaviour
{
    private Director director;
    public int level = 1;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    public GameObject Enemy7;
    public GameObject Enemy8;
    public GameObject Enemy9;

    void Start()
    {
        director = FindAnyObjectByType<Director>().GetComponent<Director>();
        LevelCheck();
    }

    void Update()
    {
        DestroySelf();
    }

    private void LevelCheck()
    {
        level = Mathf.Min(3, level);
        level = Mathf.Max(1, level);

        switch (level)
        {
            case 1:
                Enemy1.SetActive(true);
                Enemy2.SetActive(false);
                Enemy3.SetActive(false);
                Enemy4.SetActive(false);
                Enemy5.SetActive(false);
                Enemy6.SetActive(false);
                Enemy7.SetActive(false);
                Enemy8.SetActive(false);
                Enemy9.SetActive(false);
                break;
            case 2:
                Enemy1.SetActive(true);
                Enemy2.SetActive(true);
                Enemy3.SetActive(true);
                Enemy4.SetActive(true);
                Enemy5.SetActive(true);
                Enemy6.SetActive(false);
                Enemy7.SetActive(false);
                Enemy8.SetActive(false);
                Enemy9.SetActive(false);
                break;
            case 3:
                Enemy1.SetActive(true);
                Enemy2.SetActive(true);
                Enemy3.SetActive(true);
                Enemy4.SetActive(true);
                Enemy5.SetActive(true);
                Enemy6.SetActive(true);
                Enemy7.SetActive(true);
                Enemy8.SetActive(true);
                Enemy9.SetActive(true);
                break;
        }
    }

    private void DestroySelf()
    {
        switch (level)
        {
            case 1:
                if (!Enemy1)
                {
                    director.EnemyGroupDestory();
                    Destroy(gameObject);
                }
                break;
            case 2:
                if ((!Enemy1) && (!Enemy2) && (!Enemy3) && (!Enemy4) && (!Enemy5))
                {
                    director.EnemyGroupDestory();
                    Destroy(gameObject);
                }
                break;
            case 3:
                if ((!Enemy1) && (!Enemy2) && (!Enemy3) && (!Enemy4) && (!Enemy5) && (!Enemy6) && (!Enemy7) && (!Enemy8) && (!Enemy9))
                {
                    director.EnemyGroupDestory();
                    Destroy(gameObject);
                }
                break;
        }
    }
}
