using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaidSkill3 : MonoBehaviour
{
    public GameObject Player;
    [Header("攻撃力")] public int damage = 5;
    [Header("ドール")]
    public GameObject Doll1;
    public GameObject Doll2;
    [Header("魔法速度")] public float magicSpeed = 7f;
    [Header("射撃間隔")] public float time_cool = 2f;
    [Header("射程")] public float Range = 20f;


    [SerializeField] public int skillLv;
    private int realskillLv;
    private int realdamage;

    private float SmoothTime = 0.3f;
    private Vector3 Velocity = Vector3.zero;

    void Start()
    {
        realskillLv = -1;
        realdamage = damage;
        CheckFilp();
    }

    void Update()
    {
        CheckFilp();
        MoveWithPlayer();
        SkillLevelCheck();
    }

    private void CheckFilp()
    {
        if (Player.GetComponent<SpriteRenderer>().flipX)
        {
            Doll1.GetComponent<DollControl>().ChangeFilp(false);
            Doll2.GetComponent<DollControl>().ChangeFilp(false);
        }
        else
        {
            Doll1.GetComponent<DollControl>().ChangeFilp(true);
            Doll2.GetComponent<DollControl>().ChangeFilp(true);
        }
    }

    private void MoveWithPlayer()
    {
        Vector3 targetPosition = Player.transform.position;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, SmoothTime);

        transform.position = smoothPosition;
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
        Doll1.SetActive(false);
        Doll2.SetActive(false);
        Debug.Log("メイドスギル3:Lv0");
    }

    private void SkillLv1()
    {
        Doll1.SetActive(true);
        Doll2.SetActive(false);
        Debug.Log("メイドスギル3:Lv1");
    }

    private void SkillLv2()
    {
        realdamage += damage;
        Debug.Log("メイドスギル3:Lv2");
    }

    private void SkillLv3()
    {
        Doll1.SetActive(true);
        Doll2.SetActive(true);
        time_cool /= 1.5f;
        Debug.Log("メイドスギル3:Lv3");
    }

    private void SkillLv4()
    {
        realdamage += damage;
        time_cool /= 1.5f;
        Debug.Log("メイドスギル3:LvMax");
    }

    public int ReturnDamage()
    {
        return realdamage;
    }

    public float ReturnMagicSpeed()
    {
        return magicSpeed;
    }

    public float ReturnRange()
    {
        return Range;
    }

    public float ReturnCoolTime()
    {
        return time_cool;
    }
}
