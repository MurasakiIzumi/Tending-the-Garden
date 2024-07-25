using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class MaidSkill1 : MonoBehaviour
{
    public GameObject Player;
    [Header("âÒì]ë¨ìx")] public float rotatespeed = 100f;
    [Header("âÒì]äpìx")] public float rotaterange = 90f;
    [Header("çUåÇóÕ")] public int damage = 20;
    [Header("ÇŸÇ§Ç´")] public GameObject Houki;

    [SerializeField] public int skillLv = 1;
    private int realskillLv;
    private int realdamage;
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
        realskillLv = 0;
        realdamage = damage;
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

        Debug.Log("ÉÅÉCÉhÉXÉMÉã1:Lv1");
    }

    private void SkillLv2()
    {
        realdamage += damage;

        Debug.Log("ÉÅÉCÉhÉXÉMÉã2:Lv2");
    }

    private void SkillLv3()
    {
        rotatespeed *= 2f;

        Debug.Log("ÉÅÉCÉhÉXÉMÉã2:Lv3");
    }

    private void SkillLv4()
    {
        rotaterange *= 3f;

        Debug.Log("ÉÅÉCÉhÉXÉMÉã2:LvMax");
    }

    public int ReturnDamage()
    {
        return realdamage;
    }
}
