using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleExploControl : MonoBehaviour
{
    [Header("Šg‘å—¦‘¬“x")] public float speed = 10f;
    [Header("Å‘å‹K–Í")] public float MaxScale = 3f;

    private int Damage;
    private float knockbackPower;

    void Update()
    {
        ChangeScale();
        DestroySelf();
    }

    private void ChangeScale()
    {
        float realSpeed=speed*Time.deltaTime;
        Vector3 nowScale = transform.localScale;

        nowScale = new Vector3(nowScale.x + realSpeed, nowScale.y + realSpeed, nowScale.z + realSpeed);

        transform.localScale = nowScale;
    }

    private void DestroySelf()
    {
        if (transform.localScale.x >= MaxScale)
        {
            Destroy(gameObject);
        }
    }

    public void SetInfo(int damage,float power)
    {
        Damage = damage;
        knockbackPower = power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyControl Enemy = collision.GetComponent<EnemyControl>();

            if (Enemy.CanBeKnockBack())
            {
                Enemy.GetHurt(Damage);
                Enemy.StartKnockBack(transform.position, knockbackPower);
            }
        }
    }
}
