using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("ˆÚ“®‘¬“x")] public float moveSpeed;
    [Header("‰Œ–‹")] public GameObject Smoke;

    //[Header("Žè“®ƒXƒMƒ‹")] public GameObject Skill;
    //[Header("Ž©“®ƒXƒMƒ‹1")] public GameObject Skill1;
    //[Header("Ž©“®ƒXƒMƒ‹2")] public GameObject Skill2;
    //[Header("Ž©“®ƒXƒMƒ‹3")] public GameObject Skill3;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private float timer_smoke;
    private float time_smoke;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        audioSource=GetComponent<AudioSource>();

        timer_smoke = 0;
        time_smoke = 0.2f;
    }


    void Update()
    {
        ForwardChange();
        PlayerMove();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
