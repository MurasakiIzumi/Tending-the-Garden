using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [Header("Hpíl")] public int MaxHp = 10;
    [Header("çUåÇóÕ")] public int Damage = 5;
    [Header("ë¨ìx")] public float Speed = 1f;

    private GameObject Player;
    private CircleCollider2D SeachArea;
    private int hp;
    private int realdamage;

    private bool GotoPlayer;

    void Start()
    {
        SeachArea=GetComponent<CircleCollider2D>();
        hp = MaxHp;
        realdamage = Damage;
    }

    void Update()
    {
        GoToPlayer();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player = collision.gameObject;
            GotoPlayer = true;
            SeachArea.enabled = false;
        }
    }
}
