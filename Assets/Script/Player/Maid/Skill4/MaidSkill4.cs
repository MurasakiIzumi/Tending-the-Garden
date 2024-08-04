using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MaidSkill4 : MonoBehaviour
{
    [Header("転移距離")] public float distance = 10f;
    [Header("転移時間")] public float costtime = 0.25f;
    [Header("回数上限")] public int maxtimes = 2;
    [Header("回数回復時間")] public float cooltime = 1f;
    [Header("攻撃力")] public int damage = 10;
    [Header("爆発波")]
    public GameObject ExploA;
    public GameObject ExploB;

    [Header("UI:アイコンカバー")] public Image IconCover;
    [Header("UI:アイコン回数")] public TextMeshProUGUI IconTimes;

    private PlayerControl Player;
    private SpriteRenderer spriteRenderer;
    private float costTimer;
    private int nowTimes;
    private float coolTimer;
    private Vector3 Dir;

    private bool isRun;
    private bool startCosttimer;
    private bool canExplo;

    [SerializeField] public int skillLv = 0;
    private int realskillLv;
    private int realdamage;
    private float knockbackPower;
    private float iconspeed;
    private bool CanIconRotate;

    void Start()
    {
        Player = GetComponent<PlayerControl>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        costTimer = 0f;
        nowTimes = 1;
        coolTimer = 0f;
        Dir = Vector3.zero;
        isRun = false;
        startCosttimer = false;
        canExplo = false;

        realskillLv = -1;
        realdamage = 0;
        knockbackPower = 1f;
        iconspeed = 1f / cooltime;
        CanIconRotate = false;
    }

    void Update()
    {
        StartCheck();
        TransformRun();
        CostTimer();
        CoolTimer();
        IconRotate();
        SkillLevelCheck();
    }

    private void StartCheck()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!CheckCanRun())
            {
                return;
            }

            Vector2 Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 PlayerPos = transform.position;

            Dir = new Vector3(Mousepos.x - PlayerPos.x, Mousepos.y - PlayerPos.y, 0);
            Dir.Normalize();

            isRun = true;
            nowTimes--;
            startCosttimer = true;
            spriteRenderer.enabled = false;
            CanIconRotate = true;
            IconCover.fillAmount = 1f;
            IconTimes.text = nowTimes.ToString();
            SetExplo(true);

        }
    }

    private void TransformRun()
    {
        if (!isRun)
        {
            return;
        }

        transform.position += Dir * distance * Time.deltaTime;
    }

    private void CostTimer()
    {
        if (!startCosttimer)
        {
            costTimer = 0f;
            return;
        }

        if (costTimer >= costtime)
        {
            isRun = false;
            startCosttimer = false;
            spriteRenderer.enabled = true;
            costTimer = 0f;
            SetExplo(false);
        }
        else
        {
            costTimer += Time.deltaTime;
        }
    }

    private void CoolTimer()
    {
        if (nowTimes == maxtimes)
        {
            coolTimer = 0f;
            return;
        }

        if (coolTimer >= cooltime)
        {
            nowTimes++;
            nowTimes = Mathf.Min(nowTimes, maxtimes);
            coolTimer = 0f;
        }
        else
        {
            coolTimer += Time.deltaTime;
        }

        IconTimes.text = nowTimes.ToString();
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

    private bool CheckCanRun()
    {
        if (isRun)
        {
            return false;
        }
        else if (nowTimes < 1)
        {
            IconCover.fillAmount = 1f;
            CanIconRotate = false;
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SetExplo(bool isA)
    {
        if (!canExplo)
        {
            return;
        }

        if (isA)
        {
            GameObject explo = Instantiate(ExploA, transform.position, Quaternion.identity);
            explo.GetComponent<TeleExploControl>().SetInfo(realdamage, knockbackPower);
        }
        else
        {
            GameObject explo = Instantiate(ExploB, transform.position, Quaternion.identity);
            explo.GetComponent<TeleExploControl>().SetInfo(realdamage, knockbackPower);
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
        canExplo = true;
        Debug.Log("メイドスギル4:Lv1");
    }

    private void SkillLv2()
    {
        knockbackPower += knockbackPower;
        maxtimes++;
        Debug.Log("メイドスギル4:Lv2");
    }

    private void SkillLv3()
    {
        distance *= 1.5f;
        Debug.Log("メイドスギル4:Lv3");
    }

    private void SkillLv4()
    {
        realdamage = damage;
        maxtimes++;
        Debug.Log("メイドスギル4:Lv4");
    }

    public int ReturnDamage()
    {
        return realdamage;
    }

    public float ReturnKonckPower()
    {
        return knockbackPower;
    }

    public int ReturnSkillLv()
    {
        return realskillLv;
    }
}
