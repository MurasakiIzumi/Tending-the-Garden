using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatakiControl : MonoBehaviour
{
    public MaidSkill2 maidSkill2;
    private float rotateSpeed;
    private int damage;
    private float knockbackPower;

    void Start()
    {
        damage = maidSkill2.ReturnDamage();
        knockbackPower = 1f;
    }

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        rotateSpeed = maidSkill2.rotatespeed;
        transform.RotateAround(transform.position, Vector3.back, rotateSpeed * Time.deltaTime);
    }

    public int ReturnDamage()
    {
        return damage;
    }

    public float ReturnKonckPower()
    {
        return knockbackPower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemyControl Enemy = collision.GetComponent<EnemyControl>();

            if (Enemy.CanBeKnockBack())
            {
                Enemy.GetHurt(maidSkill2.ReturnDamage());
                Enemy.StartKnockBack(maidSkill2.transform.position, knockbackPower);
            }
        }
    }
}
