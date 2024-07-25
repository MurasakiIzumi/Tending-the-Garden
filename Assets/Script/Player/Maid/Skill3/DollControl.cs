using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class DollControl : MonoBehaviour
{
    public MaidSkill3 maidSkill3;

    public DollControl AnotherDoll;
    public GameObject Magic;

    public Vector3 offsetL;
    private Vector3 offsetR;

    private float timer_cool;
    private bool isLockOn;
    private bool canShoot;
    private GameObject Target;
    private int TargetNum;
    private float Range;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        offsetR = offsetL;
        offsetR.x *= -1f;
        timer_cool = 0;
        isLockOn = false;
        canShoot = false;
        TargetNum = 0;
        Range = maidSkill3.ReturnRange();
    }

    void Update()
    {
        ShootMagic();
        CoolTimer();
    }

    private void ShootMagic()
    {
        if (!canShoot)
        {
            return;
        }

        if (!isLockOn)
        {
            return;
        }

        if (Target == null)
        {
            isLockOn = false;
            return;
        }

        if (Vector3.Distance(transform.position, Target.transform.position) <= Range)
        {
            SetMagic();
        }
        else
        {
            Target = null;
            TargetNum = 0;
            isLockOn = false;
        }
    }

    private void SetMagic()
    {
        GameObject newMagic = Instantiate(Magic, transform.position, Quaternion.identity);
        MagicControl newmagicControl=newMagic.GetComponent<MagicControl>();
        newmagicControl.SetInfo(Target, maidSkill3.ReturnMagicSpeed(), maidSkill3.ReturnDamage());

        canShoot = false;
    }

    private void CoolTimer()
    {
        if (canShoot)
        {
            return;
        }

        if (timer_cool >= maidSkill3.ReturnCoolTime())
        {
            timer_cool = 0;
            canShoot = true;
        }
        else
        {
            timer_cool += Time.deltaTime;
        }
    }

    public void ChangeFilp(bool isL)
    {
        if (isL)
        {
            transform.localPosition = offsetL;
            spriteRenderer.flipX = false;
        }
        else
        {
            transform.localPosition = offsetR;
            spriteRenderer.flipX = true;
        }
    }

    public int ReturnTargetNum()
    {
        return TargetNum;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isLockOn)
        {
            if (collision.tag == "Enemy")
            {
                Target= collision.gameObject;
                TargetNum = Target.GetComponent<EnemyControl>().Enemynum;

                if (TargetNum != AnotherDoll.ReturnTargetNum())
                {
                    isLockOn = true;
                }
                else
                {
                    Target = null;
                    TargetNum = 0;
                }
            }
        }
    }
}
