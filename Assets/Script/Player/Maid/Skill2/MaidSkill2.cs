using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidSkill2 : MonoBehaviour
{
    public GameObject Player;
    [Header("回転速度")] public float rotatespeed = 5f;
    [Header("攻撃力")] public int damage = 10;
    [Header("はたき")]
    public GameObject Hataki1;
    public GameObject Hataki2;
    public GameObject Hataki3;
    public GameObject Hataki4;
    public GameObject Hataki5;
    public GameObject Hataki6;

    [SerializeField] public int skillLv;
    private int realskillLv;
    private int realdamage;
    private Vector3 CenterPos;

    void Start()
    {
        realskillLv = -1;
        realdamage = 0;
    }

    void Update()
    {
        Rotate();
        SkillLevelCheck();
    }

    private void Rotate()
    {
        if (skillLv == 0)
        {
            return;
        }

        CenterPos = Player.transform.position;

        transform.RotateAround(CenterPos, Vector3.forward, rotatespeed * Time.deltaTime);
    }

    private void SkillLevelCheck()
    {
        if (skillLv <= realskillLv)
        {
            return;
        }
        else
        {
            realskillLv=skillLv;
        }

        switch (skillLv)
        {
            case 0:
                SkillLv0();
                break;
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

    private void SkillLv0()
    {
        Hataki1.SetActive(false);
        Hataki2.SetActive(false);
        Hataki3.SetActive(false);
        Hataki4.SetActive(false);
        Hataki5.SetActive(false);
        Hataki6.SetActive(false);

        Debug.Log("メイドスギル2:Lv0");
    }

    private void SkillLv1()
    {
        Hataki1.SetActive(true);
        Hataki2.SetActive(false);
        Hataki3.SetActive(false);
        Hataki4.SetActive(true);
        Hataki5.SetActive(false);
        Hataki6.SetActive(true);

        Debug.Log("メイドスギル2:Lv1");
    }

    private void SkillLv2()
    {
        realdamage = damage;

        Debug.Log("メイドスギル2:Lv2");
    }

    private void SkillLv3()
    {
        Hataki1.SetActive(true);
        Hataki2.SetActive(true);
        Hataki3.SetActive(true);
        Hataki4.SetActive(true);
        Hataki5.SetActive(true);
        Hataki6.SetActive(true);

        Quaternion defultrotation = Hataki1.transform.rotation;

        Hataki2.transform.rotation = defultrotation;
        Hataki3.transform.rotation = defultrotation;
        Hataki5.transform.rotation = defultrotation;

        Debug.Log("メイドスギル2:Lv3");
    }

    private void SkillLv4()
    {
        rotatespeed *= 1.5f;

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
