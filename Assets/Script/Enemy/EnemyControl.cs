using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Hp値")] public int MaxHp = 10;
    [Header("攻撃力")] public int Damage = 5;
    [Header("速度")] public float Speed = 1f;
    [Header("撃退力")] public float BackPower = 5f;
    [Header("経験値")] public GameObject Exp;
    public int Enemynum;
    private GameObject Player;
    private CircleCollider2D SeachArea;
    private int hp;
    private int realdamage;

    private Vector3 BackDir;
    private float knockbackpower;

    private float timer_knockback;
    private float time_knockback;

    private bool GotoPlayer;
    private bool beKnockBack;

    void Start()
    {
        SeachArea=GetComponent<CircleCollider2D>();
        hp = MaxHp;
        realdamage = Damage;
        BackDir = Vector3.zero;
        knockbackpower = 0;
        timer_knockback = 0;
        time_knockback = 0.5f;
        GotoPlayer = false;
        beKnockBack = false;
    }

    void Update()
    {
        GoToPlayer();
        KnockBack();
        DeathCheck();
    }

    private void GoToPlayer()
    {
        if (!GotoPlayer)
        {
            return;
        }

        Vector3 Dir = Player.transform.position - transform.position;
        Dir.Normalize();
        transform.position += Dir * Speed * Time.deltaTime;
    }

    private void KnockBack()
    {
        if (!beKnockBack)
        {
            return;
        }

        transform.position += BackDir * knockbackpower * BackPower * Time.deltaTime;

        if (timer_knockback >= time_knockback)
        {
            timer_knockback = 0;
            beKnockBack = false;
            GotoPlayer = true;
            BackDir = Vector3.zero;
            knockbackpower = 0;
        }
        else
        {
            timer_knockback += Time.deltaTime;
        }
    }

    public bool CanBeKnockBack()
    {
        if (SeachArea.enabled == false)
        {
            return !beKnockBack;
        }
        else
        {
            return false;
        }
    }

    public void StartKnockBack(Vector3 Pos, float Power)
    {
        GotoPlayer = false;
        beKnockBack = true;

        BackDir = Pos - transform.position;
        BackDir.Normalize();
        BackDir *= -1f;

        knockbackpower = Power;
    }

    public void GetHurt(int damage)
    {
        hp-=damage;
    }

    private void DeathCheck()
    {
        if ((hp <= 0) && !beKnockBack)
        {
            Instantiate(Exp, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player = collision.gameObject;
            GotoPlayer = true;
            SeachArea.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControl Player=collision.gameObject.GetComponent<PlayerControl>();

            Player.GetHurt(realdamage);

            StartKnockBack(Player.transform.position, Player.ReturnKonckPower());
        }
    }
}
