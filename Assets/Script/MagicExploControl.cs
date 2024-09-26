using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicExploControl : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        var state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.normalizedTime >= state.length)
        {
            spriteRenderer.enabled = false;

            if (!audioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
