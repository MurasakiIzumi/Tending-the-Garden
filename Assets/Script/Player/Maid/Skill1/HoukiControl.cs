using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoukiControl : MonoBehaviour
{
    [Header("è¡Ç¶ÇÈë¨ìx")] public float ChangeSpeed = 10f;
    public MaidSkill1 maidSkill1;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    private int damage;
    private float knockbackPower;
    private bool toAlphaUp;
    private bool toAlphaDown;

    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        polygonCollider.enabled= false;
        damage = maidSkill1.ReturnDamage();
        knockbackPower = 1f;
        toAlphaUp = false;
        toAlphaDown = false;
        SetAlphaZero();
    }

    void Update()
    {
        AlphaChange();
    }

    private void AlphaChange()
    {
        if ((!toAlphaUp) && (!toAlphaDown))
        {
            return;
        }

        Color color = spriteRenderer.color;

        if (toAlphaUp)
        {
            color.a += ChangeSpeed * Time.deltaTime;

            color.a = Mathf.Min(color.a, 1f);

            if (spriteRenderer.color.a == 1f)
            {
                toAlphaUp = false;
            }
        }

        if (toAlphaDown)
        {
            color.a -= ChangeSpeed * Time.deltaTime;

            color.a = Mathf.Max(color.a, 0f);

            if (spriteRenderer.color.a == 0)
            {
                toAlphaDown = false;
            }
        }

        spriteRenderer.color = color;

        Debug.Log(spriteRenderer.color);
    }

    public void SetAlphaUpStart()
    {
        if (!toAlphaUp)
        {
            toAlphaUp = true;
            polygonCollider.enabled = true;
        }
    }

    public void SetAlphaDownStart()
    {
        if (!toAlphaDown)
        {
            toAlphaDown = true;
        }
    }

    public void SetAlphaZero()
    {
        spriteRenderer.color = new Color(1, 1, 1, 0);
        polygonCollider.enabled = false;
    }

    public int ReturnDamage()
    {
        return damage;
    }

    public void SetKnockPower(float num)
    {
        knockbackPower = num;
    }

    public float ReturnKonckPower()
    {
        return knockbackPower;
    }
}
