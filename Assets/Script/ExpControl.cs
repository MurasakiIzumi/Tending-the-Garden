using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpControl : MonoBehaviour
{
    [Header("ŒoŒ±’l")] public int Exp = 10;
    [Header("ˆÚ“®‘¬“x")] public float Speed = 10f;

    private GameObject player;
    private CircleCollider2D SeachArea;
    private bool GotoPlayer;

    void Start()
    {
        SeachArea=GetComponent<CircleCollider2D>();
        GotoPlayer = false;
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

        Vector3 Dir = player.transform.position - transform.position;
        transform.position += Dir * Speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) <= 0.1f)
        {
            player.GetComponent<PlayerControl>().GetExp(Exp);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject;
            SeachArea.enabled = false;
            GotoPlayer = true;
        }
    }
}
