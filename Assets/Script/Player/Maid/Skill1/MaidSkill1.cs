using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class MaidSkill1 : MonoBehaviour
{
    public GameObject Player;
    [Header("回転速度")] public float rotatespeed = 100f;
    [Header("回転角度")] public float rotaterange = 90f;
    [Header("攻撃力")] public int damage = 20;
    [Header("ほうき")] public GameObject Houki;
    [Header("UI:アイコンカバー")] public Image IconCover;

    [SerializeField] public int skillLv = 1;
    private int realskillLv;
    private int realdamage;
    private float iconspeed;
    private Vector3 CenterPos;
    private Vector3 Dir;
    private float CenterAngle;
    private float StartAngle;
    private float EndAngle;
    private float RealAngle;


    private bool toStart;
    private bool isRun;
    private bool RighttoLeft;

    void Start()
    {
        realskillLv = -1;
        realdamage = damage;
        iconspeed = rotatespeed / 100f;
        toStart = false;
        isRun = false;
        RighttoLeft = true;
    }

    void Update()
    {
        StartCheck();
        Rotate();
        SkillLevelCheck();
    }

    private void StartCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CenterPos = Player.transform.position;
            Dir = new Vector3(Mousepos.x - CenterPos.x, Mousepos.y - CenterPos.y, 0);

            float angle = Vector3.Angle(Vector3.right, Dir);
            if (Mousepos.y <= CenterPos.y)
            {
                angle *= -1f;
            }

            CenterAngle = angle;

            toStart = true;
            IconCover.fillAmount = 1;
        }
    }

    private void Rotate()
    {
        if (!toStart)
        {
            return;
        }

        if (!isRun)
        {
            if (RighttoLeft)
            {
                StartAngle = CenterAngle - (rotaterange / 2);
                EndAngle = CenterAngle + (rotaterange / 2);
            }
            else
            {
                StartAngle = CenterAngle + (rotaterange / 2);
                EndAngle = CenterAngle - (rotaterange / 2);
            }

            RealAngle = StartAngle;
            transform.rotation = Quaternion.Euler(0, 0, StartAngle);
            Houki.GetComponent<HoukiControl>().SetAlphaUpStart();

            isRun = true;
        }

        if (isRun)
        {
            if (RighttoLeft)
            {
                RealAngle += rotatespeed * Time.deltaTime;

                RealAngle = Mathf.Min(RealAngle, EndAngle);
            }
            else
            {
                RealAngle -= rotatespeed * Time.deltaTime;

                RealAngle = Mathf.Max(RealAngle, EndAngle);
            }

            AlphaChange();
            transform.rotation = Quaternion.Euler(0, 0, RealAngle);
            IconCover.fillAmount -= iconspeed * Time.deltaTime;

            if (RealAngle == EndAngle)
            {
                if (RighttoLeft)
                {
                    RighttoLeft = false;
                }
                else
                {
                    RighttoLeft = true;
                }

                isRun = false;
                toStart = false;
                IconCover.fillAmount = 0;

                Houki.GetComponent<HoukiControl>().SetAlphaZero();
            }
        }

    }

    private void AlphaChange()
    {
        float angletoEnd = Mathf.Abs(RealAngle - EndAngle);

        if (angletoEnd <= rotaterange / 10f)
        {
            Houki.GetComponent<HoukiControl>().SetAlphaDownStart();
        }
    }

    private void SkillLevelCheck()
    {
        if (skillLv <= realskillLv)
        {
            return;
        }
        else
        {
            realskillLv = skillLv;
        }

        switch (skillLv)
        {
            case 1:
                SkillLv1();
                break;
            case 2:
                SkillLv2();
                break;
            case 3:
                SkillLv3();
                break;
            case 4:
                SkillLv4();
                break;
        }
    }

    private void SkillLv1()
    {
        Houki.GetComponent<HoukiControl>().SetKnockPower(2f);

        Debug.Log("メイドスギル1:Lv1");
    }

    private void SkillLv2()
    {
        realdamage += damage;

        Debug.Log("メイドスギル2:Lv2");
    }

    private void SkillLv3()
    {
        rotatespeed *= 2f;
        iconspeed *= 2f;

        Debug.Log("メイドスギル2:Lv3");
    }

    private void SkillLv4()
    {
        rotaterange *= 3f;
        iconspeed *= 0.35f;

        Debug.Log("メイドスギル2:LvMax");
    }

    public int ReturnDamage()
    {
        return realdamage;
    }

    public int ReturnSkillLv()
    {
        return realskillLv;
    }
}
