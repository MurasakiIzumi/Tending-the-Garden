using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaidSkill4 : MonoBehaviour
{
    [Header("“]ˆÚ‹——£")] public float distance = 10f;
    [Header("“]ˆÚŠÔ")] public float costtime = 0.25f;
    [Header("‰ñ”ãŒÀ")] public int maxtimes = 2;
    [Header("‰ñ”‰ñ•œŠÔ")] public float cooltime = 1f;
    [Header("UŒ‚—Í")] public int damage = 10;
    [Header("”š”­”g")]
    public GameObject ExploA;
    public GameObject ExploB;

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

    void Start()
    {
        Player = GetComponent<PlayerControl>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        costTimer = 0f;
        nowTimes = 0;
        coolTimer = 0f;
        Dir = Vector3.zero;
        isRun = false;
        startCosttimer = false;
        canExplo = false;

        realskillLv = 0;
        realdamage = 0;
        knockbackPower = 1f;
    }

    void Update()
    {
        StartCheck();
        TransformRun();
        CostTimer();
        CoolTimer();
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
    }

    private bool CheckCanRun()
    {
        if (isRun)
        {
            return false;
        }
        else if (nowTimes < 1)
        {
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
        Debug.Log("ƒƒCƒhƒXƒMƒ‹4:Lv1");
    }

    private void SkillLv2()
    {
        knockbackPower += knockbackPower;
        maxtimes++;
        Debug.Log("ƒƒCƒhƒXƒMƒ‹4:Lv2");
    }

    private void SkillLv3()
    {
        distance *= 1.5f;
        Debug.Log("ƒƒCƒhƒXƒMƒ‹4:Lv3");
    }

    private void SkillLv4()
    {
        realdamage = damage;
        maxtimes++;
        Debug.Log("ƒƒCƒhƒXƒMƒ‹4:Lv4");
    }

    public int ReturnDamage()
    {
        return realdamage;
    }

    public float ReturnKonckPower()
    {
        return knockbackPower;
    }
}
