using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("UI:アイコン")] public Image Icon;
    [Header("UI:アイコンカバー")] public Image IconCover;

    [SerializeField] public int skillLv;
    private int realskillLv;
    private int realdamage;

    private float SmoothTime = 0.3f;
    private Vector3 Velocity = Vector3.zero;
    private float iconspeed;
    private bool CanIconRotate;

    void Start()
    {
        realskillLv = -1;
        realdamage = damage;
        iconspeed = 1f / time_cool;
        CanIconRotate = false;
        CheckFilp();
    }

    void Update()
    {
        CheckFilp();
        MoveWithPlayer();
        IconRotate();
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

    private void IconRotate()
    {
        if (!CanIconRotate)
        {
            return;
        }

        IconCover.fillAmount -= iconspeed * Time.deltaTime;

        if (IconCover.fillAmount <= 0)
        {
            IconCover.fillAmount = 0;
        }
    }

    public void SetIconFillAmout(bool canStart, int num)
    {
        CanIconRotate = canStart;

        IconCover.fillAmount = num;
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

        Icon.gameObject.SetActive(false);
        IconCover.gameObject.SetActive(false);
        CanIconRotate = false;

        Debug.Log("メイドスギル3:Lv0");
    }

    private void SkillLv1()
    {
        Doll1.SetActive(true);
        Doll2.SetActive(false);

        Icon.gameObject.SetActive(true);
        IconCover.gameObject.SetActive(true);

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
        iconspeed = 1f / time_cool;
        Debug.Log("メイドスギル3:Lv3");
    }

    private void SkillLv4()
    {
        realdamage += damage;
        time_cool /= 1.5f;
        iconspeed = 1f / time_cool;
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

    public int ReturnSkillLv()
    {
        return realskillLv;
    }
}
