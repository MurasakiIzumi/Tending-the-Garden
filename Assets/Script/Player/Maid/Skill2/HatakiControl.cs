using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatakiControl : MonoBehaviour
{
    public MaidSkill2 maidSkill2;
    private float rotateSpeed;
    private int damage;
    void Start()
    {
        damage = maidSkill2.ReturnDamage();
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
}
