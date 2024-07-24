using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("ç≈ëÂHP")] public int MaxHp;
    [Header("à⁄ìÆë¨ìx")] public float moveSpeed;
    [Header("âåñã")] public GameObject Smoke;

    [SerializeField] private int Level;
    [SerializeField] private int Exp;
    [SerializeField] private int Hp;

    //[Header("éËìÆÉXÉMÉã")] public GameObject Skill;
    //[Header("é©ìÆÉXÉMÉã1")] public GameObject Skill1;
    //[Header("é©ìÆÉXÉMÉã2")] public GameObject Skill2;
    //[Header("é©ìÆÉXÉMÉã3")] public GameObject Skill3;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private float timer_smoke;
    private float time_smoke;

    private int ExpNeed;

    private bool nodamage;
    private float timer_nodamge;
    private float time_nodamge;

    private float knockbackPower;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        audioSource=GetComponent<AudioSource>();

        Level = 1;
        Exp = 0;
        Hp = MaxHp;

        timer_smoke = 0;
        time_smoke = 0.2f;

        ExpNeed = 4;

        nodamage = false;
        timer_nodamge = 0;
        time_nodamge = 0.2f;

        knockbackPower = 2f;
    }


    void Update()
    {
        ForwardChange();
        PlayerMove();
        LevelUp();
        NodamageTimer();
    }

    private void ForwardChange()
    {
        Vector2 Mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Mousepos.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (Mousepos.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX != 0) || (moveY != 0))
        {
            animator.Play("Move");
            PlayWalkSE();

            if (timer_smoke >= time_smoke)
            {
                SmokeMaker();
                timer_smoke = 0;
            }
            else
            {
                timer_smoke += Time.deltaTime;
            }
        }
        else
        {
            animator.Play("Idle");
            StopWalkSE();
            timer_smoke = 0;
        }

        transform.position += new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime;
    }

    private void SmokeMaker()
    {
        Vector3 SetPostion = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        Instantiate(Smoke, SetPostion, Quaternion.identity);
    }

    private void PlayWalkSE()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopWalkSE()
    {
        if(audioSource.isPlaying)
        { 
            audioSource.Stop();
        }
    }

    private void LevelUp()
    {
        if (Exp >= ExpNeed)
        {
            Exp = 0;
            Level++;
            ExpNeed *= 2;
        }
    }

    public void GetExp(int exp)
    {
        Exp += exp;
    }

    public void GetHurt(int damage)
    {
        if (!nodamage)
        {
            Hp-=damage;
            nodamage = true;
        }
    }

    private void NodamageTimer()
    {
        if (!nodamage)
        {
            return;
        }

        if (timer_nodamge >= time_nodamge)
        {
            timer_nodamge = 0;
            nodamage = false;
        }
        else
        {
            timer_nodamge += Time.deltaTime;
        }
    }

    public float ReturnKonckPower()
    {
        return knockbackPower;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
