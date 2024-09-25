using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("ディレクター")] public Director director;
    [Header("最大HP")] public int MaxHp;
    [Header("移動速度")] public float moveSpeed;
    [Header("煙幕")] public GameObject Smoke;

    [SerializeField] private int Level;
    [SerializeField] private int Exp;
    [SerializeField] private int Hp;
    [SerializeField] private int ExpNeed;

    [Header("手動スギル")] public MaidSkill1 Skill1;
    [Header("自動スギル1")] public MaidSkill2 Skill2;
    [Header("自動スギル2")] public MaidSkill3 Skill3;
    [Header("自動スギル3")] public MaidSkill4 Skill4;

    [Header("受撃ボイスプレイヤー")] public AudioSource GetHurtSEplayer;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private float timer_smoke;
    private float time_smoke;

    private bool nodamage;
    private float timer_nodamge;
    private float time_nodamge;

    private float knockbackPower;

    private int playerdir;

    private bool isExit;

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

        ExpNeed = 8;

        nodamage = false;
        timer_nodamge = 0;
        time_nodamge = 0.2f;

        knockbackPower = 2f;

        playerdir = 2;
        isExit = false;
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
        float moveX = 0;
        float moveY = 0;

        if (!isExit)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
        }

        if ((moveX != 0) || (moveY != 0))
        {
            PlayerAnimationControl(moveX, moveY);
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
            PlayerAnimationControl();
            StopWalkSE();
            timer_smoke = 0;
        }

        transform.position += new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime;
    }

    private void PlayerAnimationControl()
    {
        switch (playerdir)
        {
            case 2:
                animator.Play("IdleS");
                break;
            case 4:
                animator.Play("IdleD");
                break;
            case 6:
                animator.Play("IdleD");
                break;
            case 8:
                animator.Play("IdleW");
                break;
        }
    }

    private void PlayerAnimationControl(float moveX, float moveY)
    {
        if (moveY == 0)
        {
            if (moveX < 0)
            {
                animator.Play("MoveD");
                playerdir = 4;
            }
            else
            {
                animator.Play("MoveD");
                playerdir = 6;
            }
        }
        else
        {
            if (moveY < 0)
            {
                animator.Play("MoveS");
                playerdir = 2;
            }
            else
            {
                animator.Play("MoveW");
                playerdir = 8;
            }
        }
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
            ExpNeed = (int)(ExpNeed * 1.25f);
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
            GetHurtSEplayer.Play();
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

    public int ReturnHp()
    {
        return Hp;
    }

    public int ReturnLevel()
    {
        return Level;
    }

    public int ReturnExp()
    {
        return Exp;
    }

    public int ReturnMaxExp()
    {
        return ExpNeed;
    }

    public int ReturnSkillLv(int index)
    {
        switch (index)
        {
            case 1:
                return Skill1.ReturnSkillLv();
            case 2:
                return Skill2.ReturnSkillLv();
            case 3:
                return Skill3.ReturnSkillLv();
            case 4:
                return Skill4.ReturnSkillLv();
            default:
                return 0;

        }
    }

    public void SetSkillLv(int index)
    {
        switch (index)
        {
            case 1:
                Skill1.skillLv++;
                break;
            case 2:
                Skill2.skillLv++;
                break;
            case 3:
                Skill3.skillLv++;
                break;
            case 4:
                Skill4.skillLv++;
                break;
            case 5:
                MaxHp += 10;
                Hp += 10;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exit")
        {
            if (Vector3.Distance(transform.position, collision.gameObject.transform.position) <= 1f)
            {
                Time.timeScale = 0.3f;
                animator.updateMode = AnimatorUpdateMode.UnscaledTime;
                collision.gameObject.GetComponent<AudioSource>().Play();
                isExit = true;

                StartCoroutine("Exit", 3f);
            }
        }
    }

    IEnumerator Exit(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);

        Time.timeScale = 1;
        director.PlayerExit();
    }
}
